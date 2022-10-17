using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTask
{
    public class task
    {
        //main
        public int number { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string startDate{ get; set; }
        public string endDate { get; set; }
        public string status { get; set; }

        public static string inbox = "SELECT  tasks.id_task as Numer,tasks.opis as Opis, category.category_name as Kategoria, tasks.startDate as 'Data rozpoczęcia', tasks.endDate as 'Data zakończenia', status.nameStatus as Status, users.username FROM tasks " +
                "INNER JOIN category ON category.id_category = tasks.id_kategorii " +
                "INNER JOIN status ON status.id_status = tasks.id_status " +
                "INNER JOIN users ON users.id_user = tasks.id_user " +
                "WHERE users.username='" + excentions.userNM.ToString() + "'" +
                "AND tasks.id_status = 2";

        public static string incoming = "SELECT tasks.id_task as Numer,tasks.opis as Opis, category.category_name as Kategoria, tasks.startDate as 'Data rozpoczęcia', tasks.endDate as 'Data zakończenia', status.nameStatus as Status, users.username FROM tasks " +
                "INNER JOIN category ON category.id_category = tasks.id_kategorii " +
                "INNER JOIN status ON status.id_status = tasks.id_status " +
                "INNER JOIN users ON users.id_user = tasks.id_user " +
                "WHERE users.username='" + excentions.userNM.ToString() + "'" +
                "AND startDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "'" +
                "AND tasks.id_status = 2";

        public static string deadline = "SELECT tasks.id_task as Numer,tasks.opis as Opis, category.category_name as Kategoria, tasks.startDate as 'Data rozpoczęcia', tasks.endDate as 'Data zakończenia', status.nameStatus as Status, users.username FROM tasks " +
                "INNER JOIN category ON category.id_category = tasks.id_kategorii " +
                "INNER JOIN status ON status.id_status = tasks.id_status " +
                "INNER JOIN users ON users.id_user = tasks.id_user " +
                "WHERE users.username='" + excentions.userNM.ToString() + "'" +
                "AND endDate='" + DateTime.Now.ToString("yyyy-MM-dd")+"'" +
                "AND tasks.id_status = 2";
        public static string done = "SELECT  tasks.id_task as Numer,tasks.opis as Opis, category.category_name as Kategoria, tasks.startDate as 'Data rozpoczęcia', tasks.endDate as 'Data zakończenia', status.nameStatus as Status, users.username FROM tasks " +
               "INNER JOIN category ON category.id_category = tasks.id_kategorii " +
               "INNER JOIN status ON status.id_status = tasks.id_status " +
               "INNER JOIN users ON users.id_user = tasks.id_user " +
               "WHERE users.username='" + excentions.userNM.ToString() + "'" +
               "AND tasks.id_status = 1";

    }
    public class categoryAdd
    {
        public int idCategoryAdd { get; set; }
        public string categoryName { get; set; }
        public override string ToString()
        {
            return categoryName;
        }
    }
    public class userAdd 
    {
        public int idUser { get; set; }
        public string nameUser { get; set; }
        public override string ToString()
        {
            return nameUser;
        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
