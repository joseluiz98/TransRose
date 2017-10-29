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
        private static int ano;
        private Button btSair;
        private Button btEnviaBanco;
        private Label label1;
        private TextBox recebeAnoNovoDB;

        public novoDB()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.recebeAnoNovoDB = new TextBox();
            this.btEnviaBanco = new Button();
            this.btSair = new Button();
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
            this.btEnviaBanco.FlatStyle = FlatStyle.Flat;
            this.btEnviaBanco.Location = new Point(0x131, 0x68);
            this.btEnviaBanco.Name = "btEnviaBanco";
            this.btEnviaBanco.Size = new Size(0x4b, 0x17);
            this.btEnviaBanco.TabIndex = 2;
            this.btEnviaBanco.Text = "Criar Banco";
            this.btEnviaBanco.UseVisualStyleBackColor = true;
            this.btEnviaBanco.Click += new EventHandler(this.btEnviaBanco_Click);
            this.btSair.FlatStyle = FlatStyle.Flat;
            this.btSair.Location = new Point(0xd6, 0x68);
            this.btSair.Name = "btSair";
            this.btSair.Size = new Size(0x4b, 0x17);
            this.btSair.TabIndex = 3;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new EventHandler(this.btSair_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x188, 0x8b);
            base.ControlBox = false;
            base.Controls.Add(this.btSair);
            base.Controls.Add(this.btEnviaBanco);
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

        private void btSair_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        public int getAno()
        {
            return ano;
        }

        private void btEnviaBanco_Click(object sender, EventArgs e)
        {
            ano = Convert.ToInt32(this.recebeAnoNovoDB.Text);
            SplashScreen screen = new SplashScreen();
            base.DialogResult = DialogResult.OK;
        }
    }
}

