/*
 * Author: Brent Kuzmanich
 * Comment: Interface and class for bootstrapping Unity.
 */

using Avinode_CodeSample.Processing;
using Unity;

namespace Avinode_CodeSample.Utility
{
    /// <summary>
    /// Defines methods for bootstrapping Unit.
    /// </summary>
    public interface IUnityContainerFactory
    {
        /// <summary>
        /// Defines a method for getting a Unit container.
        /// </summary>
        /// <returns>Unity container.</returns>
        IUnityContainer GetContainer();
    }

    /// <summary>
    /// Class for bootstrapping Unity.
    /// </summary>
    public class UnityContainerFactory : IUnityContainerFactory
    {
        /// <summary>
        /// Method for getting a registered and configured Unity container.
        /// </summary>
        /// <returns>Unit container.</returns>
        public IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            Register(container);
            return container;
        }

        //Register all dependencies here.
        private void Register(IUnityContainer container)
        {
            //classes
            container.RegisterType<IMenuParser, MenuParser>();
            container.RegisterType<IMenuDisplay, ConsoleDisplay>();
            container.RegisterType<IMenuProcessor, MenuProcessor>();
        }
    }
}
