using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ToDoTask
{
    public partial class userLogin : Form
    {
        
        public userLogin()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //private void btnenter(object sender, KeyEventArgs e) 
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        MessageBox.Show("hel");
        //    }
        //}

        private void loginButton_Click(object sender, EventArgs e)
        {
            
            excentions.openToDataBase();
            var priv = "SELECT privileges FROM users WHERE username='"+username.Text+"'";
            SqlDataAdapter p = new SqlDataAdapter(priv, excentions.conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM users WHERE username='" + username.Text + "' AND password='" + password.Text + "'", excentions.conn);
            DataTable dt = new DataTable();
            DataTable pp = new DataTable();
            p.Fill(pp);
            sda.Fill(dt);
            for (int i = 0; i < pp.Rows.Count; i++)
            {
                excentions.privileges = (int)pp.Rows[0]["privileges"];
            }
            if (dt.Rows[0][0].ToString() == "1") 
            {
                excentions.userNM = username.Text;
                main f4 = new main();
                this.Hide();
                f4.ShowDialog();
                excentions.closeToDataBase();
                this.Close();

            }
            else 
            {
                label3.Text = "Niepoprawna nazwa użytkownika lub hasło.";
                label4.Text = "Spróbuj ponownie.";
            }

        }

        private void userLogin_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
            }
        }
    }
}
