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
    public partial class Form1 : Form
    {
        public Form1()
            
        {
            
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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
                ConnTDB f2 = new ConnTDB();
                this.Hide();
                f2.ShowDialog();
                this.Close();
               
            }
        }
    }
}
