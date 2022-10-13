using System.Reflection;
using System.Windows.Forms;

namespace ScreensaverEngine.Config
{
    public partial class ConfigForm : Form
    {
        Assembly[] assemblies;

        public ConfigForm(Assembly[] assemblies, EngineConfig config)
        {
            InitializeComponent();

            this.assemblies = assemblies;

            ScreensaverList.BeginUpdate();
            {
                ScreensaverList.Items.Clear();
                ScreensaverList.Items.AddRange(this.assemblies);
            }
            ScreensaverList.EndUpdate();
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            SaveEngineConfig();
            Close();
        }

        private void SaveEngineConfig()
        {
            // TODO
        }

        private void ConfigButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
