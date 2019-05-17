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

namespace buku
{
    public partial class Form1 : Form
    {
        string database = "server = localhost; database=perpus; uid=root;Convert Zero Datetime=True";
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public Form1()
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

        public DataTable baca()
        {
            string sql = "select * from buku";
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            diskonek();
            return dt;
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

        public void ubah()
        {
            try
            {
                koneksi = new MySqlConnection(database);
                koneksi.Open();
                string update = "UPDATE buku SET tgl ='" + dateTimePicker1.Text + "',nama_buku ='" + textBox1.Text + ",nama_penulis ='" + textBox2.Text + "',nama_penerbit='" + textBox3.Text;
                cmd = new MySqlCommand(update, koneksi);
                koneksi.Close();
                MessageBox.Show("Update Sukses", "informasi", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void hapus()
        {
            string sql = "delete from buku where tgl='" + this.dateTimePicker1.Text + "'";
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }

        }
        private void btnView_Click(object sender, EventArgs e)
        {
            baca();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Query("insert into buku values('" + this.dateTimePicker1.Text + "','" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "')");
            MessageBox.Show("Insert data berhasil");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ubah();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow br = this.dataGridView1.Rows[e.RowIndex];

            dateTimePicker1.Text = br.Cells["tgl"].Value.ToString();
            textBox1.Text = br.Cells["nama_buku"].Value.ToString();
            textBox2.Text = br.Cells["nama_penulis"].Value.ToString();
            textBox2.Text = br.Cells["nama_penerbit"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            hapus();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string tgl = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                string judul = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string penulis = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string penerbit = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                dateTimePicker1.Text = tgl;
                textBox1.Text = judul;
                textBox2.Text = penulis;
                textBox3.Text = penerbit;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
