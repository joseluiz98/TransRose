namespace WindowsFormsApplication2
{
    using System;
    using System.Windows.Forms;

    public class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VerCadastros("", "", "", "", "", "", true));
        }
    }
}