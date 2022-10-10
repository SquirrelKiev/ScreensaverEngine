using System;

namespace ScreensaverEngine
{
    public static class Debug
    {
        public static void Log(object info)
        {
            InternalLog("[INFO]", ConsoleColor.Green, info);
        }

        public static void LogWarning(object info)
        {
            InternalLog("[WARN]", ConsoleColor.Yellow, info);
        }

        public static void LogError(object info)
        {
            InternalLog("[ERROR]", ConsoleColor.Red, info);
        }

        private static void InternalLog(string prefix, ConsoleColor textColor, object info)
        {
#if DEBUG
            if (info == null) info = "null";

            Console.ForegroundColor = textColor;
            Console.WriteLine($"{prefix} {info}");
            Console.ForegroundColor = ConsoleColor.White;
#endif
        }
    }
}
