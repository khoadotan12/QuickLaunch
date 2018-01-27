using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1512252
{
    public static class Data
    {
        public static List<string> listpath, listfile;
    }
    public static class Stats
    {
        public static List <string> filename;
        public static List <int> frequent;
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        

        static void Main()
        {
            Data.listfile = new List<string>();
            Data.listpath = new List<string>();
            Stats.filename = new List<string>();
            Stats.frequent = new List<int>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
