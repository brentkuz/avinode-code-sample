/*
 * Author: Brent Kuzmanich
 * Comment: Interface and class runs a pre-order traversal to display 
 * menu items and their sub items.
 */

using Avinode_CodeSample.Menu;
using System;

namespace Avinode_CodeSample.Processing
{
    /// <summary>
    /// Defines methods for displaying a menu.
    /// </summary>
    public interface IMenuDisplay
    {
        /// <summary>
        /// Defines a method for displaying a menu.
        /// </summary>
        /// <param name="menu">Root node of the menu to display.</param>
        void Display(MenuNode menu);
    }

    /// <summary>
    /// Class for displaying a menu tree in the console.
    /// </summary>
    public class ConsoleDisplay : IMenuDisplay
    {
        private const char tab = '\t';
        private const string active = "ACTIVE";

        /// <summary>
        /// Method for displaying a menu and identifying active paths in the console.
        /// </summary>
        /// <param name="menu">Root node of the menu to display.</param>
        public void Display(MenuNode menu)
        {
            if (menu == null)
                throw new ArgumentNullException("menu");

            //Skip root and start with lvl 1
            foreach (var n in menu.SubMenu)
                Display(n, 0);

        }

        //Preorder traversal to display the menu
        private void Display(MenuNode n, int depth)
        {
            if (n == null)
                return;

            //Add padding for lvl
            var pad = "";
            for (var i = 0; i < depth; i++)
                pad += tab;

            var line = string.Format("{0}{1}, {2} {3}", pad, n.Name, n.Path, n.Active ? active : string.Empty);
            Console.WriteLine(line);

            //Recurse and display sub menus
            foreach (var s in n.SubMenu)
                Display(s, depth + 1);
        }
        
    }
}
