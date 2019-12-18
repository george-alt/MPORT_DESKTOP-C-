using BD.MPORT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MPORT
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader(@"D:\visual_studio\MPORT\MPORT\loginAuto.txt");
            string linha;
            int contW = 0;
            while ((linha = sr.ReadLine()) != null)
            {
                if (contW == 0)
                {
                    txtEmail.Text = linha;
                }
                else
                {
                    txtSenha.Text = linha;
                }
                contW++;
            }
            if(txtEmail.Text.Length > 0)
            {
                cbxConectado.Checked = true;
            }
            sr.Close();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                login01 lg = new login01();
                lg.email = txtEmail.Text;
                lg.senha = txtSenha.Text;

                if (lg.getUserVerificar())
                { 
                    if(cbxConectado.Checked == true)
                    {
                        StreamWriter writer = new StreamWriter(@"D:\visual_studio\MPORT\MPORT\loginAuto.txt", false, Encoding.ASCII);
                        writer.WriteLine(txtEmail.Text);
                        writer.WriteLine(txtSenha.Text);
                        writer.Close();
                    }
                    this.Hide();
                    Home hm = new Home();
                    hm.Show();
                }
                else
                {
                    MessageBox.Show("O endereço de E-mail ou a Senha que você inseriu não é válido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(245, 133, 36), Color.FromArgb(249, 43, 127), 65f);
            graphics.FillRectangle(b, gradient_rectangle);
        }
    }
}
