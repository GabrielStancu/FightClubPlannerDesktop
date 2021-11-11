using System;

namespace DataLayer.DataAccess.DatabaseExceptions
{
    public class UserNotRegisteredException : Exception
    {
        public UserNotRegisteredException(): base("The username or password provided is not correct.") { }
    }
}
