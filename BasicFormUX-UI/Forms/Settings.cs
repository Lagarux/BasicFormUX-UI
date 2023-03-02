using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFormUX_UI.Forms
{
    public partial class Settings : Form
    {
        public Settings()
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
            menuStrip1.BackColor= ThemeColor.PrimaryColor;
            gti1.BackColor= ThemeColor.SecondaryColor;
            gti2.BackColor= ThemeColor.SecondaryColor;
            gti3.BackColor= ThemeColor.SecondaryColor;
            gti4.BackColor= ThemeColor.SecondaryColor;
            gti5.BackColor= ThemeColor.SecondaryColor;
        }
    

    private void Settings_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
