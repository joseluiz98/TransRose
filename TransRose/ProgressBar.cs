using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransRose
{
    public partial class ProgressBar : Form
    {
        public static int tamanho;
        public ProgressBar()
        {
            InitializeComponent();
            //tamanho = TAM;

            // Sets the progress bar's Maximum property to
            // the total number of records to be created.
            //progressBar1.Maximum = tamanho;
            //progressBar1.Show();
        }

        public void setValor(int v)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.BeginInvoke((MethodInvoker) delegate {
                    progressBar1.Value = v;
                });
        }

        public void avancaBarra()
        {

            // Increases the value displayed by the progress bar.
            progressBar1.Value += 1;
            return;
        }
    }
}
