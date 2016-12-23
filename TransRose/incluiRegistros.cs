using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TransRose
{
    public partial class incluiRegistros : Form
    {

        public incluiRegistros()
        {
            InitializeComponent();

            ProgressBar Progress = new ProgressBar(50);
            Progress.Show();
            for (int i = 1; i<=50; i++)
            {
                Progress.avancaBarra();
                checkedListBox1.Items.Add("Opção " + i);
                Thread.Sleep(40);
            }

            Progress.Close();
        }

        private void incluiRegistros_Load(object sender, EventArgs e)
        {

        }
    }
}
