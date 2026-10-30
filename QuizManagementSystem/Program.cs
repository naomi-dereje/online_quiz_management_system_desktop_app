using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizMaster.Forms;
using QuizMaster.Services;

namespace QuizMaster
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataStore.Seed();
            Application.Run(new Home());
        }
    }
}