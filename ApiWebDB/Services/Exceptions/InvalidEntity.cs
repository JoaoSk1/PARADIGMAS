using System;

namespace ApiWebDB.Services.Exceptions
{
    public class InvalidEntity : Exception
    {
        public InvalidEntity(string message) : base(message) 
        {

        }
        
    }
}
