using System;
using System.Threading;
using System.Windows.Forms;

namespace PDV.Apresentacao
{
    static class Program
    {
        // name é o identificador único da aplicação
        static Mutex mutex = new Mutex(true, name: "d4709732-f5aa-404f-ba0e-a0a8a4201ff6");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmPrincipal());
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show("Este programa já está sendo executado!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
