using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace perpustakaan
{
    public partial class pengembalian : Form
    {
        public pengembalian()
        {
            InitializeComponent();
            baca();
        }


        string database = ("server=localhost;uid=root;database=perpustakaan;pwd='';Convert Zero Datetime=True;");

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

        public DataTable baca()
        {

            DataTable dt = new DataTable();
            try
            {
                konek();
                string sql = "select nim,nama,kelas,buku,pengembalian from pinjam where nim = '" + Program.login + "' ";
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    
                    Program.buku = rdr["buku"].ToString();



                }
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            diskonek();
            return dt;
        }
        private void pengembalian_Load(object sender, EventArgs e)
        {
            label5.Text = Program.login;
            label6.Text = Program.nama;
            label7.Text = Program.kelas;
        }
        public void hapus()
        {
            try
            {
                konek();
                string del = "delete from pinjam WHERE buku = '"+ Program.buku+"' ";
                cmd = new MySqlCommand(del, koneksi);
                cmd.ExecuteNonQuery();
                diskonek();
                MessageBox.Show("TERIMA KASIH TELAH MENGEMBALIKAN BUKU SESUAI JADWAL", "INFORMASI", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow baris = this.dataGridView1.Rows[e.RowIndex];
            baris.Cells["nim"].Value.ToString();
             baris.Cells["nama"].Value.ToString();
             baris.Cells["kelas"].Value.ToString();
             baris.Cells["buku"].Value.ToString();
             baris.Cells["pengembalian"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            app b = new app();
            b.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hapus();
            baca();
        }
    }
}
