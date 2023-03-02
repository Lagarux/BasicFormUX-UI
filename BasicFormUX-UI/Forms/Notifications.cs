using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFormUX_UI.Forms
{
    public partial class Notifications : Form
    {
        public Notifications()
        {
            InitializeComponent();
        }
        
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
            label4.ForeColor = ThemeColor.SecondaryColor;
        }

        private void Notifications_Load(object sender, EventArgs e)
        {
            LoadTheme();
            btnAddList.Left += 105;
            btnAddList.Width += 30;
            btnAddList.Cursor = Cursors.Hand;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

            //axWindowsMediaPlayer1.URL = "C:\\\\Users\\\\ttt-g\\\\Music\\\\Tripkolik_gozleri_varya.mp3";
            
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            ofdSong.ShowDialog();
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myPlayList");
            WMPLib.IWMPMedia media;
            if(ofdSong.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in ofdSong.FileNames)
                {
                    media=axWindowsMediaPlayer1.newMedia(file);
                    playlist.appendItem(media);
                }
            }
            axWindowsMediaPlayer1.currentPlaylist= playlist;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            
        }
    }

}
