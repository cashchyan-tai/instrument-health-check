using System;
using System.Linq;
using System.Windows.Forms;

namespace InstrumentHealthCheck
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool launchedFromLp = args.Contains("--from-lp");
            Application.Run(new MainForm(launchedFromLp));
        }
    }
}
