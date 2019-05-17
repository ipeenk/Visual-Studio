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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        string database = ("server = localhost; database = member; uid = root; pwd = ''; convert zero datetime = true ");
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public MySqlDataReader read;
        string data, status;
        public Login()
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
            konek();
            cmd = new MySqlCommand(query, koneksi);
            adp = new MySqlDataAdapter(cmd);
            read = cmd.ExecuteReader();
            read.Read();
            if (read.HasRows)
            {
                data = read.GetString("password");
                status = read.GetString("status");
            }
            diskonek();
        }
        private void metroLink1_Click(object sender, EventArgs e)
        {
            ctxMenu.Show(metroLink1, 0, metroLink1.Height);
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String nick = metroTextBox2.Text;
            String password = metroTextBox1.Text;
            konek();
            cmd = new MySqlCommand("select nickname,pass from user where nickname='" + metroTextBox2.Text + "'and pass='" + metroTextBox1.Text + "'", koneksi);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MenuUtama fr = new MenuUtama();
                this.Hide();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Nickname ATAU PASSWORD SALAH");
            }
            koneksi.Close();
            diskonek();
        }

        private void ctxMenu_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
