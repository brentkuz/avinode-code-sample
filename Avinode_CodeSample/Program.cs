/*
 * Author: Brent Kuzmanich
 * Comment: Main entry point into app.
 */

using Avinode_CodeSample.Processing;
using Avinode_CodeSample.Utility;
using System;
using Unity;

namespace Avinode_CodeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 2)
            {
                Console.WriteLine("This program requires 2 arguments: Arg1 = path to xml menu; Arg2 = active path to match;");
                Console.WriteLine("Arg 1: path to menu; Arg 2: match path");
                return;
            }

            //Bootstrap Unity and get container
            var unityContainer = new UnityContainerFactory().GetContainer();

            try
            {
                //start processing
                IMenuProcessor processor = unityContainer.Resolve<IMenuProcessor>();
                processor.Process(args[0], args[1]);
               
            }
            catch(Exception ex)
            {
                ex.LogToConsole("Sorry, an error occurred");
            }

            
        }
    }
}
