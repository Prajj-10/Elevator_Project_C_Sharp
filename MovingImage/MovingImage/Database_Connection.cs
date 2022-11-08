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

    }
            
    

}

