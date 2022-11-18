using System;
using System.Windows.Forms;

namespace ScreensaverEngine.FlyingToasters
{
    public partial class ToasterConfigForm : Form
    {
        private ToasterConfig config;

        public ToasterConfigForm()
        {
            InitializeComponent();

            LoadToasterConfig();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (SaveToasterConfig())
                Close();
        }

        private bool SaveToasterConfig()
        {
            config.NumToasters = (int)numToasters.Value;

            config.LightlyToastedToast = LTTCheckbox.Checked;
            config.WellToastedToast = WTTCheckbox.Checked;
            config.VeryWellToastedToast = VWTTCheckbox.Checked;
            config.BurntToast = BTCheckbox.Checked;
            config.Toaster = FTCheckbox.Checked;

            config.MinSpeed = (int)minimumSpeed.Value;
            config.MaxSpeed = (int)maximumSpeed.Value;

            config.Volume = (float)volumeSlider.Value / volumeSlider.Maximum;

            if (config.MinSpeed > config.MaxSpeed)
            {
                MessageBox.Show("Minimum speed cannot be higher than the maximum!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ConfigUtility.SaveConfig(config);

            return true;
        }

        private void LoadToasterConfig()
        {
            config = ConfigUtility.LoadConfig<ToasterConfig>();

            numToasters.Value = config.NumToasters;

            LTTCheckbox.Checked = config.LightlyToastedToast;
            WTTCheckbox.Checked = config.WellToastedToast;
            VWTTCheckbox.Checked = config.VeryWellToastedToast;
            BTCheckbox.Checked = config.BurntToast;
            FTCheckbox.Checked = config.Toaster;

            minimumSpeed.Value = config.MinSpeed;
            maximumSpeed.Value = config.MaxSpeed;
            
            volumeSlider.Value = (int)(config.Volume * volumeSlider.Maximum);
        }
    }
}
