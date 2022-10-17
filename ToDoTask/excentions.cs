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
using System.IO;

namespace ToDoTask
{
    internal class excentions
    {
       public static SqlConnection conn;
       public static string userNM;
       public static int privileges;
       public static string currentFilePath = @"C:\ToDoTaks\dataTDT.txt";
       public static string dirFilePath = @"C:\ToDoTaks";
        public static void openToDataBase() 
        {
            
            string[] lines;
            lines = new string[4];
            if (File.Exists(excentions.currentFilePath))
            {
                int i = 0;
                foreach (string line in System.IO.File.ReadLines(excentions.currentFilePath))
                {
                    lines[i] = line;
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Błąd brak pliku konfiguracji", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string connetionString = null;
            
            connetionString = "Data Source=" + lines[0] + ";Initial Catalog=" + lines[1] + ";User ID=" + lines[2] + ";Password=" + lines[3];
            conn = new SqlConnection(connetionString);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd połączenia z bazą danych ! ");
            }

        }
        static public void closeToDataBase() 
        {
           
            string[] lines;
            lines = new string[4];
            if (File.Exists(excentions.currentFilePath))
            {
                int i = 0;
                foreach (string line in System.IO.File.ReadLines(excentions.currentFilePath))
                {
                    lines[i] = line;
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Błąd brak pliku konfiguracji", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string connetionString = null;
            SqlConnection conn;
            connetionString = "Data Source=" + lines[0] + ";Initial Catalog=" + lines[1] + ";User ID=" + lines[2] + ";Password=" + lines[3];
            conn = new SqlConnection(connetionString);
            try
            {
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd połączenia z bazą danych ! ");
            }
        }
        
       
          
    }
}
