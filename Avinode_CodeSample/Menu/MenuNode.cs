/*
 * Author: Brent Kuzmanich
 * Comment: A class representation of a menu item.
 */

using System.Collections.Generic;

namespace Avinode_CodeSample.Menu
{ 
    /// <summary>
    /// A class representation of a menu item.
    /// </summary>
    public class MenuNode
    {
        public MenuNode()
        {
            SubMenu = new List<MenuNode>();
        }
        public MenuNode(string name, string path, bool active)
        {
            Name = name;
            Path = path;
            Active = active;
            SubMenu = new List<MenuNode>();
        }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public bool Active { get; set; }
        public List<MenuNode> SubMenu { get; set; }
    }
}
