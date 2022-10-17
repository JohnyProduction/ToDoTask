using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ToDoTask
{
    public partial class ConnTDB : Form
    {
        
        public ConnTDB()
        {
            InitializeComponent();
        }

        private void ConnTDB_Load(object sender, EventArgs e)
        {
            
        }

        private void DBaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(excentions.dirFilePath);
            string[] lines =
            {
                DBaddress.Text,DBname.Text,username.Text,password.Text
            };
            File.WriteAllLines(excentions.currentFilePath, lines);
            if (File.Exists(excentions.currentFilePath))
            {
                Console.WriteLine($"Directory {excentions.currentFilePath} exists!");
                userLogin f3 = new userLogin();
                this.Hide();
                f3.ShowDialog();
                this.Close();

            }
            else
            {
                Console.WriteLine($"Directory {excentions.currentFilePath} does not exist!");
            }


        }

        private void DBname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
