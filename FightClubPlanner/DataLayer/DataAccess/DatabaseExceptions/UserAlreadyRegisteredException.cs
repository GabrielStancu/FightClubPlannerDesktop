using System;

namespace DataLayer.DataAccess.DatabaseExceptions
{
    public class UserAlreadyRegisteredException : Exception
    {
        public UserAlreadyRegisteredException() : base("The user is already registered!") { }
    }
}
