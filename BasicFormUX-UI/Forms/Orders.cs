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
    public partial class Orders : Form
    {
        public Orders()
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
            groupBox1.ForeColor = ThemeColor.PrimaryColor;
            radioButton1.ForeColor = ThemeColor.SecondaryColor;
            radioButton2.ForeColor = ThemeColor.SecondaryColor;
            radioButton3.ForeColor = ThemeColor.SecondaryColor;
            radioButton4.ForeColor = ThemeColor.SecondaryColor;

        }

        private void Orders_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}

