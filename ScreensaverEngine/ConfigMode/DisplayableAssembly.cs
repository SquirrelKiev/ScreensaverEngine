using System.Reflection;

namespace ScreensaverEngine.Config
{
    internal class DisplayableAssemblyWrapper
    {
        internal readonly Assembly assembly;

        internal DisplayableAssemblyWrapper(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public override string ToString()
        {
            return assembly.GetName().Name;
        }
    }
}
