
namespace ScreensaverEngine
{
    internal static class Entrypoint
    {
        internal static int Main(string[] args)
        {
            using var engine = new Engine();
            engine.Run();

            return 0;
        }
    }
}

