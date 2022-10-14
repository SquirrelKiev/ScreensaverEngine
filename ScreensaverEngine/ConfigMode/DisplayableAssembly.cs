using System.Reflection;

namespace ScreensaverEngine
{
    internal class DisplayableAssembly
    {
        internal Assembly Assembly { get; }

        internal DisplayableAssembly(Assembly assembly)
        {
            Assembly = assembly;
        }

        public override string ToString()
        {
            var attribute = Assembly.GetCustomAttribute<ModuleInfoAttribute>();
            return attribute != null ? $"{attribute.ModuleName} by {attribute.ModuleAuthor}" : $"{Assembly.GetName().Name}";
        }
    }
}
