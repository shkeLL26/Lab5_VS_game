using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            trackBarMusicVolume.Minimum = 0;
            trackBarMusicVolume.Maximum = 100;
            trackBarMusicVolume.Value = SoundHandler.GetSoundTrackVolume();
        }

        private void trackBarMusicVolume_Scroll(object sender, EventArgs e)
        {
            SoundHandler.SetSoundTrackVolume((float)trackBarMusicVolume.Value / 100);
        }
    }
}
