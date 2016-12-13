namespace WindowsFormsApplication2
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class novoDB : Form
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static int ano;
        private Button botaoSair;
        private IContainer components = null;
        private Button enviaBanco;
        private Label label1;
        private TextBox recebeAnoNovoDB;

        public novoDB(int recebeAno)
        {
            this.InitializeComponent();
            ano = recebeAno;
        }

        private void botaoSair_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private void enviaBanco_Click(object sender, EventArgs e)
        {
            ano = Convert.ToInt32(this.recebeAnoNovoDB.Text);
            SplashScreen screen = new SplashScreen(ano);
            base.DialogResult = DialogResult.OK;
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.recebeAnoNovoDB = new TextBox();
            this.enviaBanco = new Button();
            this.botaoSair = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x72, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xbb, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Qual o ano do novo banco de dados?";
            this.recebeAnoNovoDB.Location = new Point(0x91, 0x3f);
            this.recebeAnoNovoDB.Name = "recebeAnoNovoDB";
            this.recebeAnoNovoDB.Size = new Size(100, 20);
            this.recebeAnoNovoDB.TabIndex = 1;
            this.enviaBanco.FlatStyle = FlatStyle.Flat;
            this.enviaBanco.Location = new Point(0x131, 0x68);
            this.enviaBanco.Name = "enviaBanco";
            this.enviaBanco.Size = new Size(0x4b, 0x17);
            this.enviaBanco.TabIndex = 2;
            this.enviaBanco.Text = "Criar Banco";
            this.enviaBanco.UseVisualStyleBackColor = true;
            this.enviaBanco.Click += new EventHandler(this.enviaBanco_Click);
            this.botaoSair.FlatStyle = FlatStyle.Flat;
            this.botaoSair.Location = new Point(0xd6, 0x68);
            this.botaoSair.Name = "botaoSair";
            this.botaoSair.Size = new Size(0x4b, 0x17);
            this.botaoSair.TabIndex = 3;
            this.botaoSair.Text = "Sair";
            this.botaoSair.UseVisualStyleBackColor = true;
            this.botaoSair.Click += new EventHandler(this.botaoSair_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x188, 0x8b);
            base.ControlBox = false;
            base.Controls.Add(this.botaoSair);
            base.Controls.Add(this.enviaBanco);
            base.Controls.Add(this.recebeAnoNovoDB);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Name = "novoDB";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Cadastrar banco";
            base.TopMost = true;
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        /*public static int ano
        {
            get; set;
        }*/
    }
}

