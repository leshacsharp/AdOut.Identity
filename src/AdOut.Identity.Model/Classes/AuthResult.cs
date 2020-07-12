using System.Collections.Generic;

namespace AdOut.Identity.Model.Classes
{
    public class AuthResult
    {
        public bool IsSuccessed 
        {
            get
            {
                return Errors.Count == 0;
            }
        }

        public List<string> Errors { get; set; }

        public AuthResult()
        {
            Errors = new List<string>();
        }
    }
}
