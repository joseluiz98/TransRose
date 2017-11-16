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
    public partial class importaRegistrosDialogo : Form
    {
        public importaRegistrosDialogo(ref ComboBox cbRecebeAno)
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
