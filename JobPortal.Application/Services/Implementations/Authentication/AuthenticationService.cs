using AutoMapper;
using FluentValidation;
using JobPortal.Application.DTOs;
using JobPortal.Application.DTOs.Identity;
using JobPortal.Application.Services.Interfaces.Authentication;
using JobPortal.Application.Services.Interfaces.Logging;
using JobPortal.Application.Validation;
using JobPortal.Domain.Entities.Identity;
using JobPortal.Domain.Interfaces.Authentication;

namespace JobPortal.Application.Services.Implementations.Authentication
{
    public class AuthenticationService
            (ITokenManagement tokenManagement, IUserManagement userManagement,
            IRoleManagement roleManagement, IAppLogger<AuthenticationService> logger,
            IMapper mapper, IValidator<RegisterDTO> createUserValidator,
            IValidator<LoginDTO> loginUserValidator,
            IValidationService validationService) : IAuthenticationService
    {
        public async Task<ServiceResponse> RegisterUser(RegisterDTO user)
        {
            var _validationResult = await validationService
                .ValidateAsync(user, createUserValidator);

            if (!_validationResult.Success)
                return _validationResult;
          
            if (user.Role != "JobSeeker" && user.Role != "Recruiter")
                return new ServiceResponse { Message = "Invalid role. Choose either 'JobSeeker' or 'Recruiter'." };
           
            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.UserName = user.Email;
            mappedModel.PasswordHash = user.Password;

            var result = await userManagement.CreateUser(mappedModel);

            if (!result)
                return new ServiceResponse { Message = "Email might be already in use or unknown error occured" };

            var _user = await userManagement.GetUserByEmail(user.Email);

            bool assignedResult = await roleManagement.AddUserToRole(_user!, user.Role);

            if (assignedResult == false)
            {
                int removeUserResult = await userManagement.RemoveUserByEmail(_user!.Email!);
                if (removeUserResult <= 0)
                {
                    logger.LogError(new Exception($"User with email {_user.Email} failed to be remove as a result of role assigning issue"),
                        "User could not be assigned role");
                    return new ServiceResponse { Message = "Error occured in creating account" };
                }
            }
            return new ServiceResponse { Success = true, Message = "Account created" };
        }
        public async Task<LoginResponse> LoginUser(LoginDTO user)
        {
            var _validationResult = await validationService.ValidateAsync(user, loginUserValidator);
            if (_validationResult.Success == false)
                return new LoginResponse(Message: _validationResult.Message);

            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.PasswordHash = user.Password;

            bool loginResult = await userManagement.LoginUser(mappedModel);
            if (loginResult == false)
                return new LoginResponse(Message: "Email not found or invalid credntials");

            var _user = await userManagement.GetUserByEmail(user.Email);
            var claims = await userManagement.GetUserClaims(_user!.Email!);

            string jwtToken = tokenManagement.GenerateToken(claims);
            string refreshToken = tokenManagement.GetRefreshToken();

            int saveTokenResult = 0;

            bool userTokenCheck = await tokenManagement.ValidateRefreshToken(refreshToken);
            if (userTokenCheck == true)
            {
                saveTokenResult = await tokenManagement.UpdateRefreshToken(_user.Id, refreshToken);
            }
            else
            {
                saveTokenResult = await tokenManagement.AddRefreshToken(_user.Id, refreshToken);
            }
            if (saveTokenResult <= 0)
            {
                return new LoginResponse(Message: "Internal error occured while authenticating");
            }
            else
            {
                return new LoginResponse(Success: true, Token: jwtToken, RefreshToken: refreshToken);
            }
        }
        public async Task<LoginResponse> ReviveToken(string refreshToken)
        {
            bool validateTokenResult = await tokenManagement
                .ValidateRefreshToken(refreshToken);

            if (validateTokenResult == false)
                return new LoginResponse(Message: "Invalid token");

            string userId = await tokenManagement.GetUserIdByRefreshToken(refreshToken);
            AppUser? user = await userManagement.GetUserById(userId);
            var claims = await userManagement.GetUserClaims(user.Email!);
            string newJwtToken = tokenManagement.GenerateToken(claims);
            string newRefreshToken = tokenManagement.GetRefreshToken();
            await tokenManagement.UpdateRefreshToken(userId, newRefreshToken);
            return new LoginResponse(Success: true, Token: newJwtToken, RefreshToken: newRefreshToken);
        }
    }
}
