using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
namespace perpustakaan
{
    public partial class daftar : Form
    {
        string database = ("server=localhost;uid=root;database=perpustakaan;pwd='';Convert Zero Datetime=True;");
        string fileName;
        string lastDir;
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public daftar()
        {
            InitializeComponent();
            
            
        }

        public void konek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Open();
        }
        public void Query(string query)
        {
            koneksi = new MySqlConnection(database);
            try
            {
                konek();
                cmd = new MySqlCommand(query, koneksi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            finally
            {
                koneksi.Close();
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "image files(*.jpg;*.jpeg;*.png;) | *.jpg;*jpeg;*.png;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileName = open.FileName.ToString();
                pictureBox1.ImageLocation = fileName;


            }
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                byte[] img = null;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql = "insert into user values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "', @foto )";
                
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                cmd.Parameters.Add(new MySqlParameter("@foto", img));
                int x = cmd.ExecuteNonQuery();

                koneksi.Close();
                
                MessageBox.Show(x.ToString()+ "Data Berhasil Didaftarkan");
            } 
            catch (Exception ex)
            {
                koneksi.Close();
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings.DefaultPageSettings.Landscape = false;
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

            var font = new Font("Sitka Display", 14);

            e.Graphics.DrawString("\t KARTU ANGGOTA PERPUSTAKAAN \n\n\n", font, Brushes.Black, 25, 20);
            e.Graphics.DrawString("Nama \t: " + textBox2.Text + "\n\n", new Font("Sitka Display", 12), Brushes.Black, 140, 70);
            e.Graphics.DrawString("Nim \t: " + textBox1.Text + "\n\n", new Font("Sitka Display", 12), Brushes.Black, 140, 90);
            e.Graphics.DrawString("Kelas \t: " + textBox3.Text + "\n\n", new Font("Sitka Display", 12), Brushes.Black, 140, 110);
            e.Graphics.DrawString("Alamat \t: " + textBox5.Text + "\n\n", new Font("Sitka Display", 12), Brushes.Black, 140, 130);

            e.Graphics.DrawImage(pictureBox1.Image, 30, 60, (int)90, (int)120);
            e.Graphics.DrawImage(pictureBox2.Image, 160, 170, (int)200, (int)30);
           
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login b = new login();
            b.Show();
            this.Close();
        }

       


    }
}
