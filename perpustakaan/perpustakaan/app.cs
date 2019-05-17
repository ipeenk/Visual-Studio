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
    public partial class app : Form
    {
        public app()
        {
            InitializeComponent();
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



        
        private void app_Load(object sender, EventArgs e)
        {
            label3.Text = Program.nama;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login b = new login();
            b.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            peminjaman b = new peminjaman();
            b.Show();
            this.Hide();
        }

       
        public DataTable baca()
        {
            
            DataTable dt = new DataTable();
            try
            {
                konek();
                string sql = "select nama,kelas,buku,pengembalian from pinjam where nim = '" + Program.login + "' ";
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

        private void label5_Click(object sender, EventArgs e)
        {
            baca();
        }

        private void dATAANDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            akun acc = new akun();
            this.Close();
            acc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pengembalian kem = new pengembalian();
            this.Close();
            kem.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             
        
            printDocument1.PrinterSettings.DefaultPageSettings.Landscape = false;
            printDocument1.Print();
        

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            var font = new Font("Khmer UI", 12);
            e.Graphics.DrawString("\t\t\t DAFTAR PINJAMAN \n\n\n", font, Brushes.Black, 25, 10);
            e.Graphics.DrawString("\t\t\t =================================== \n\n\n", font, Brushes.Black, 25, 18);
            e.Graphics.DrawString("nama \t:" + Program.nama + "\n\n", font, Brushes.Black, 20, 30);
           
        
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about a = new about();
            a.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

     
        
    }
    }
