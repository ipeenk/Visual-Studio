using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace perpustakaan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
        public static string login;
        public static string nama;
        public static string kelas;
        public static string alamat;
        public static string hp;
        public static string email;
        public static string buku;
      
        
        
        
    }
}
