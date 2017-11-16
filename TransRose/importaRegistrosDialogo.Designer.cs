namespace TransRose
{
    partial class importaRegistrosDialogo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btSair = new System.Windows.Forms.Button();
            this.btEnviaAno = new System.Windows.Forms.Button();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.cbRecebeAno = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btSair
            // 
            this.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSair.Location = new System.Drawing.Point(181, 104);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(75, 23);
            this.btSair.TabIndex = 7;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // btEnviaAno
            // 
            this.btEnviaAno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnviaAno.Location = new System.Drawing.Point(271, 104);
            this.btEnviaAno.Name = "btEnviaAno";
            this.btEnviaAno.Size = new System.Drawing.Size(100, 23);
            this.btEnviaAno.TabIndex = 6;
            this.btEnviaAno.Text = "Selecionar Ano";
            this.btEnviaAno.UseVisualStyleBackColor = true;
            // 
            // lbMensagem
            // 
            this.lbMensagem.AutoSize = true;
            this.lbMensagem.Location = new System.Drawing.Point(112, 30);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(187, 13);
            this.lbMensagem.TabIndex = 4;
            this.lbMensagem.Text = "Qual o ano do novo banco de dados?";
            // 
            // cbRecebeAno
            // 
            this.cbRecebeAno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRecebeAno.FormattingEnabled = true;
            this.cbRecebeAno.Location = new System.Drawing.Point(136, 59);
            this.cbRecebeAno.Name = "cbRecebeAno";
            this.cbRecebeAno.Size = new System.Drawing.Size(121, 21);
            this.cbRecebeAno.Sorted = true;
            this.cbRecebeAno.TabIndex = 8;
            // 
            // importaRegistrosDialogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 139);
            this.ControlBox = false;
            this.Controls.Add(this.cbRecebeAno);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.btEnviaAno);
            this.Controls.Add(this.lbMensagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "importaRegistrosDialogo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importando registros";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Button btEnviaAno;
        private System.Windows.Forms.Label lbMensagem;
        private System.Windows.Forms.ComboBox cbRecebeAno;
    }
}