using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Member_Sedulur_Team_v2
{
    public partial class MenuUtama : MetroFramework.Forms.MetroForm
    {
        string database = ("server = localhost; database = member; uid = root; pwd = ''; convert zero datetime = true ");
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public MySqlDataReader read;
        public MenuUtama()
        {
            InitializeComponent();
        }

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

        public void Query(string query)
        {
            koneksi = new MySqlConnection(database);
            try
            {
                koneksi.Open();
                cmd = new MySqlCommand(query, koneksi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception irfan)
            {
                MessageBox.Show(irfan.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }

        public DataTable barang()
        {
            string sql = "select nama, jekel, alamat, hp, email from user";
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                metroGrid1.DataSource = dt;
            }
            catch (Exception ricky)
            {
                MessageBox.Show(ricky.Message);
            }
            diskonek();
            return dt;
        }
        
        private void metroContextMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            ctxMenu.Show(metroLink1, 0, metroLink1.Height);
        }


        private void MenuUtama_Load(object sender, EventArgs e)
        {
            barang();
        }

        private void contoh1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transaksi tran = new transaksi();
            this.Hide();
            tran.Show();
        }

        private void contoh2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Apakah anda ingin keluar?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
