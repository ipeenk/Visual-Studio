using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace perpustakaan
{
    class koneksidatabase
    {
        string database = ("server=localhost;uid=root;database=perpustakaan;pwd='';");
        string sql = "select from user";
        public MySqlConnection koneksi;

        public MySqlCommand cmd;
        public MySqlDataAdapter adp;

        public void konek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Open();
        }

        public void diskonek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Close();
        }



        public DataTable tampil()
        {
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }

        public void QUERY(string query)
        {
            try
            {
                konek();
                cmd = new MySqlCommand(query, koneksi);
                cmd.ExecuteNonQuery();
            }
            catch(Exception mars)
            {
                MessageBox.Show(mars.Message);
            }
            finally
            {
                diskonek();
            }
           }
        }
    }

