namespace WindowsFormsApplication2
{
    using System;
    using System.ComponentModel;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class excluiCliente : Form
    {
        /*[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string <ct>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string <db>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string <localizaBanco>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string <localizaCont>k__BackingField;*/
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private PictureBox cadastraCliente;
        private IContainer components = null;
        private Label descreveApanha;
        private Label descreveBairro;
        private Label descreveBairroEscola;
        private Label descreveCasa;
        private Label descreveCel;
        private Label descreveCPF;
        private Label descreveCrianca;
        private Label descreveEntrega;
        private Label descreveEscola;
        private Label descreveEscTel;
        private Label descreveOrgao;
        private Label descreveParcela;
        private Label descreveRG;
        private Label descreveRua;
        private Label descreveRuaEscola;
        private Label descreveTelFixo;
        private Label descreveValContrato;
        private ToolStripMenuItem fecharToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private MenuStrip menuStrip1;
        private NotifyIcon notifyCadastroSucesso;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private Label TituloDadosdoContrato;
        private Label TituloDadosResponsavel;
        private Label TituloDadosServico;
        private Label TituloHorarios;
        private MaskedTextBox txtApanha;
        private TextBox txtBairro;
        private TextBox txtBairroEscola;
        private MaskedTextBox txtCel;
        private MaskedTextBox txtCPF;
        private MaskedTextBox txtEnt;
        private TextBox txtEscola;
        private MaskedTextBox txtEscTel;
        private TextBox txtId;
        private TextBox txtNome;
        private TextBox txtNomeCrianca;
        private TextBox txtNumCasa;
        private TextBox txtOrgao;
        private MaskedTextBox txtParc;
        private TextBox txtRG;
        private TextBox txtRua;
        private TextBox txtRuaEscola;
        private MaskedTextBox txtTelFixo;
        private MaskedTextBox txtValAnual;
        private ComboBox txtValContrato;
        private PictureBox voltarVerCadastros;

        public excluiCliente(string data, string contrato)
        {
            this.InitializeComponent();
            db = data;
            localizaBanco = @"C:\Windows\Temp\transrosedb\" + db + ".mdb";
            ct = contrato;
            localizaCont = @"C:\Windows\Temp\transrosedb\" + ct + ".doc";
        }

        private void cadastraCliente_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text == "")
            {
                MessageBox.Show("Campo Cliente: Não pode estar em branco!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.txtId.Text == "")
            {
                MessageBox.Show("Campo ID: Não pode estar em branco!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!this.txtCPF.MaskFull)
            {
                MessageBox.Show("Campo CPF: não pode conter caracteres em branco!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!this.txtParc.MaskFull)
            {
                MessageBox.Show("Campo Valor da Parcela: não pode estar em branco!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!this.txtValAnual.MaskFull)
            {
                MessageBox.Show("Campo Valor Anual: não pode estar em branco!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.txtValContrato.SelectedItem == null)
            {
                MessageBox.Show("Campo Contrato: deve ser selecionada uma opção!", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                int num = Convert.ToInt32(this.txtId.Text);
                bool flag = false;
                if (this.txtValContrato.SelectedItem.ToString() == "Ativo")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + localizaBanco + "'";
                string str2 = "ID,Nome,Rua,NumCasa,Bairro,RG,[Orgão Expedidor],CPF,[Telefone Fixo],Celular,Contrato,Parcela,[Valor Anual],Criança,[Nome da escola],[Rua da escola],[Telefone da escola],[Bairro da escola],Apanha,Entrega";
                object[] objArray1 = new object[] { 
                    "INSERT INTO Cadastros(", str2, ") VALUES(", num, ",'", this.txtNome.Text, "','", this.txtRua.Text, "','", this.txtNumCasa.Text, "','", this.txtBairro.Text, "','", this.txtRG.Text, "', '", this.txtOrgao.Text,
                    "','", this.txtCPF.Text, "','", this.txtTelFixo.Text, "','", this.txtCel.Text, "', ", flag.ToString(), ",'", this.txtParc.Text, "','", this.txtValAnual.Text, "','", this.txtNomeCrianca.Text, "','", this.txtEscola.Text,
                    "','", this.txtRuaEscola.Text, "','", this.txtEscTel.Text, "','", this.txtBairroEscola.Text, "','", this.txtApanha.Text, "','", this.txtEnt.Text, "')"
                };
                string cmdText = string.Concat(objArray1);
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand command = new OleDbCommand(cmdText, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    this.LimparCampos();
                    new VerCadastros("", db, ct, "", "", "", true).CarregaDados();
                    MessageBox.Show("Cliente cadastrado com sucesso.");
                    this.notifyCadastroSucesso.Visible = true;
                    this.notifyCadastroSucesso.ShowBalloonTip(5);
                    Thread.Sleep(0x7d0);
                    this.notifyCadastroSucesso.Visible = false;
                }
                catch (OleDbException exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(excluiCliente));
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.notifyCadastroSucesso = new System.Windows.Forms.NotifyIcon(this.components);
            this.descreveEntrega = new System.Windows.Forms.Label();
            this.TituloHorarios = new System.Windows.Forms.Label();
            this.descreveApanha = new System.Windows.Forms.Label();
            this.txtBairroEscola = new System.Windows.Forms.TextBox();
            this.descreveBairroEscola = new System.Windows.Forms.Label();
            this.txtRuaEscola = new System.Windows.Forms.TextBox();
            this.descreveRuaEscola = new System.Windows.Forms.Label();
            this.txtEscola = new System.Windows.Forms.TextBox();
            this.descreveEscola = new System.Windows.Forms.Label();
            this.txtNomeCrianca = new System.Windows.Forms.TextBox();
            this.descreveCrianca = new System.Windows.Forms.Label();
            this.TituloDadosServico = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.descreveParcela = new System.Windows.Forms.Label();
            this.txtValContrato = new System.Windows.Forms.ComboBox();
            this.TituloDadosdoContrato = new System.Windows.Forms.Label();
            this.descreveValContrato = new System.Windows.Forms.Label();
            this.descreveCel = new System.Windows.Forms.Label();
            this.descreveTelFixo = new System.Windows.Forms.Label();
            this.TituloDadosResponsavel = new System.Windows.Forms.Label();
            this.descreveCPF = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.descreveRG = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.descreveBairro = new System.Windows.Forms.Label();
            this.txtNumCasa = new System.Windows.Forms.TextBox();
            this.descreveCasa = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.descreveRua = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtOrgao = new System.Windows.Forms.TextBox();
            this.descreveOrgao = new System.Windows.Forms.Label();
            this.descreveEscTel = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtTelFixo = new System.Windows.Forms.MaskedTextBox();
            this.txtCel = new System.Windows.Forms.MaskedTextBox();
            this.txtEscTel = new System.Windows.Forms.MaskedTextBox();
            this.txtApanha = new System.Windows.Forms.MaskedTextBox();
            this.txtEnt = new System.Windows.Forms.MaskedTextBox();
            this.txtParc = new System.Windows.Forms.MaskedTextBox();
            this.txtValAnual = new System.Windows.Forms.MaskedTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voltarVerCadastros = new System.Windows.Forms.PictureBox();
            this.cadastraCliente = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voltarVerCadastros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cadastraCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtId.Location = new System.Drawing.Point(180, 42);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(30, 20);
            this.txtId.TabIndex = 0;
            // 
            // notifyCadastroSucesso
            // 
            this.notifyCadastroSucesso.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyCadastroSucesso.BalloonTipText = "Novo cliente cadastrado";
            // 
            // descreveEntrega
            // 
            this.descreveEntrega.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveEntrega.AutoSize = true;
            this.descreveEntrega.Location = new System.Drawing.Point(525, 538);
            this.descreveEntrega.Name = "descreveEntrega";
            this.descreveEntrega.Size = new System.Drawing.Size(47, 13);
            this.descreveEntrega.TabIndex = 100;
            this.descreveEntrega.Text = "Entrega:";
            // 
            // TituloHorarios
            // 
            this.TituloHorarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloHorarios.AutoSize = true;
            this.TituloHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloHorarios.Location = new System.Drawing.Point(600, 444);
            this.TituloHorarios.Name = "TituloHorarios";
            this.TituloHorarios.Size = new System.Drawing.Size(101, 25);
            this.TituloHorarios.TabIndex = 97;
            this.TituloHorarios.Text = "Horários";
            // 
            // descreveApanha
            // 
            this.descreveApanha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveApanha.AutoSize = true;
            this.descreveApanha.Location = new System.Drawing.Point(525, 508);
            this.descreveApanha.Name = "descreveApanha";
            this.descreveApanha.Size = new System.Drawing.Size(47, 13);
            this.descreveApanha.TabIndex = 96;
            this.descreveApanha.Text = "Apanha:";
            // 
            // txtBairroEscola
            // 
            this.txtBairroEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBairroEscola.BackColor = System.Drawing.SystemColors.Window;
            this.txtBairroEscola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairroEscola.Location = new System.Drawing.Point(588, 342);
            this.txtBairroEscola.Name = "txtBairroEscola";
            this.txtBairroEscola.Size = new System.Drawing.Size(250, 20);
            this.txtBairroEscola.TabIndex = 16;
            // 
            // descreveBairroEscola
            // 
            this.descreveBairroEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveBairroEscola.AutoSize = true;
            this.descreveBairroEscola.Location = new System.Drawing.Point(525, 347);
            this.descreveBairroEscola.Name = "descreveBairroEscola";
            this.descreveBairroEscola.Size = new System.Drawing.Size(48, 13);
            this.descreveBairroEscola.TabIndex = 94;
            this.descreveBairroEscola.Text = "Bairro(s):";
            // 
            // txtRuaEscola
            // 
            this.txtRuaEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRuaEscola.BackColor = System.Drawing.SystemColors.Window;
            this.txtRuaEscola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuaEscola.Location = new System.Drawing.Point(588, 312);
            this.txtRuaEscola.Name = "txtRuaEscola";
            this.txtRuaEscola.Size = new System.Drawing.Size(250, 20);
            this.txtRuaEscola.TabIndex = 15;
            // 
            // descreveRuaEscola
            // 
            this.descreveRuaEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveRuaEscola.AutoSize = true;
            this.descreveRuaEscola.Location = new System.Drawing.Point(525, 317);
            this.descreveRuaEscola.Name = "descreveRuaEscola";
            this.descreveRuaEscola.Size = new System.Drawing.Size(41, 13);
            this.descreveRuaEscola.TabIndex = 92;
            this.descreveRuaEscola.Text = "Rua(s):";
            // 
            // txtEscola
            // 
            this.txtEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEscola.BackColor = System.Drawing.SystemColors.Window;
            this.txtEscola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEscola.Location = new System.Drawing.Point(588, 282);
            this.txtEscola.Name = "txtEscola";
            this.txtEscola.Size = new System.Drawing.Size(250, 20);
            this.txtEscola.TabIndex = 14;
            // 
            // descreveEscola
            // 
            this.descreveEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveEscola.AutoSize = true;
            this.descreveEscola.Location = new System.Drawing.Point(525, 287);
            this.descreveEscola.Name = "descreveEscola";
            this.descreveEscola.Size = new System.Drawing.Size(53, 13);
            this.descreveEscola.TabIndex = 90;
            this.descreveEscola.Text = "Escola(s):";
            // 
            // txtNomeCrianca
            // 
            this.txtNomeCrianca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNomeCrianca.BackColor = System.Drawing.SystemColors.Window;
            this.txtNomeCrianca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeCrianca.Location = new System.Drawing.Point(588, 252);
            this.txtNomeCrianca.Name = "txtNomeCrianca";
            this.txtNomeCrianca.Size = new System.Drawing.Size(250, 20);
            this.txtNomeCrianca.TabIndex = 13;
            // 
            // descreveCrianca
            // 
            this.descreveCrianca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveCrianca.AutoSize = true;
            this.descreveCrianca.Location = new System.Drawing.Point(525, 257);
            this.descreveCrianca.Name = "descreveCrianca";
            this.descreveCrianca.Size = new System.Drawing.Size(57, 13);
            this.descreveCrianca.TabIndex = 88;
            this.descreveCrianca.Text = "Criança(s):";
            // 
            // TituloDadosServico
            // 
            this.TituloDadosServico.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloDadosServico.AutoSize = true;
            this.TituloDadosServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloDadosServico.Location = new System.Drawing.Point(561, 193);
            this.TituloDadosServico.Name = "TituloDadosServico";
            this.TituloDadosServico.Size = new System.Drawing.Size(198, 25);
            this.TituloDadosServico.TabIndex = 87;
            this.TituloDadosServico.Text = "Dados do Serviço";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 659);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Valor Anual:";
            // 
            // descreveParcela
            // 
            this.descreveParcela.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveParcela.AutoSize = true;
            this.descreveParcela.Location = new System.Drawing.Point(18, 629);
            this.descreveParcela.Name = "descreveParcela";
            this.descreveParcela.Size = new System.Drawing.Size(46, 13);
            this.descreveParcela.TabIndex = 83;
            this.descreveParcela.Text = "Parcela:";
            // 
            // txtValContrato
            // 
            this.txtValContrato.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValContrato.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtValContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtValContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtValContrato.FormattingEnabled = true;
            this.txtValContrato.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.txtValContrato.Location = new System.Drawing.Point(81, 594);
            this.txtValContrato.Name = "txtValContrato";
            this.txtValContrato.Size = new System.Drawing.Size(121, 21);
            this.txtValContrato.TabIndex = 10;
            // 
            // TituloDadosdoContrato
            // 
            this.TituloDadosdoContrato.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloDadosdoContrato.AutoSize = true;
            this.TituloDadosdoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloDadosdoContrato.Location = new System.Drawing.Point(54, 533);
            this.TituloDadosdoContrato.Name = "TituloDadosdoContrato";
            this.TituloDadosdoContrato.Size = new System.Drawing.Size(209, 25);
            this.TituloDadosdoContrato.TabIndex = 81;
            this.TituloDadosdoContrato.Text = "Dados do Contrato";
            // 
            // descreveValContrato
            // 
            this.descreveValContrato.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveValContrato.AutoSize = true;
            this.descreveValContrato.Location = new System.Drawing.Point(18, 599);
            this.descreveValContrato.Name = "descreveValContrato";
            this.descreveValContrato.Size = new System.Drawing.Size(43, 13);
            this.descreveValContrato.TabIndex = 80;
            this.descreveValContrato.Text = "Estado:";
            // 
            // descreveCel
            // 
            this.descreveCel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveCel.AutoSize = true;
            this.descreveCel.Location = new System.Drawing.Point(18, 501);
            this.descreveCel.Name = "descreveCel";
            this.descreveCel.Size = new System.Drawing.Size(42, 13);
            this.descreveCel.TabIndex = 78;
            this.descreveCel.Text = "Celular:";
            // 
            // descreveTelFixo
            // 
            this.descreveTelFixo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveTelFixo.AutoSize = true;
            this.descreveTelFixo.Location = new System.Drawing.Point(18, 471);
            this.descreveTelFixo.Name = "descreveTelFixo";
            this.descreveTelFixo.Size = new System.Drawing.Size(47, 13);
            this.descreveTelFixo.TabIndex = 76;
            this.descreveTelFixo.Text = "Tel Fixo:";
            // 
            // TituloDadosResponsavel
            // 
            this.TituloDadosResponsavel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloDadosResponsavel.AutoSize = true;
            this.TituloDadosResponsavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloDadosResponsavel.Location = new System.Drawing.Point(54, 193);
            this.TituloDadosResponsavel.Name = "TituloDadosResponsavel";
            this.TituloDadosResponsavel.Size = new System.Drawing.Size(242, 25);
            this.TituloDadosResponsavel.TabIndex = 75;
            this.TituloDadosResponsavel.Text = "Dados do Contratante";
            // 
            // descreveCPF
            // 
            this.descreveCPF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveCPF.AutoSize = true;
            this.descreveCPF.Location = new System.Drawing.Point(18, 441);
            this.descreveCPF.Name = "descreveCPF";
            this.descreveCPF.Size = new System.Drawing.Size(30, 13);
            this.descreveCPF.TabIndex = 73;
            this.descreveCPF.Text = "CPF:";
            // 
            // txtRG
            // 
            this.txtRG.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRG.BackColor = System.Drawing.SystemColors.Window;
            this.txtRG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRG.Location = new System.Drawing.Point(81, 374);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(250, 20);
            this.txtRG.TabIndex = 5;
            // 
            // descreveRG
            // 
            this.descreveRG.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveRG.AutoSize = true;
            this.descreveRG.Location = new System.Drawing.Point(18, 381);
            this.descreveRG.Name = "descreveRG";
            this.descreveRG.Size = new System.Drawing.Size(60, 13);
            this.descreveRG.TabIndex = 71;
            this.descreveRG.Text = "Identidade:";
            // 
            // txtBairro
            // 
            this.txtBairro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBairro.BackColor = System.Drawing.SystemColors.Window;
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.Location = new System.Drawing.Point(81, 344);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(250, 20);
            this.txtBairro.TabIndex = 4;
            // 
            // descreveBairro
            // 
            this.descreveBairro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveBairro.AutoSize = true;
            this.descreveBairro.Location = new System.Drawing.Point(18, 351);
            this.descreveBairro.Name = "descreveBairro";
            this.descreveBairro.Size = new System.Drawing.Size(37, 13);
            this.descreveBairro.TabIndex = 69;
            this.descreveBairro.Text = "Bairro:";
            // 
            // txtNumCasa
            // 
            this.txtNumCasa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumCasa.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumCasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumCasa.Location = new System.Drawing.Point(81, 314);
            this.txtNumCasa.Name = "txtNumCasa";
            this.txtNumCasa.Size = new System.Drawing.Size(250, 20);
            this.txtNumCasa.TabIndex = 3;
            // 
            // descreveCasa
            // 
            this.descreveCasa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveCasa.AutoSize = true;
            this.descreveCasa.Location = new System.Drawing.Point(18, 321);
            this.descreveCasa.Name = "descreveCasa";
            this.descreveCasa.Size = new System.Drawing.Size(47, 13);
            this.descreveCasa.TabIndex = 67;
            this.descreveCasa.Text = "Número:";
            // 
            // txtRua
            // 
            this.txtRua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRua.BackColor = System.Drawing.SystemColors.Window;
            this.txtRua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRua.Location = new System.Drawing.Point(81, 284);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(250, 20);
            this.txtRua.TabIndex = 2;
            // 
            // descreveRua
            // 
            this.descreveRua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveRua.AutoSize = true;
            this.descreveRua.Location = new System.Drawing.Point(18, 291);
            this.descreveRua.Name = "descreveRua";
            this.descreveRua.Size = new System.Drawing.Size(30, 13);
            this.descreveRua.TabIndex = 65;
            this.descreveRua.Text = "Rua:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNome.BackColor = System.Drawing.SystemColors.Window;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(81, 254);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(250, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtOrgao
            // 
            this.txtOrgao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOrgao.BackColor = System.Drawing.SystemColors.Window;
            this.txtOrgao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgao.Location = new System.Drawing.Point(81, 404);
            this.txtOrgao.Name = "txtOrgao";
            this.txtOrgao.Size = new System.Drawing.Size(250, 20);
            this.txtOrgao.TabIndex = 6;
            // 
            // descreveOrgao
            // 
            this.descreveOrgao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveOrgao.AutoSize = true;
            this.descreveOrgao.Location = new System.Drawing.Point(18, 411);
            this.descreveOrgao.Name = "descreveOrgao";
            this.descreveOrgao.Size = new System.Drawing.Size(57, 13);
            this.descreveOrgao.TabIndex = 106;
            this.descreveOrgao.Text = "Expedidor:";
            // 
            // descreveEscTel
            // 
            this.descreveEscTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descreveEscTel.AutoSize = true;
            this.descreveEscTel.Location = new System.Drawing.Point(525, 377);
            this.descreveEscTel.Name = "descreveEscTel";
            this.descreveEscTel.Size = new System.Drawing.Size(53, 26);
            this.descreveEscTel.TabIndex = 108;
            this.descreveEscTel.Text = "Tel(s) das\r\nEscolas:";
            // 
            // txtCPF
            // 
            this.txtCPF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPF.Location = new System.Drawing.Point(81, 434);
            this.txtCPF.Mask = "000,000,000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(250, 20);
            this.txtCPF.TabIndex = 7;
            // 
            // txtTelFixo
            // 
            this.txtTelFixo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTelFixo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelFixo.Location = new System.Drawing.Point(81, 464);
            this.txtTelFixo.Mask = "(00)0000-0000";
            this.txtTelFixo.Name = "txtTelFixo";
            this.txtTelFixo.Size = new System.Drawing.Size(250, 20);
            this.txtTelFixo.TabIndex = 8;
            // 
            // txtCel
            // 
            this.txtCel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCel.Location = new System.Drawing.Point(81, 494);
            this.txtCel.Mask = "(00)00000-0000";
            this.txtCel.Name = "txtCel";
            this.txtCel.Size = new System.Drawing.Size(250, 20);
            this.txtCel.TabIndex = 9;
            // 
            // txtEscTel
            // 
            this.txtEscTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEscTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEscTel.Location = new System.Drawing.Point(588, 380);
            this.txtEscTel.Mask = "(00)0000-0000";
            this.txtEscTel.Name = "txtEscTel";
            this.txtEscTel.Size = new System.Drawing.Size(250, 20);
            this.txtEscTel.TabIndex = 17;
            // 
            // txtApanha
            // 
            this.txtApanha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtApanha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApanha.Location = new System.Drawing.Point(588, 505);
            this.txtApanha.Mask = "00:00";
            this.txtApanha.Name = "txtApanha";
            this.txtApanha.Size = new System.Drawing.Size(121, 20);
            this.txtApanha.TabIndex = 18;
            this.txtApanha.ValidatingType = typeof(System.DateTime);
            // 
            // txtEnt
            // 
            this.txtEnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEnt.Location = new System.Drawing.Point(588, 535);
            this.txtEnt.Mask = "00:00";
            this.txtEnt.Name = "txtEnt";
            this.txtEnt.Size = new System.Drawing.Size(121, 20);
            this.txtEnt.TabIndex = 19;
            this.txtEnt.ValidatingType = typeof(System.DateTime);
            // 
            // txtParc
            // 
            this.txtParc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtParc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParc.Location = new System.Drawing.Point(81, 624);
            this.txtParc.Mask = "000.00";
            this.txtParc.Name = "txtParc";
            this.txtParc.Size = new System.Drawing.Size(121, 20);
            this.txtParc.TabIndex = 11;
            // 
            // txtValAnual
            // 
            this.txtValAnual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValAnual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValAnual.Location = new System.Drawing.Point(81, 654);
            this.txtValAnual.Mask = "0,000.00";
            this.txtValAnual.Name = "txtValAnual";
            this.txtValAnual.Size = new System.Drawing.Size(121, 20);
            this.txtValAnual.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 109;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fecharToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // voltarVerCadastros
            // 
            this.voltarVerCadastros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.voltarVerCadastros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.voltarVerCadastros.Image = global::TransRose.Properties.Resources.close_window;
            this.voltarVerCadastros.Location = new System.Drawing.Point(879, 697);
            this.voltarVerCadastros.Name = "voltarVerCadastros";
            this.voltarVerCadastros.Size = new System.Drawing.Size(93, 53);
            this.voltarVerCadastros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.voltarVerCadastros.TabIndex = 105;
            this.voltarVerCadastros.TabStop = false;
            this.voltarVerCadastros.Click += new System.EventHandler(this.voltarVerCadastros_Click);
            // 
            // cadastraCliente
            // 
            this.cadastraCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cadastraCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cadastraCliente.Image = global::TransRose.Properties.Resources.new_row;
            this.cadastraCliente.Location = new System.Drawing.Point(12, 680);
            this.cadastraCliente.Name = "cadastraCliente";
            this.cadastraCliente.Size = new System.Drawing.Size(106, 70);
            this.cadastraCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cadastraCliente.TabIndex = 24;
            this.cadastraCliente.TabStop = false;
            this.cadastraCliente.Click += new System.EventHandler(this.cadastraCliente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::TransRose.Properties.Resources._4_Grayscale_logo_on_transparent_533x75;
            this.pictureBox1.Location = new System.Drawing.Point(451, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = global::TransRose.Properties.Resources.client;
            this.pictureBox3.Location = new System.Drawing.Point(12, 35);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(134, 131);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // excluiCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 762);
            this.Controls.Add(this.txtValAnual);
            this.Controls.Add(this.txtParc);
            this.Controls.Add(this.txtEnt);
            this.Controls.Add(this.txtApanha);
            this.Controls.Add(this.txtEscTel);
            this.Controls.Add(this.txtCel);
            this.Controls.Add(this.txtTelFixo);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.descreveEscTel);
            this.Controls.Add(this.txtOrgao);
            this.Controls.Add(this.descreveOrgao);
            this.Controls.Add(this.voltarVerCadastros);
            this.Controls.Add(this.descreveEntrega);
            this.Controls.Add(this.TituloHorarios);
            this.Controls.Add(this.descreveApanha);
            this.Controls.Add(this.txtBairroEscola);
            this.Controls.Add(this.descreveBairroEscola);
            this.Controls.Add(this.txtRuaEscola);
            this.Controls.Add(this.descreveRuaEscola);
            this.Controls.Add(this.txtEscola);
            this.Controls.Add(this.descreveEscola);
            this.Controls.Add(this.txtNomeCrianca);
            this.Controls.Add(this.descreveCrianca);
            this.Controls.Add(this.TituloDadosServico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descreveParcela);
            this.Controls.Add(this.txtValContrato);
            this.Controls.Add(this.TituloDadosdoContrato);
            this.Controls.Add(this.descreveValContrato);
            this.Controls.Add(this.descreveCel);
            this.Controls.Add(this.descreveTelFixo);
            this.Controls.Add(this.TituloDadosResponsavel);
            this.Controls.Add(this.descreveCPF);
            this.Controls.Add(this.txtRG);
            this.Controls.Add(this.descreveRG);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.descreveBairro);
            this.Controls.Add(this.txtNumCasa);
            this.Controls.Add(this.descreveCasa);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.descreveRua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.cadastraCliente);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "excluiCliente";
            this.Text = "Novo Cliente - Cadastro de Clientes - TransRose";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voltarVerCadastros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cadastraCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LimparCampos()
        {
            try
            {
                foreach (Control control in base.Controls)
                {
                    if (control.GetType() == typeof(ComboBox))
                    {
                        this.txtValContrato.Items.Clear();
                        this.txtValContrato.Items.Add("Sim");
                        this.txtValContrato.Items.Add("N\x00e3o");
                    }
                    if ((control.GetType() == typeof(TextBox)) || (control.GetType() == typeof(MaskedTextBox)))
                    {
                        control.Text = string.Empty;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro: " + exception.Message);
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }

        private void voltarVerCadastros_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        public static string ct
        {
            get; set;
        }

        public static string db
        {
            get; set;
        }

        public static string localizaBanco
        {
            get; set;
        }

        public static string localizaCont
        {
            get; set;
        }
    }
}

