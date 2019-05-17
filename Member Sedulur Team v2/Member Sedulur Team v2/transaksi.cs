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
    public partial class transaksi : MetroFramework.Forms.MetroForm
    {
        string database = ("server = localhost; database = member; uid = root; pwd = ''; convert zero datetime = true ");
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public MySqlDataReader read;
        public transaksi()
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

        private void metroComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.Text == "TOPI")
            {
                metroTextBox1.Text = "15000";
            }
            else if (metroComboBox1.Text == "KAOS")
            {
                metroTextBox1.Text = "30000";
            }
            else if (metroComboBox1.Text == "STICKER")
            {
                metroTextBox1.Text = "10000";
            }
        }

       
        

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void transaksi_Load(object sender, EventArgs e)
        {
            barang();
        }


        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(metroTextBox1.Text) && !string.IsNullOrEmpty(metroTextBox2.Text))
                metroTextBox3.Text = (Convert.ToInt32(metroTextBox1.Text) * Convert.ToInt32(metroTextBox2.Text)).ToString();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Query("DELETE FROM transaksi");
            MessageBox.Show("Data Berhasil di Reset");
            barang();
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
            metroTextBox3.Text = "";
        }

        public DataTable barang()
        {
            string sql = "select * from transaksi";
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Query("insert into transaksi (jenis_barang, harga, jumlah, total_harga) values('" + metroComboBox1.Text + "','" + metroTextBox1.Text + "','" + metroTextBox2.Text + "','" + metroTextBox3.Text + "')");
            MessageBox.Show("Input data berhasil");
            barang();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuUtama mu = new MenuUtama();
            this.Hide();
            mu.Show();
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            ctxMenu.Show(metroLink1, 0, metroLink1.Height);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings.DefaultPageSettings.Landscape = false;
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var font = new Font("Sitka Display", 14);

            e.Graphics.DrawString("\t\t INVOICE PEMBELIAN MERCHANDISE SEDULUR TEAM \n\n\n", font, Brushes.Black, 25, 20);
            e.Graphics.DrawString("Jenis Barang \t: " + metroComboBox1.Text + "\n\n", font, Brushes.Black, 140, 50);
            e.Graphics.DrawString("Harga \t\t: " + metroTextBox1.Text + "\n\n", font, Brushes.Black, 140, 75);
            e.Graphics.DrawString("Jumlah Pembelian \t: " + metroTextBox2.Text + "\n\n", font, Brushes.Black, 140, 100);
            e.Graphics.DrawString("Total Harga \t: " + metroTextBox3.Text + "\n\n", font, Brushes.Black, 140, 125);
        }
    }
}
