using System;
using System.Reflection;
using System.Windows.Forms;

namespace ScreensaverEngine.Config
{
    internal partial class ConfigForm : Form
    {
        private EngineConfig config;

        internal ConfigForm(Assembly[] assemblies, EngineConfig config)
        {
            InitializeComponent();

            this.config = config;

            ScreensaverList.BeginUpdate();
            {
                int matchingAssembly = 0;

                ScreensaverList.Items.Clear();
                for (int i = 0; i < assemblies.Length; i++)
                {
                    ScreensaverList.Items.Add(new DisplayableAssembly(assemblies[i]));
                    if(assemblies[i].FullName == config.AssemblyToLoad)
                    {
                        matchingAssembly = i;
                    }
                }

                ScreensaverList.SetSelected(matchingAssembly, true);
            }
            ScreensaverList.EndUpdate();
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            SaveEngineConfig();
            Close();
        }

        private void ConfigButton_Click(object sender, System.EventArgs e)
        {
            var moduleInfo = ((DisplayableAssembly)ScreensaverList.SelectedItem).Assembly.GetCustomAttribute<ModuleInfoAttribute>();
            if (moduleInfo.ConfigForm != null && moduleInfo.ConfigForm.IsSubclassOf(typeof(Form)))
            {
                var moduleConfigForm = (Form)Activator.CreateInstance(moduleInfo.ConfigForm);
                moduleConfigForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No valid config form found for this module.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveEngineConfig()
        {
            var assemblyName = ((DisplayableAssembly)ScreensaverList.SelectedItem).Assembly.FullName;

            config.AssemblyToLoad = assemblyName;

            ConfigUtility.SaveConfig(config);
        }
    }
}
