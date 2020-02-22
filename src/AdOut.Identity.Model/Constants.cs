namespace AdOut.Identity.Model
{
    public class Constants
    {
        //_T - template
        public class Messages
        {
            public static string USER_EXISTS_T = "User with name {0} has already registrated";
            public static string USER_INVALID = "UserName or password is invalid";
        }

        public class ClaimsTypes
        {
            public static string Permission = "permission";
        }
    }
}
