using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace perpustakaan
{
    public partial class akun : Form
    {
        string database = ("server=localhost;uid=root;database=perpustakaan;pwd='';Convert Zero Datetime=True;");

        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public akun()
        {
            InitializeComponent();
        }
        public void konek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Open();
        }
        

        private void akun_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select foto from user where nim = '" + Program.login + "' ";
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    textBox1.Text = Program.login;
                    textBox2.Text = Program.nama;
                    textBox3.Text = Program.kelas;
                    textBox4.Text = Program.alamat;
                    textBox5.Text = Program.email;
                    textBox6.Text = Program.hp;
                    Byte[] img = (byte[])(dr["foto"]);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Bitmap.FromStream(ms);
                }

                koneksi.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
                
            
            

           
            
           
           


          
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksidatabase kont = new koneksidatabase();
            kont.QUERY("UPDATE user set nama = '" + this.textBox2.Text + "', kelas = '" + this.textBox3.Text + "',alamat = '" + this.textBox4.Text + "',hp = '" + this.textBox6.Text + "',email = '" + this.textBox5.Text + "' WHERE nim = '" + this.textBox1.Text + "' ");
            MessageBox.Show("edit berhasil sukses,silahkan login ulang");
            login log = new login();
            this.Close();
            log.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            app back = new app();
            this.Close();
            back.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings.DefaultPageSettings.Landscape = false;
            printDocument1.Print();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.Size = new System.Drawing.Size(100, 100);
            
            printPreviewDialog1.ShowDialog();
          
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var font = new Font("Sitka Display", 14);

            e.Graphics.DrawString("\t KARTU ANGGOTA PERPUSTAKAAN \n\n\n", font, Brushes.Black,25, 20);
            e.Graphics.DrawString("Nama \t: " + Program.nama + "\n\n", new Font("Sitka Display", 12), Brushes.Black, 140, 70);
            e.Graphics.DrawString("Nim \t: " + Program.login + "\n\n", new Font("Sitka Display", 12), Brushes.Black, 140, 90);
            e.Graphics.DrawString("Kelas \t: " + Program.kelas + "\n\n", new Font("Sitka Display", 12), Brushes.Black, 140, 110);
            e.Graphics.DrawString("Alamat \t: " + Program.alamat + "\n\n", new Font("Sitka Display", 12), Brushes.Black, 140, 130);

            e.Graphics.DrawImage(pictureBox1.Image, 30, 60, (int)90, (int)120);
         
            e.Graphics.DrawImage(pictureBox2.Image, 160, 170, (int)200, (int)30);
        }

       
    }
}
