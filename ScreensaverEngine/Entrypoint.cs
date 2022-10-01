
namespace ScreensaverEngine
{
    internal static class Entrypoint
    {
        internal static void Main()
        {
            using var engine = new Engine();
            engine.Run();
        }
    }
}

