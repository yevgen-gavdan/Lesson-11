using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMediaLibrary.Player
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        private List<string> playlist;

        public void PlayAudio(List<string> playlist)
        {
            this.playlist = playlist;
            axPlayer.Ctlcontrols.stop();
            axPlayer.URL = this.playlist[0];
            axPlayer.Ctlcontrols.play();
        }
    }
}
