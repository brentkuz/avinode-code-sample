/*
 * Author: Brent Kuzmanich
 * Comment: Facade interface and class for processing menus.
 */

using System;
using System.IO;
using System.Xml;

namespace Avinode_CodeSample.Processing
{
    /// <summary>
    /// Defines methods for processing an XML menu. 
    /// </summary>
    public interface IMenuProcessor
    {
        /// <summary>
        /// Defines a method for processing an XML menu.
        /// </summary>
        /// <param name="menuPath">Path to XML menu file.</param>
        /// <param name="matchPath">Active path to match.</param>
        void Process(string menuPath, string matchPath);
    }

    /// <summary>
    /// Class for processing an XML menu.
    /// </summary>
    public class MenuProcessor : IMenuProcessor
    {
        private IMenuParser parser;
        private IMenuDisplay display;

        public MenuProcessor(IMenuParser parser, IMenuDisplay display)
        {
            this.parser = parser;
            this.display = display;           
        }

        /// <summary>
        /// Method for parsing and displaying an XML menu document.
        /// </summary>
        /// <param name="menuPath">Path to XML menu file.</param>
        /// <param name="matchPath">Active path to match.</param>
        public void Process(string menuPath, string matchPath)
        {
            if (!File.Exists(menuPath))
                throw new FileNotFoundException("MenuProcessor: The menu could not be located.");

            //Load xml doc into memory
            var xml = new XmlDocument();
            xml.Load(menuPath);
        
            //Parse and build menu
            var menu = parser.Parse(xml, matchPath);
       
            if (menu == null)
                throw new Exception("MenuProcessor: Failed to parse menu.");

            //Display parsed menu
            display.Display(menu);
        }
    }
}
