
namespace ScreensaverEngine
{
    internal static class Entrypoint
    {
        internal static void Main()
        {
            using var game = new Engine();
            game.Run();
        }
    }
}

