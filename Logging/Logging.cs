using System;
namespace Villa_Api.Logging
{
    public class Logging: ILogging
    {
        public void Log(string msg, string type)
        {
            if(type == "error")
            {
                Console.WriteLine("Error " + msg);
            }
            else
            {
                Console.WriteLine("Log " + msg);
            }
        }
    }
}

