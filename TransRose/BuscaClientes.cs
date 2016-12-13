namespace WindowsFormsApplication2
{
    using System;
    using System.ComponentModel;
    using System.Data.OleDb;
    using System.Drawing;
    using System.Windows.Forms;

    public class BuscaClientes : Form
    {
        private Button botaoBuscar;
        private Button botaoSair;
        private VerCadastros chamaVerCadastros;
        private IContainer components = null;
        private Label descreveBuscaCrianca;
        private Label descreveBuscaID;
        private Label descreveBuscaNome;
        private PictureBox pictureBox4;
        private Label TituloBusca;
        private TextBox txtBuscaCrianca;
        private TextBox txtBuscaID;
        private TextBox txtBuscaNome;

        public BuscaClientes(VerCadastros busca)
        {
            this.InitializeComponent();
            this.chamaVerCadastros = busca;
        }

        private void botaoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (((this.txtBuscaID.Text.ToString() == "") & (this.txtBuscaNome.ToString() == "")) & (this.txtBuscaCrianca.ToString() == ""))
                {
                    MessageBox.Show("Nenhum dos campos foi preenchido", "Preencha ao menos um campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    VerCadastros.BuscaID = this.txtBuscaID.Text.ToString();
                    VerCadastros.BuscaNome = this.txtBuscaNome.Text.ToString();
                    VerCadastros.BuscaCrianca = this.txtBuscaCrianca.Text.ToString();
                    this.chamaVerCadastros.CarregaDados();
                    this.chamaVerCadastros.WindowState = FormWindowState.Maximized;
                    this.chamaVerCadastros.Focus();
                    this.chamaVerCadastros.BringToFront();
                }
            }
            catch (OleDbException exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
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

        private void InitializeComponent()
        {
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.TituloBusca = new System.Windows.Forms.Label();
            this.descreveBuscaID = new System.Windows.Forms.Label();
            this.descreveBuscaNome = new System.Windows.Forms.Label();
            this.txtBuscaID = new System.Windows.Forms.TextBox();
            this.txtBuscaNome = new System.Windows.Forms.TextBox();
            this.txtBuscaCrianca = new System.Windows.Forms.TextBox();
            this.descreveBuscaCrianca = new System.Windows.Forms.Label();
            this.botaoSair = new System.Windows.Forms.Button();
            this.botaoBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::TransRose.Properties.Resources.seek_row;
            this.pictureBox4.Location = new System.Drawing.Point(12, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(136, 78);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // TituloBusca
            // 
            this.TituloBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TituloBusca.AutoSize = true;
            this.TituloBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloBusca.Location = new System.Drawing.Point(196, 25);
            this.TituloBusca.Name = "TituloBusca";
            this.TituloBusca.Size = new System.Drawing.Size(203, 25);
            this.TituloBusca.TabIndex = 42;
            this.TituloBusca.Text = "Busca de Clientes";
            // 
            // descreveBuscaID
            // 
            this.descreveBuscaID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descreveBuscaID.AutoSize = true;
            this.descreveBuscaID.Location = new System.Drawing.Point(89, 93);
            this.descreveBuscaID.Name = "descreveBuscaID";
            this.descreveBuscaID.Size = new System.Drawing.Size(72, 13);
            this.descreveBuscaID.TabIndex = 43;
            this.descreveBuscaID.Text = "Busca por ID:";
            // 
            // descreveBuscaNome
            // 
            this.descreveBuscaNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descreveBuscaNome.AutoSize = true;
            this.descreveBuscaNome.Location = new System.Drawing.Point(89, 130);
            this.descreveBuscaNome.Name = "descreveBuscaNome";
            this.descreveBuscaNome.Size = new System.Drawing.Size(89, 13);
            this.descreveBuscaNome.TabIndex = 44;
            this.descreveBuscaNome.Text = "Busca por Nome:";
            // 
            // txtBuscaID
            // 
            this.txtBuscaID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaID.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscaID.Location = new System.Drawing.Point(190, 90);
            this.txtBuscaID.Name = "txtBuscaID";
            this.txtBuscaID.Size = new System.Drawing.Size(48, 20);
            this.txtBuscaID.TabIndex = 1;
            // 
            // txtBuscaNome
            // 
            this.txtBuscaNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaNome.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscaNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscaNome.Location = new System.Drawing.Point(190, 127);
            this.txtBuscaNome.Name = "txtBuscaNome";
            this.txtBuscaNome.Size = new System.Drawing.Size(249, 20);
            this.txtBuscaNome.TabIndex = 2;
            // 
            // txtBuscaCrianca
            // 
            this.txtBuscaCrianca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaCrianca.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscaCrianca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscaCrianca.Location = new System.Drawing.Point(190, 164);
            this.txtBuscaCrianca.Name = "txtBuscaCrianca";
            this.txtBuscaCrianca.Size = new System.Drawing.Size(249, 20);
            this.txtBuscaCrianca.TabIndex = 3;
            // 
            // descreveBuscaCrianca
            // 
            this.descreveBuscaCrianca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descreveBuscaCrianca.AutoSize = true;
            this.descreveBuscaCrianca.Location = new System.Drawing.Point(89, 167);
            this.descreveBuscaCrianca.Name = "descreveBuscaCrianca";
            this.descreveBuscaCrianca.Size = new System.Drawing.Size(97, 13);
            this.descreveBuscaCrianca.TabIndex = 47;
            this.descreveBuscaCrianca.Text = "Busca por Criança:";
            // 
            // botaoSair
            // 
            this.botaoSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoSair.Location = new System.Drawing.Point(417, 190);
            this.botaoSair.Name = "botaoSair";
            this.botaoSair.Size = new System.Drawing.Size(75, 23);
            this.botaoSair.TabIndex = 5;
            this.botaoSair.Text = "Sair";
            this.botaoSair.UseVisualStyleBackColor = true;
            this.botaoSair.Click += new System.EventHandler(this.botaoSair_Click);
            // 
            // botaoBuscar
            // 
            this.botaoBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoBuscar.Location = new System.Drawing.Point(324, 190);
            this.botaoBuscar.Name = "botaoBuscar";
            this.botaoBuscar.Size = new System.Drawing.Size(75, 23);
            this.botaoBuscar.TabIndex = 4;
            this.botaoBuscar.Text = "Buscar";
            this.botaoBuscar.UseVisualStyleBackColor = true;
            this.botaoBuscar.Click += new System.EventHandler(this.botaoBuscar_Click);
            // 
            // BuscaClientes
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 222);
            this.ControlBox = false;
            this.Controls.Add(this.botaoBuscar);
            this.Controls.Add(this.botaoSair);
            this.Controls.Add(this.txtBuscaCrianca);
            this.Controls.Add(this.descreveBuscaCrianca);
            this.Controls.Add(this.txtBuscaNome);
            this.Controls.Add(this.txtBuscaID);
            this.Controls.Add(this.descreveBuscaNome);
            this.Controls.Add(this.descreveBuscaID);
            this.Controls.Add(this.TituloBusca);
            this.Controls.Add(this.pictureBox4);
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 260);
            this.MinimumSize = new System.Drawing.Size(520, 260);
            this.Name = "BuscaClientes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Cliente - Cadastro de Clientes - TransRose";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

