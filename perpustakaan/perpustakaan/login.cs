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

    public partial class login : Form
    {
        public MySqlCommand cmd;
        public MySqlDataReader rdr;
        public MySqlConnection koneksi;

        
        public login()
        {
            InitializeComponent();
        }

       
   
       
      

      

        private void getTheName(String username)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server = localhost;uid = root; database = perpustakaan; pwd = '';";
            String query = "select nama,kelas,alamat,hp,email from user where nim=@nim";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nim", username);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
               
                if (rdr.Read())
                {
                    Program.nama = rdr["nama"].ToString();
                    Program.kelas = rdr["kelas"].ToString();
                    Program.alamat = rdr["alamat"].ToString();
                    Program.hp = rdr["hp"].ToString(); 
                    Program.email = rdr["email"].ToString();
                    
                    

                }
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
        }

        
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            MySqlConnection koneksi = new MySqlConnection("server = localhost;uid = root; database = perpustakaan; pwd = '';");
            koneksi.Open();
            string nim = textBox1.Text;
            string pass = textBox2.Text;
            cmd = new MySqlCommand("select nim,pass from user where nim='" + textBox1.Text + "'and pass='" + textBox2.Text + "'", koneksi);
          
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            


            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.getTheName(textBox1.Text);
                this.Hide();
                app fm = new app();
                Program.login = textBox1.Text;
                
                fm.Show();
                

               
                
                
            }
            else
            {
                MessageBox.Show("NIM ATAU PASSWORD SALAH");
            }
            koneksi.Close();
        }



        private void label5_Click(object sender, EventArgs e)
        {
            daftar a = new daftar();
            this.Hide();
            a.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }


       
        

        }
    }



