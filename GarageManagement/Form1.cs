using GarageManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagement
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            try
            {
                using (GarageManagementEntities db = new GarageManagementEntities())
                {
                    var query = from n in db.Admins where n.emailAdmin == email && n.password == pass select n;
                    if (query.SingleOrDefault() != null)
                    {
                        MessageBox.Show("Login successfull !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form2 a = new Form2();
                        a.Show();
                    }
                    else
                    {
                        MessageBox.Show("Your email or password is incorrect.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//Enter key
                txtPassword.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btLogin.PerformClick();
        }
    }
}
