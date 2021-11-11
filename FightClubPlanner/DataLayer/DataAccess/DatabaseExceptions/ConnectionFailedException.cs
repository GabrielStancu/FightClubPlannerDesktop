using System;

namespace DataLayer.DataAccess.DatabaseExceptions
{
    public class ConnectionFailedException : Exception
    {
        public ConnectionFailedException() : base ("The connection to the database could not be established.") { }
    }
}
