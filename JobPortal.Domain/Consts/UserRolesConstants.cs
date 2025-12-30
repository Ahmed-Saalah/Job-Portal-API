namespace JobPortal.Domain.Consts
{
    public class UserRolesConstants
    {
        public const string JobSeeker = "jobseeker";
        public const string Recruiter = "recruiter";

        public static readonly string[] AllRoles = [JobSeeker, Recruiter];
    }
}
