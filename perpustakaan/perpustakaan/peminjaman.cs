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
    public partial class peminjaman : Form
    {
        string database = ("server = localhost;uid = root; database = perpustakaan; pwd = '';Convert Zero Datetime=True;");

        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public peminjaman()
        {
            InitializeComponent();
        }






         public void query(string query)
        {
            koneksi = new MySqlConnection(database);

            try
            {
                koneksi.Open();
                cmd = new MySqlCommand( query,koneksi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception mars)
            {
                MessageBox.Show(mars.Message);

            }
            finally
            {
                koneksi.Close();
            }
        }


         

         private void button1_Click_1(object sender, EventArgs e)
         {
             string a, b, c, d, s;
             string hasil;

             a = textBox1.Text;
             b = textBox2.Text;
             c = textBox3.Text;
             d = comboBox1.Text;
             s = comboBox2.Text;
             DateTime date = DateTime.Now;


             if (string.IsNullOrWhiteSpace(a))
             {
                 MessageBox.Show("MAAF KOLOM TIDAK BOLEH KOSONG");
             }
             else if (string.IsNullOrWhiteSpace(b))
             {
                 MessageBox.Show("MAAF KOLOM TIDAK BOLEH KOSONG");
             }
             else if (string.IsNullOrWhiteSpace(c))
             {
                 MessageBox.Show("MAAF KOLOM TIDAK BOLEH KOSONG");
             }
             else if (string.IsNullOrWhiteSpace(d))
             {
                 MessageBox.Show("MAAF KOLOM TIDAK BOLEH KOSONG");
             }
             else
             {
                 if (s == "1")
                 {
                     hasil = date.AddDays(1).ToString("yyyy-MM-dd");
                     query("insert into pinjam values('" + a + "','" + b + "','" + c + "','" + d + "','" + hasil +"')");
                     MessageBox.Show("BERHASIL MEMINJAM BUKU DATA \n\n MAHASISWA\n\n" + "\nNAMA : " + a + "\n\nNIM : " + b + "\n\nKELAS : " + c + "\n\nBUKU : " + d + "\n\n========================================="
                            + "\n\nANDA MEMINJAM BUKU SELAMA : " + s + " HARI"
                            + "\n\nDIKEMBALIKAN PADA TANGGAL : " + hasil + "\n\nHARAP DIKEMBALIKAN SESUAI JADWAL", "APLIKASI PEMINJAMAN BUKU");

                 }

                 else if (s == "2")
                 {
                     hasil = date.AddDays(2).ToString("yyyy-MM-dd");
                     query("insert into pinjam values('" + a + "','" + b + "','" + c + "','" + d + "','" + hasil + "')");
                     MessageBox.Show("BERHASIL MEMINJAM BUKU DATA \n\n MAHASISWA\n\n" + "\nNAMA : " + a + "\n\nNIM : " + b + "\n\nKELAS : " + c + "\n\nBUKU : " + d + "\n\n========================================="
                         + "\n\nANDA MEMINJAM BUKU SELAMA : " + s + " HARI"
                         + "\n\nDIKEMBALIKAN PADA TANGGAL : " + hasil + "\n\nHARAP DIKEMBALIKAN SESUAI JADWAL", "APLIKASI PEMINJAMAN BUKU");

                 }
                 else if (s == "3")
                 {
                     hasil = date.AddDays(3).ToString("yyyy-MM-dd");
                     query("insert into pinjam values('" + a + "','" + b + "','" + c + "','" + d + "','" + hasil + "')");
                     MessageBox.Show("BERHASIL MEMINJAM BUKU DATA \n\n MAHASISWA\n\n" + "\nNAMA : " + a + "\n\nNIM : " + b + "\n\nKELAS : " + c + "\n\nBUKU : " + d + "\n\n========================================="
                         + "\n\nANDA MEMINJAM BUKU SELAMA : " + s + " HARI"
                         + "\n\nDIKEMBALIKAN PADA TANGGAL : " + hasil + "\n\nHARAP DIKEMBALIKAN SESUAI JADWAL", "APLIKASI PEMINJAMAN BUKU");

                 }
                 else if (s == "4")
                 {
                     hasil = date.AddDays(4).ToString("yyyy-MM-dd");
                     query("insert into pinjam values('" + a + "','" + b + "','" + c + "','" + d + "','" + hasil + "')");
                     MessageBox.Show("BERHASIL MEMINJAM BUKU DATA \n\n MAHASISWA\n\n" + "\nNAMA : " + a + "\n\nNIM : " + b + "\n\nKELAS : " + c + "\n\nBUKU : " + d + "\n\n========================================="
                         + "\n\nANDA MEMINJAM BUKU SELAMA : " + s + " HARI"
                         + "\n\nDIKEMBALIKAN PADA TANGGAL : " + hasil + "\n\nHARAP DIKEMBALIKAN SESUAI JADWAL", "APLIKASI PEMINJAMAN BUKU");


                 }
                 else if (s == "5")
                 {
                     hasil = date.AddDays(5).ToString("yyyy-MM-dd");
                     query("insert into pinjam values('" + a + "','" + b + "','" + c + "','" + d + "','" + hasil + "')");
                     MessageBox.Show("BERHASIL MEMINJAM BUKU DATA \n\n MAHASISWA\n\n" + "\nNAMA : " + a + "\n\nNIM : " + b + "\n\nKELAS : " + c + "\n\nBUKU : " + d + "\n\n========================================="
                          + "\n\nANDA MEMINJAM BUKU SELAMA : " + s + " HARI"
                          + "\n\nDIKEMBALIKAN PADA TANGGAL : " + hasil + "\n\nHARAP DIKEMBALIKAN SESUAI JADWAL", "APLIKASI PEMINJAMAN BUKU");

                 }
                 else if (s == "6")
                 {
                     hasil = date.AddDays(6).ToString("yyyy-MM-dd");
                     query("insert into pinjam values('" + a + "','" + b + "','" + c + "','" + d + "','" + hasil +  "')");
                     MessageBox.Show("BERHASIL MEMINJAM BUKU DATA \n\n MAHASISWA\n\n" + "\nNAMA : " + a + "\n\nNIM : " + b + "\n\nKELAS : " + c + "\n\nBUKU : " + d + "\n\n========================================="
                         + "\n\nANDA MEMINJAM BUKU SELAMA : " + s + " HARI"
                         + "\n\nDIKEMBALIKAN PADA TANGGAL : " + hasil + "\n\nHARAP DIKEMBALIKAN SESUAI JADWAL", "APLIKASI PEMINJAMAN BUKU");

                 }
                 else if (s == "7")
                 {
                     hasil = date.AddDays(7).ToString("yyyy-MM-dd");
                     query("insert into pinjam values('" + a + "','" + b + "','" + c + "','" + d + "','" + hasil + "')");
                     MessageBox.Show("BERHASIL MEMINJAM BUKU DATA \n\n MAHASISWA\n\n" + "\nNAMA : " + a + "\n\nNIM : " + b + "\n\nKELAS : " + c + "\n\nBUKU : " + d + "\n\n========================================="
                          + "\n\nANDA MEMINJAM BUKU SELAMA : " + s + " HARI"
                          + "\n\nDIKEMBALIKAN PADA TANGGAL : " + hasil + "\n\nHARAP DIKEMBALIKAN SESUAI JADWAL", "APLIKASI PEMINJAMAN BUKU");
                 }
                 else
                 {

                     MessageBox.Show("MAAF CUMA BISA PINJAM 7 HARI, TERIMA KASIH");

                 }
             }
         }

         private void button2_Click(object sender, EventArgs e)
         {
             app b = new app();
             b.Show();
             this.Close();
         }

         private void button3_Click(object sender, EventArgs e)
         {
             textBox1.Text = "";
             textBox2.Text = "";
             textBox3.Text = "";
             comboBox1.Text = "";
             comboBox2.Text = "";

         }

         private void peminjaman_Load(object sender, EventArgs e)
         {
             textBox2.Text = Program.login;
             textBox1.Text = Program.nama;
             textBox3.Text = Program.kelas;
         }
    }
  
  }