using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace MPORT
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            lblNome.Text = "George Rodrigues";
            lblMatricula.Text = "25177";
            lblTelefone.Text = "(85) 999448106";
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd,int wmsg, int wparam, int lparam);

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if(menuVertical.Width == 250)
            {
                menuVertical.Width = 70;
            }
            else
            {
                menuVertical.Width = 250;
            }
        }

        private void IconFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IconMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                Image img = Image.FromFile("D:/visual_studio/MPORT/MPORT/Resources/icon restaurar.png");
                iconMax.Image = img;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                Image img = Image.FromFile("D:/visual_studio/MPORT/MPORT/Resources/icon maximizar.png");
                iconMax.Image = img;
            }
        }

        private void IconMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112,0xf012,0);
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(245, 133, 36), Color.FromArgb(249, 43, 127), 65f);
            graphics.FillRectangle(b, gradient_rectangle);
        }

    }
}
