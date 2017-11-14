/*
 * Author: Brent Kuzmanich
 * Comment: Interface and class used to run a depth-first search on a menu represented 
 * by an xml document and determine which menu items are active.
 */

using Avinode_CodeSample.Menu;
using System;
using System.Xml;

namespace Avinode_CodeSample.Processing
{
    /// <summary>
    /// Defines methods to parse an xml menu document.
    /// </summary>
    public interface IMenuParser
    {
        /// <summary>
        /// Defines a method for parsing an Xml menu
        /// </summary>
        /// <param name="xmlMenu">Menu xml document</param>
        /// <param name="matchPath">Path to match in xml document</param>
        /// <returns>Root of the menu built from the xml document</returns>
        MenuNode Parse(XmlDocument xmlMenu, string matchPath);
    }

    /// <summary>
    /// Class used to parse an Xml menu document.
    /// </summary>
    public class MenuParser : IMenuParser
    {
        /// <summary>
        /// Method for parsing an Xml menu document and building a tree of MenuNodes.
        /// <param name="xmlMenu">Menu xml document</param>
        /// <param name="matchPath">Path to match in xml document</param>
        /// <returns>Root of the menu built from the xml document</returns>
        public MenuNode Parse(XmlDocument xmlMenu, string matchPath)
        {
            if (xmlMenu == null || matchPath == null)
                throw new ArgumentNullException("MenuParser: Parse method requires 2 arguments.");
           
            return DFS(xmlMenu.FirstChild, new MenuNode("root", "", false), matchPath);
        }

        //Depth first search that simultaneously builds and returns a tree
        private MenuNode DFS(XmlNode x, MenuNode n, string match)
        {
            if (n == null)
                return null;
            
            MenuNode node = null;
           
            if (x.Name == "item") //If menu item found, create new node 
            {
                var nameNode = x.SelectSingleNode("displayName");               
                var pathNode = x.SelectSingleNode("path");

                //Check that this item is not malformed
                if (nameNode == null || pathNode == null)
                    throw new NullReferenceException("MenuParser: Malformed menu item. Please check the menu for correctness.");

                var name = nameNode.InnerText;
                var path = pathNode.Attributes["value"].Value;
                node = new MenuNode(name, path, path == match);

                //If sub menu exists, recurse sub menu items
                var sub = x.SelectSingleNode("subMenu");
                if (sub != null)
                {
                    foreach (XmlNode c in sub.ChildNodes)
                    {
                        if (c.Name == "item")
                        {
                            var res = DFS(c, node, match);
                            node.Active = node.Active || res.Active;
                            node.SubMenu.Add(res);
                        }
                    }
                }
                else
                    return node;
            }
            else 
            {
                foreach (XmlNode c in x.ChildNodes)
                {
                    //Only go deeper if item is encountered
                    if (c.Name == "item")
                    {
                        var res = DFS(c, n, match);
                        n.Active = n.Active || res.Active;
                        n.SubMenu.Add(res);
                    }
                }
            }

            return node ?? n;
        }

     
    }
}
