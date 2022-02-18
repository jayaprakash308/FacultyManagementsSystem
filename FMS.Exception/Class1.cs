using System;

namespace FMS.Exceptions
{
    public class FacultyExceptions : Exception
    {
        public FacultyExceptions() : base()
        {

        }

        public FacultyExceptions(string message) : base(message)
        {

        }
        public FacultyExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }


    }
}
