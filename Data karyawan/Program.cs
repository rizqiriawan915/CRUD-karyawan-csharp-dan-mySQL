using System;
using System.Windows.Forms;

namespace Data_karyawan
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DataKaryawan());
        }
    }
}
