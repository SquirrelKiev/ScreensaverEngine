using System.Reflection;

namespace ScreensaverEngine
{
    internal class DisplayableAssembly
    {
        internal Assembly Assembly { get; private set; }

        internal DisplayableAssembly(Assembly assembly)
        {
            Assembly = assembly;
        }

        public override string ToString()
        {
            var attribute = Assembly.GetCustomAttribute<ModuleInfoAttribute>();
            return $"{attribute.ModuleName} by {attribute.ModuleAuthor}";
        }
    }
}
