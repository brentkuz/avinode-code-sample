/*
 * Author: Brent Kuzmanich
 * Comment: Static class for logging exceptions.
 */

using System;

namespace Avinode_CodeSample.Utility
{
    public static class Logger
    {
        /// <summary>
        /// Extension method to log an exception to the console.
        /// </summary>
        public static void LogToConsole(this Exception ex, string message = null)
        {
            if (message != null)
                Console.WriteLine(message); 
            
            Console.WriteLine(ex.Message);

            if (ex.InnerException != null)
                Console.WriteLine(ex.InnerException.Message);
        }

    }
}
