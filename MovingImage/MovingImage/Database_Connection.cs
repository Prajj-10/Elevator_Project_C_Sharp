using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingImage
{
    internal class Database_Connection
    {
        
        private  NpgsqlConnection conn;
        private string? sql;
        private NpgsqlCommand? cmd;
        private DataTable? dt;

        public string connstring = string.Format("Server={0}; Port={1};" +
            "User Id={2}; Password={3}; Database={4};",
            "localhost", 5432, "postgres", "12345", "elevator_log_db");

        // Button_Functions btnF = new Button_Functions();

        
        

        

        public void Select(DataGridView dgvLogData)
        {
            
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"select * from log_select();";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dgvLogData.DataSource = null; // reset datagridview
                dgvLogData.DataSource = dt;

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        public void Delete_Logs()
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"TRUNCATE log_details restart identity;";

                cmd = new NpgsqlCommand(sql, conn);

                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error : " + ex.Message);

            }
        }

        public void InsertData(object sender, EventArgs e)
        {
            try
            {
                

                // string button = btnF.ButtonClicked((Button)sender, e);
                string button = form1.returnButton(sender, e);
                string action = form1.returnButtonAction(sender, e);
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = String.Format("select * from log_insert('{0}', '{1}', '{2}', '{3}');", button, DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.ToString("h:mm:ss tt"), action);
                // MessageBox.Show(sql);

                // sql = @"select * from log_insert('_button', '_date', '_time', '_action');";
                cmd = new NpgsqlCommand(sql, conn);
                /*cmd.Parameters.AddWithValue("_button", button);
                cmd.Parameters.AddWithValue("_date", DateTime.Now.ToString("mm/dd/yyyy"));
                cmd.Parameters.AddWithValue("_time", DateTime.Now.ToString("h:mm:ss tt"));
                cmd.Parameters.AddWithValue("_action", action);*/
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error : " + ex.Message);

            }
        }






    }
            
    

}

