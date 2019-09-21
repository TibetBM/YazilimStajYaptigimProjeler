using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KORDSA_UTP
{
    public partial class LoginForm : Form
    {
        Islem islem;
        AnaForm a;
        public LoginForm()
        {
            InitializeComponent();
            islem = new Islem();
            a = new AnaForm();
            this.Validate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            if (txtkullaniciadi.Text != "" && txtsifre.Text != "" && islem.loginGiris(txtkullaniciadi.Text, txtsifre.Text))
            {
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login İşlemi Başarısız Oldu !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkullaniciadi.BackColor = Color.LightYellow;
                txtsifre.BackColor = Color.LightYellow;
            }
        }

        private void btngiris_MouseHover(object sender, EventArgs e)
        {
            btngiris.BackColor = Color.LightYellow;
            this.Cursor = Cursors.Hand;
        }

        private void btngiris_MouseLeave(object sender, EventArgs e)
        {
            btngiris.BackColor = Color.ForestGreen;
            this.Cursor = Cursors.Default;
        }

        private void btncikis_MouseHover(object sender, EventArgs e)
        {
            btncikis.BackColor = Color.LightYellow;
            this.Cursor = Cursors.Hand;
        }

        private void btncikis_MouseLeave(object sender, EventArgs e)
        {
            btncikis.BackColor = Color.Tomato;
            this.Cursor = Cursors.Default;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtkullaniciadi.Focus();
        }
    }
}
