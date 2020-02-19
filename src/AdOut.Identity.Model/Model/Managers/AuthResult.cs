using System.Collections.Generic;

namespace AdOut.Identity.Model.Model.Managers
{
    public class AuthResult
    {
        public bool IsSuccessed 
        {
            get
            {
                return Errors.Count != 0;
            }
        }

        public List<string> Errors { get; set; }

        public RegistrationResult()
        {
            Errors = new List<string>();
        }
    }
}
