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
    public partial class Register : MetroFramework.Forms.MetroForm
    {
        string database = ("server = localhost; database = member; uid = root; pwd = ''; convert zero datetime = true ");
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public MySqlDataReader read;
        public Register()
        {
            InitializeComponent();
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            ctxMenu.Show(metroLink1, 0, metroLink1.Height);
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string rGender = "";

            if (metroRadioButton1.Checked)
            {
                rGender = metroRadioButton1.Text;
            }
            else if (metroRadioButton2.Checked)
            {
                rGender = metroRadioButton2.Text;
            }

            Query("insert into user (nama, nickname, pass, jekel, alamat, hp, email) values('" + this.metroTextBox1.Text + "','" + this.metroTextBox2.Text + "','" + metroTextBox3.Text + "','" + rGender + "','" + this.metroTextBox4.Text + "','" + this.metroTextBox5.Text + "','" + this.metroTextBox6.Text + "')");
            MessageBox.Show("DAFTAR berhasil");
        }

        private void lOGINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
            metroTextBox3.Text = "";
            metroTextBox4.Text = "";
            metroTextBox5.Text = "";
            metroTextBox6.Text = "";
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
        }
    }
}
