using System.Reflection;
using System.Windows.Forms;

namespace ScreensaverEngine.Config
{
    public partial class ConfigForm : Form
    {
        DisplayableAssemblyWrapper[] assemblies;

        public ConfigForm(Assembly[] assemblies, Config.EngineConfig config)
        {
            InitializeComponent();

            this.assemblies = new DisplayableAssemblyWrapper[assemblies.Length];

            for (int i = 0; i < assemblies.Length; i++)
            {
                this.assemblies[i] = new DisplayableAssemblyWrapper(assemblies[i]);
            }

            ScreensaverList.BeginUpdate();
            {
                ScreensaverList.Items.Clear();
                ScreensaverList.Items.AddRange(this.assemblies);
            }
            ScreensaverList.EndUpdate();
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            SaveConfig();
            Close();
        }

        private void SaveConfig()
        {
            // TODO
        }
    }
}
