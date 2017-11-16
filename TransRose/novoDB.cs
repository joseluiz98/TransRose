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
            this.label1 = new System.Windows.Forms.Label();
            this.recebeAnoNovoDB = new System.Windows.Forms.TextBox();
            this.btEnviaBanco = new System.Windows.Forms.Button();
            this.btSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Qual o ano do novo banco de dados?";
            // 
            // recebeAnoNovoDB
            // 
            this.recebeAnoNovoDB.Location = new System.Drawing.Point(145, 63);
            this.recebeAnoNovoDB.Name = "recebeAnoNovoDB";
            this.recebeAnoNovoDB.Size = new System.Drawing.Size(100, 20);
            this.recebeAnoNovoDB.TabIndex = 1;
            // 
            // btEnviaBanco
            // 
            this.btEnviaBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnviaBanco.Location = new System.Drawing.Point(305, 104);
            this.btEnviaBanco.Name = "btEnviaBanco";
            this.btEnviaBanco.Size = new System.Drawing.Size(75, 23);
            this.btEnviaBanco.TabIndex = 2;
            this.btEnviaBanco.Text = "Criar Banco";
            this.btEnviaBanco.UseVisualStyleBackColor = true;
            this.btEnviaBanco.Click += new System.EventHandler(this.btEnviaBanco_Click);
            // 
            // btSair
            // 
            this.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSair.Location = new System.Drawing.Point(214, 104);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(75, 23);
            this.btSair.TabIndex = 3;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // novoDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 139);
            this.ControlBox = false;
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.btEnviaBanco);
            this.Controls.Add(this.recebeAnoNovoDB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "novoDB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar banco";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

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

