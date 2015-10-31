using System; 
using System.Windows.Forms;
using process_demonizator.UI;

namespace process_demonizator
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(
                new FrmMain()
                //new FrmAdd()
            );
        }
    }
}
