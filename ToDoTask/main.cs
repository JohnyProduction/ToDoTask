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
    public partial class main : Form
    {

        public List<task> taskList = new List<task>();
        public main()
        {
            InitializeComponent();
        }
       
        private void main_Load(object sender, EventArgs e)
        {
            if (excentions.privileges != 1) 
            {
                buttonAdd.Visible = false;
            }
            else 
            {
                buttonAdd.Visible = true;
            }
            usernameHelloText.Text = excentions.userNM;
            dateHome.Text = DateTime.Now.ToString("dd/MM/yyyy");
            


        }
        private void fillData(string select)
        { 
            
            //MessageBox.Show(select);
            excentions.openToDataBase();
            SqlDataAdapter sda = new SqlDataAdapter(select, excentions.conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                task taskObj = new task();
                taskObj.number = (int)dt.Rows[i]["Numer"];
                taskObj.description = dt.Rows[i]["Opis"].ToString();
                taskObj.category = dt.Rows[i]["Kategoria"].ToString();
                taskObj.startDate = dt.Rows[i]["Data rozpoczęcia"].ToString();
                taskObj.endDate = dt.Rows[i]["Data zakończenia"].ToString();
                taskObj.status = dt.Rows[i]["Status"].ToString();
                taskList.Add(taskObj);
            }
            
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["Opis"].ReadOnly = true;
            dataGridView1.Columns["Kategoria"].ReadOnly = true;
            dataGridView1.Columns["Kategoria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Data rozpoczęcia"].ReadOnly = true;
            dataGridView1.Columns["Data rozpoczęcia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Data zakończenia"].ReadOnly = true;
            dataGridView1.Columns["Data zakończenia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Status"].ReadOnly = true;
            dataGridView1.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Numer"].ReadOnly = true;
            dataGridView1.Columns["Numer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["buttonDone"].ReadOnly = false;
            dataGridView1.Columns["username"].Visible = false;
            buttonDone.Text = "Wykonane";
            excentions.closeToDataBase();
        }
        private void updateData(string id_task) 
        {
            excentions.openToDataBase();

            string query = "UPDATE tasks SET id_status = 1 WHERE id_task ="+id_task;
            SqlCommand command = new SqlCommand(query, excentions.conn);
            try
            {
                excentions.openToDataBase();
                command.ExecuteNonQuery();
                Console.WriteLine("Records Updated Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                excentions.closeToDataBase();
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var dt = dataGridView1.DataSource as DataTable;

                var selRows = dataGridView1.SelectedCells
                    .Cast<DataGridViewCell>()
                    .Where(c => !c.OwningRow.IsNewRow)
                    .Distinct()
                    .Select(c => ((DataRowView)c.OwningRow.DataBoundItem).Row);
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string text = row.Cells[1].Value.ToString();
                updateData(text);
                foreach (var r in selRows)
                {
                    dt.Rows.Remove(r);
                }
                taskList.RemoveAt(e.RowIndex);
                dataGridView1.Update();
                dataGridView1.Refresh();


                // Don't call this if you have a DB to update.
                // dt.AcceptChanges();

            }
            else
            {
                MessageBox.Show("Brak zadań");
            }


        }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fillData(task.inbox);
            dataGridView1.Columns["buttonDone"].Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            fillData(task.inbox);
            dataGridView1.Columns["buttonDone"].Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fillData(task.incoming);
            dataGridView1.Columns["buttonDone"].Visible = true;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            fillData(task.incoming);
            dataGridView1.Columns["buttonDone"].Visible = true;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fillData(task.deadline);
            dataGridView1.Columns["buttonDone"].Visible = true;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            fillData(task.deadline);
            dataGridView1.Columns["buttonDone"].Visible = true;
        }
        private void labelDone_Click(object sender, EventArgs e)
        {
            fillData(task.done);
            dataGridView1.Columns["buttonDone"].Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            fillData(task.done);
            dataGridView1.Columns["buttonDone"].Visible = false;
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void usernameHelloText_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userLogin f3 = new userLogin();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTask f5 = new AddTask();
            f5.ShowDialog();
            
        }

       
    }
}
