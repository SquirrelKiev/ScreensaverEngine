using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ScreensaverEngine.Config;

namespace ScreensaverEngine
{
    internal static class Entrypoint
    {
        // https://sites.harding.edu/fmccown/screensaver/screensaver.html
        // https://web.archive.org/web/20101022220937/http://doktormadsen.dk/wp/xna-screensaver-kit/
        internal static int Main(string[] args)
        {
            var config = EngineConfig.LoadConfig();
            var assemblies = ReflectionUtility.LoadAssembliesInDirectory(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Screensavers"));
            var userSelectedAssembly = assemblies.FirstOrDefault(assembly => { return assembly.FullName == config.AssemblyToLoad; });
            
            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                // Handle cases where arguments are separated by colon.
                // Examples: /c:1234567 or /P:1234567
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument[3..].Trim();
                    firstArgument = firstArgument[..2];
                }
                else if (args.Length > 1)
                {
                    secondArgument = args[1];
                }

                if (userSelectedAssembly == null)
                {
                    Debug.LogError("No screensaver set to use in config!");

                    return 1;
                }

                // Configuration mode
                if (firstArgument == "/c")
                {
                    if (secondArgument == null)
                    {
                        Debug.LogError("No window handle provided.");

                        return 2;
                    }

                    ConfigMode(assemblies, config, secondArgument);

                    return 0;
                }
                // Preview mode
                else if (firstArgument == "/p")
                {
                    if (secondArgument == null)
                    {
                        Debug.LogError("No window handle provided.");

                        return 2;
                    }

                    IntPtr previewWndHandle = new IntPtr(long.Parse(secondArgument));

                    using var engine = new Engine(userSelectedAssembly, config, previewWndHandle);
                    engine.Run();

                    return 0;
                }
                // Screensaver mode
                else if (firstArgument == "/s")
                {
                    ScreensaverMode(userSelectedAssembly, config);

                    return 0;
                }
                // Undefined argument
                else
                {
                    Debug.LogError("Not a valid argument.");

                    return 3;
                }
            }
            else // Also config mode for some reason (thank you windows very cool)
            {
                ConfigMode(assemblies, config);

                return 0;
            }
        }

        private static void ConfigMode(Assembly[] assemblies, EngineConfig config, string secondArgument)
        {
            IntPtr configCtrlHandle = new IntPtr(long.Parse(secondArgument));
            IntPtr configWndHandle = NativeMethods.GetParent(configCtrlHandle);

            ConfigMode(assemblies, config, configWndHandle);
        }

        private static void ConfigMode(Assembly[] assemblies, EngineConfig config, IntPtr? configWndHandle = null)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            var screensaverConfig = new ConfigForm(assemblies, config);

            if(configWndHandle != null)
            {
                screensaverConfig.ShowDialog(new WindowWrapper(configWndHandle.Value));
            }
            else
            {
                Application.Run(screensaverConfig);
            }
        }

        private static void ScreensaverMode(Assembly assembly, EngineConfig config)
        {
            using var engine = new Engine(assembly, config);
            engine.Run();
        }
    }
}

