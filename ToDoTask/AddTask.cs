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
    public partial class AddTask : Form
    {
        public List<categoryAdd> dataListc = new List<categoryAdd>();
        public List<userAdd> dataListu = new List<userAdd>();
        public AddTask()
        {
            InitializeComponent();
            startDateBox.Format = DateTimePickerFormat.Custom;
            startDateBox.CustomFormat = "yyyy-MM-dd ";
            endDateBox.Format = DateTimePickerFormat.Custom;
            endDateBox.CustomFormat = "yyyy-MM-dd";
        }

        private void AddTask_Load(object sender, EventArgs e)
        {
            
            fill_box();
        }
        private void fill_box() 
        {
            var selectu = "SELECT id_user as iduser, username as nameuser FROM users";
            var selectc = "SELECT id_category as 'idcategory', category_name as 'name' FROM category";
            excentions.openToDataBase();
            SqlDataAdapter sdac = new SqlDataAdapter(selectc, excentions.conn);
            SqlDataAdapter sdau = new SqlDataAdapter(selectu, excentions.conn);
            DataTable dtc = new DataTable();
            DataTable dtu = new DataTable();
            sdac.Fill(dtc);
            sdau.Fill(dtu);
            for (int i = 0; i < dtc.Rows.Count; i++)
            {
                categoryAdd dataObjc = new categoryAdd();
                dataObjc.categoryName = dtc.Rows[i]["name"].ToString();
                dataObjc.idCategoryAdd = (int)dtc.Rows[i]["idcategory"];
                categoryBox.Items.Add(dataObjc);
                dataListc.Add(dataObjc);
            }
            for (int i = 0; i < dtu.Rows.Count; i++)
            {
                userAdd dataObju = new userAdd();
                dataObju.nameUser = dtu.Rows[i]["nameuser"].ToString();
                dataObju.idUser = (int)dtu.Rows[i]["iduser"];
                userBox.Items.Add(dataObju);
                dataListu.Add(dataObju);
            }
            //MessageBox.Show(startDateBox.Value.Date.ToString());
        }
        private void addRowDB() 
        {
            startDateBox.Format = DateTimePickerFormat.Custom;
            startDateBox.CustomFormat = "yyyy-MM-dd ";
            endDateBox.Format = DateTimePickerFormat.Custom;
            endDateBox.CustomFormat = "yyyy-MM-dd";

            string query = "INSERT INTO tasks (opis,id_kategorii,startDate,endDate,id_status,id_user) " +
                "VALUES ('"+descriptionBox.Text+ "','" + (categoryBox.SelectedItem as categoryAdd).idCategoryAdd + "','" + startDateBox.Value.Date.ToString("yyyy-MM-dd") + "'," +
                "'" + endDateBox.Value.Date.ToString("yyyy-MM-dd") + "','2','"+ (userBox.SelectedItem as userAdd).idUser +"')";
            SqlCommand command = new SqlCommand(query, excentions.conn);
            try
            {
                excentions.openToDataBase();
                command.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                excentions.closeToDataBase();
                this.Hide();
                this.Close();
            }

        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            addRowDB();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show((userBox.SelectedItem as userAdd).idUser.ToString());
        }

        private void startDateBox_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
