using System;

namespace AdOut.Identity.Model.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message) : base(message)
        {

        }
    }
}
