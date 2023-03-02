using BasicFormUX_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFormUX_UI
{
    public partial class FormMainMenu : Form
    {
        //Fields
        private Button currentButton;
        private Random rnd;
        private int tempIndex;
        private Form activeForm;
        public FormMainMenu()
        {
            InitializeComponent();
            rnd=new Random();
            btnCLoseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void RelaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index=rnd.Next(0,ThemeColor.ColorList.Count);
            while(tempIndex==index)
            {
                index=rnd.Next(0,ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object sender, EventArgs e)
        {
            if (sender != null) { 
                if(currentButton!=(Button)sender)
                {
                    DisableButton();
                    Color clr=SelectThemeColor();
                    currentButton=(Button)sender;
                    currentButton.BackColor = clr;    
                    currentButton.ForeColor = Color.White;
                    currentButton.Font= new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    panelTitleBar.BackColor= clr;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(clr,-0.3);
                    ThemeColor.PrimaryColor=clr;
                    ThemeColor.SecondaryColor= ThemeColor.ChangeColorBrightness(clr, -0.3);
                    btnCLoseChildForm.Visible = true;
                }
            }
        }

        private void OpenChildForm(Form childForm,object btnSender)
        {
            if(activeForm!=null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender, null);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle= FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag= childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if(previousBtn.GetType()==typeof(Button))
                {
                    previousBtn.BackColor = Color.Gray;
                    previousBtn.ForeColor=Color.White;
                    previousBtn.Font= new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                }
            }
        }

        private void Process(object sender,EventArgs e)
        {
            //ActivateButton(sender, e);
            Button btn=(Button)sender;
            switch(btn.Text) {
                case " Products":OpenChildForm(new Forms.Product(),sender); break;
                case " Notifications":OpenChildForm(new Forms.Notifications(),sender); break;
                case " Orders":OpenChildForm(new Forms.Orders(),sender); break;
                case " Reporting":OpenChildForm(new Forms.Reporting(),sender); break;
                case " Customer":OpenChildForm(new Forms.Customer(),sender); break;
                case " Settings":OpenChildForm(new Forms.Settings(),sender); break;
            }
        }

        private void btnCLoseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Home";
            panelTitleBar.BackColor = Color.Teal;
            panelLogo.BackColor = Color.Gray;
            btnCLoseChildForm.Visible = false;

        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            RelaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFullSize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
