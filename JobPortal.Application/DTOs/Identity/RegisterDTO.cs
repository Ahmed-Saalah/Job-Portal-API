namespace JobPortal.Application.DTOs.Identity
{
    public class RegisterDTO : BaseModel
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role {  get; set; } = string.Empty;
    }
}
