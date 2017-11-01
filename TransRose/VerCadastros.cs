namespace WindowsFormsApplication2
{
    using System;
    using System.ComponentModel;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;
    using TransRose;

    public class VerCadastros : Form
    {
        public static string BuscaCrianca;
        public static string BuscaID;
        public static string BuscaNome;
        private static int idtrat;
        public static string localizaBanco;
        public static string localizaContrato;
        private Button abreContrato;
        private PictureBox anteriorRegistro;
        private PictureBox atualizaCliente;
        private PictureBox buscarRegistro;
        private PictureBox cadastraCliente;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ColorDialog colorDialog1;
        private IContainer components = null;
        private Label lbDescreveApanha;
        private Label lbDescreveBairro;
        private Label lbDescreveBairroEscola;
        private Label lbDescreveCasa;
        private Label lbDescreveCel;
        private Label lbDescreveCPF;
        private Label lbDescreveCrianca;
        private Label lbDescreveEntrega;
        private Label lbDescreveEscola;
        private Label lbDescreveEscTel;
        private Label lbDescreveId;
        private Label lbDescreveNome;
        private Label lbDescreveParcela;
        private Label lbDescreveRG;
        private Label lbDescreveRua;
        private Label lbDescreveRuaEscola;
        private Label lbDescreveTelFixo;
        private Label lbDescreveValContrato;
        private ToolStripMenuItem editToolStripMenuItem;
        private PictureBox excluirRegistro;
        private Label label3;
        private new MenuStrip Menu;
        private NotifyIcon notifyDeleteSucesso;
        private NotifyIcon notifyExecucao;
        private NotifyIcon notifySucesso;
        private PictureBox picLogoTransRose;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox primeiroRegistro;
        private PictureBox proximoRegistro;
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
        private MaskedTextBox txtEntrega;
        private TextBox txtEscola;
        private MaskedTextBox txtEscTel;
        private TextBox txtNome;
        private TextBox txtNomeCrianca;
        private TextBox txtNumCasa;
        private Label txtParcela;
        private TextBox txtRG;
        private TextBox txtRua;
        private TextBox txtRuaEscola;
        private MaskedTextBox txtTelFixo;
        private Label txtTotalAno;
        private ComboBox txtValContrato;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem buscarClienteToolStripMenuItem;
        private ToolStripMenuItem abrirContratoToolStripMenuItem;
        private ToolStripMenuItem excluirBancoDeDadosAtualToolStripMenuItem;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem esteBancoDeDadosToolStripMenuItem;
        private ToolStripMenuItem importarRegistrosToolStripMenuItem;
        private PictureBox ultimoRegistro;
        private static manipulaArquivos contexto;
        public static bool clicouSair;

        public VerCadastros()
        {
            this.InitializeComponent();
        }

        public VerCadastros(manipulaArquivos Contexto, string buscaID, string buscaNome, string buscaCrianca)
        {
            this.InitializeComponent();
            contexto = Contexto;
            localizaBanco = @"C:\Windows\Temp\transrosedb\db" + contexto.ano + ".mdb";
            localizaContrato = @"C:\Windows\Temp\transrosedb\ct" + contexto.ano + ".doc";
            BuscaID = buscaID;
            BuscaNome = buscaNome;
            BuscaCrianca = buscaCrianca;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerCadastros));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbDescreveNome = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirContratoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarRegistrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirBancoDeDadosAtualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esteBancoDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyExecucao = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbDescreveId = new System.Windows.Forms.Label();
            this.notifyDeleteSucesso = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbDescreveRua = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.lbDescreveCasa = new System.Windows.Forms.Label();
            this.txtNumCasa = new System.Windows.Forms.TextBox();
            this.lbDescreveBairro = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lbDescreveRG = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.lbDescreveCPF = new System.Windows.Forms.Label();
            this.TituloDadosResponsavel = new System.Windows.Forms.Label();
            this.lbDescreveTelFixo = new System.Windows.Forms.Label();
            this.lbDescreveCel = new System.Windows.Forms.Label();
            this.lbDescreveValContrato = new System.Windows.Forms.Label();
            this.TituloDadosdoContrato = new System.Windows.Forms.Label();
            this.txtValContrato = new System.Windows.Forms.ComboBox();
            this.lbDescreveParcela = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TituloDadosServico = new System.Windows.Forms.Label();
            this.lbDescreveCrianca = new System.Windows.Forms.Label();
            this.txtNomeCrianca = new System.Windows.Forms.TextBox();
            this.txtEscola = new System.Windows.Forms.TextBox();
            this.lbDescreveEscola = new System.Windows.Forms.Label();
            this.txtRuaEscola = new System.Windows.Forms.TextBox();
            this.lbDescreveRuaEscola = new System.Windows.Forms.Label();
            this.txtBairroEscola = new System.Windows.Forms.TextBox();
            this.lbDescreveBairroEscola = new System.Windows.Forms.Label();
            this.lbDescreveApanha = new System.Windows.Forms.Label();
            this.TituloHorarios = new System.Windows.Forms.Label();
            this.lbDescreveEntrega = new System.Windows.Forms.Label();
            this.abreContrato = new System.Windows.Forms.Button();
            this.txtApanha = new System.Windows.Forms.MaskedTextBox();
            this.txtEntrega = new System.Windows.Forms.MaskedTextBox();
            this.notifySucesso = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtEscTel = new System.Windows.Forms.MaskedTextBox();
            this.lbDescreveEscTel = new System.Windows.Forms.Label();
            this.txtCel = new System.Windows.Forms.MaskedTextBox();
            this.txtTelFixo = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.txtParcela = new System.Windows.Forms.Label();
            this.txtTotalAno = new System.Windows.Forms.Label();
            this.atualizaCliente = new System.Windows.Forms.PictureBox();
            this.buscarRegistro = new System.Windows.Forms.PictureBox();
            this.cadastraCliente = new System.Windows.Forms.PictureBox();
            this.ultimoRegistro = new System.Windows.Forms.PictureBox();
            this.primeiroRegistro = new System.Windows.Forms.PictureBox();
            this.anteriorRegistro = new System.Windows.Forms.PictureBox();
            this.excluirRegistro = new System.Windows.Forms.PictureBox();
            this.proximoRegistro = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picLogoTransRose = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atualizaCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscarRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cadastraCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultimoRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.primeiroRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anteriorRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.excluirRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proximoRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTransRose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNome.BackColor = System.Drawing.SystemColors.Window;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(81, 254);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(250, 20);
            this.txtNome.TabIndex = 2;
            // 
            // lbDescreveNome
            // 
            this.lbDescreveNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveNome.AutoSize = true;
            this.lbDescreveNome.Location = new System.Drawing.Point(18, 257);
            this.lbDescreveNome.Name = "lbDescreveNome";
            this.lbDescreveNome.Size = new System.Drawing.Size(38, 13);
            this.lbDescreveNome.TabIndex = 4;
            this.lbDescreveNome.Text = "Nome:";
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(984, 24);
            this.Menu.TabIndex = 7;
            this.Menu.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.buscarClienteToolStripMenuItem,
            this.abrirContratoToolStripMenuItem,
            this.importarRegistrosToolStripMenuItem,
            this.excluirBancoDeDadosAtualToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.editToolStripMenuItem.Text = "Arquivo";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.cadastrosToolStripMenuItem.Text = "Cadastrar Cliente";
            this.cadastrosToolStripMenuItem.Click += new System.EventHandler(this.cadastraCliente_Click);
            // 
            // buscarClienteToolStripMenuItem
            // 
            this.buscarClienteToolStripMenuItem.Name = "buscarClienteToolStripMenuItem";
            this.buscarClienteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.buscarClienteToolStripMenuItem.Text = "Buscar Cliente";
            this.buscarClienteToolStripMenuItem.Click += new System.EventHandler(this.buscarRegistro_Click);
            // 
            // abrirContratoToolStripMenuItem
            // 
            this.abrirContratoToolStripMenuItem.Name = "abrirContratoToolStripMenuItem";
            this.abrirContratoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.abrirContratoToolStripMenuItem.Text = "Abrir Contrato";
            this.abrirContratoToolStripMenuItem.Click += new System.EventHandler(this.abreContrato_Click);
            // 
            // importarRegistrosToolStripMenuItem
            // 
            this.importarRegistrosToolStripMenuItem.Name = "importarRegistrosToolStripMenuItem";
            this.importarRegistrosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.importarRegistrosToolStripMenuItem.Text = "Importar Registros";
            this.importarRegistrosToolStripMenuItem.Click += new System.EventHandler(this.incluirRegistros);
            // 
            // excluirBancoDeDadosAtualToolStripMenuItem
            // 
            this.excluirBancoDeDadosAtualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.esteBancoDeDadosToolStripMenuItem});
            this.excluirBancoDeDadosAtualToolStripMenuItem.Name = "excluirBancoDeDadosAtualToolStripMenuItem";
            this.excluirBancoDeDadosAtualToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.excluirBancoDeDadosAtualToolStripMenuItem.Text = "Excluir";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.clienteToolStripMenuItem.Text = "Este Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.excluirRegistro_Click);
            // 
            // esteBancoDeDadosToolStripMenuItem
            // 
            this.esteBancoDeDadosToolStripMenuItem.Name = "esteBancoDeDadosToolStripMenuItem";
            this.esteBancoDeDadosToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.esteBancoDeDadosToolStripMenuItem.Text = "Este Banco de Dados";
            this.esteBancoDeDadosToolStripMenuItem.Click += new System.EventHandler(this.excluiBanco);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // notifyExecucao
            // 
            this.notifyExecucao.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyExecucao.BalloonTipText = "Cadastro de Clientes - TransRose ainda em execução";
            this.notifyExecucao.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyExecucao.Icon")));
            this.notifyExecucao.Text = "Cadastro de Clientes TransRose em Execução";
            this.notifyExecucao.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyCadastro_MouseDoubleClick);
            // 
            // lbDescreveId
            // 
            this.lbDescreveId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveId.AutoSize = true;
            this.lbDescreveId.Location = new System.Drawing.Point(160, 46);
            this.lbDescreveId.Name = "lbDescreveId";
            this.lbDescreveId.Size = new System.Drawing.Size(25, 13);
            this.lbDescreveId.TabIndex = 1;
            this.lbDescreveId.Text = "#ID";
            // 
            // notifyDeleteSucesso
            // 
            this.notifyDeleteSucesso.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyDeleteSucesso.BalloonTipText = "Cliente deletado com sucesso";
            this.notifyDeleteSucesso.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyDeleteSucesso.Icon")));
            // 
            // lbDescreveRua
            // 
            this.lbDescreveRua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveRua.AutoSize = true;
            this.lbDescreveRua.Location = new System.Drawing.Point(18, 291);
            this.lbDescreveRua.Name = "lbDescreveRua";
            this.lbDescreveRua.Size = new System.Drawing.Size(30, 13);
            this.lbDescreveRua.TabIndex = 24;
            this.lbDescreveRua.Text = "Rua:";
            // 
            // txtRua
            // 
            this.txtRua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRua.BackColor = System.Drawing.SystemColors.Window;
            this.txtRua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRua.Location = new System.Drawing.Point(81, 286);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(250, 20);
            this.txtRua.TabIndex = 25;
            // 
            // lbDescreveCasa
            // 
            this.lbDescreveCasa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveCasa.AutoSize = true;
            this.lbDescreveCasa.Location = new System.Drawing.Point(18, 321);
            this.lbDescreveCasa.Name = "lbDescreveCasa";
            this.lbDescreveCasa.Size = new System.Drawing.Size(47, 13);
            this.lbDescreveCasa.TabIndex = 26;
            this.lbDescreveCasa.Text = "Número:";
            // 
            // txtNumCasa
            // 
            this.txtNumCasa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumCasa.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumCasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumCasa.Location = new System.Drawing.Point(81, 316);
            this.txtNumCasa.Name = "txtNumCasa";
            this.txtNumCasa.Size = new System.Drawing.Size(250, 20);
            this.txtNumCasa.TabIndex = 27;
            // 
            // lbDescreveBairro
            // 
            this.lbDescreveBairro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveBairro.AutoSize = true;
            this.lbDescreveBairro.Location = new System.Drawing.Point(18, 351);
            this.lbDescreveBairro.Name = "lbDescreveBairro";
            this.lbDescreveBairro.Size = new System.Drawing.Size(37, 13);
            this.lbDescreveBairro.TabIndex = 28;
            this.lbDescreveBairro.Text = "Bairro:";
            // 
            // txtBairro
            // 
            this.txtBairro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBairro.BackColor = System.Drawing.SystemColors.Window;
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.Location = new System.Drawing.Point(81, 346);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(250, 20);
            this.txtBairro.TabIndex = 29;
            // 
            // lbDescreveRG
            // 
            this.lbDescreveRG.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveRG.AutoSize = true;
            this.lbDescreveRG.Location = new System.Drawing.Point(18, 381);
            this.lbDescreveRG.Name = "lbDescreveRG";
            this.lbDescreveRG.Size = new System.Drawing.Size(60, 13);
            this.lbDescreveRG.TabIndex = 30;
            this.lbDescreveRG.Text = "Identidade:";
            // 
            // txtRG
            // 
            this.txtRG.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRG.BackColor = System.Drawing.SystemColors.Window;
            this.txtRG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRG.Location = new System.Drawing.Point(81, 376);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(250, 20);
            this.txtRG.TabIndex = 31;
            // 
            // lbDescreveCPF
            // 
            this.lbDescreveCPF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveCPF.AutoSize = true;
            this.lbDescreveCPF.Location = new System.Drawing.Point(18, 411);
            this.lbDescreveCPF.Name = "lbDescreveCPF";
            this.lbDescreveCPF.Size = new System.Drawing.Size(30, 13);
            this.lbDescreveCPF.TabIndex = 32;
            this.lbDescreveCPF.Text = "CPF:";
            // 
            // TituloDadosResponsavel
            // 
            this.TituloDadosResponsavel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloDadosResponsavel.AutoSize = true;
            this.TituloDadosResponsavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloDadosResponsavel.Location = new System.Drawing.Point(54, 193);
            this.TituloDadosResponsavel.Name = "TituloDadosResponsavel";
            this.TituloDadosResponsavel.Size = new System.Drawing.Size(242, 25);
            this.TituloDadosResponsavel.TabIndex = 34;
            this.TituloDadosResponsavel.Text = "Dados do Contratante";
            // 
            // lbDescreveTelFixo
            // 
            this.lbDescreveTelFixo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveTelFixo.AutoSize = true;
            this.lbDescreveTelFixo.Location = new System.Drawing.Point(18, 441);
            this.lbDescreveTelFixo.Name = "lbDescreveTelFixo";
            this.lbDescreveTelFixo.Size = new System.Drawing.Size(47, 13);
            this.lbDescreveTelFixo.TabIndex = 35;
            this.lbDescreveTelFixo.Text = "Tel Fixo:";
            // 
            // lbDescreveCel
            // 
            this.lbDescreveCel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveCel.AutoSize = true;
            this.lbDescreveCel.Location = new System.Drawing.Point(18, 471);
            this.lbDescreveCel.Name = "lbDescreveCel";
            this.lbDescreveCel.Size = new System.Drawing.Size(42, 13);
            this.lbDescreveCel.TabIndex = 37;
            this.lbDescreveCel.Text = "Celular:";
            // 
            // lbDescreveValContrato
            // 
            this.lbDescreveValContrato.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveValContrato.AutoSize = true;
            this.lbDescreveValContrato.Location = new System.Drawing.Point(18, 599);
            this.lbDescreveValContrato.Name = "lbDescreveValContrato";
            this.lbDescreveValContrato.Size = new System.Drawing.Size(43, 13);
            this.lbDescreveValContrato.TabIndex = 39;
            this.lbDescreveValContrato.Text = "Estado:";
            // 
            // TituloDadosdoContrato
            // 
            this.TituloDadosdoContrato.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloDadosdoContrato.AutoSize = true;
            this.TituloDadosdoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloDadosdoContrato.Location = new System.Drawing.Point(54, 533);
            this.TituloDadosdoContrato.Name = "TituloDadosdoContrato";
            this.TituloDadosdoContrato.Size = new System.Drawing.Size(209, 25);
            this.TituloDadosdoContrato.TabIndex = 41;
            this.TituloDadosdoContrato.Text = "Dados do Contrato";
            // 
            // txtValContrato
            // 
            this.txtValContrato.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValContrato.AutoCompleteCustomSource.AddRange(new string[] {
            "Ativo",
            "Inativo"});
            this.txtValContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtValContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtValContrato.FormattingEnabled = true;
            this.txtValContrato.Location = new System.Drawing.Point(81, 594);
            this.txtValContrato.Name = "txtValContrato";
            this.txtValContrato.Size = new System.Drawing.Size(121, 21);
            this.txtValContrato.TabIndex = 35;
            // 
            // lbDescreveParcela
            // 
            this.lbDescreveParcela.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveParcela.AutoSize = true;
            this.lbDescreveParcela.Location = new System.Drawing.Point(18, 629);
            this.lbDescreveParcela.Name = "lbDescreveParcela";
            this.lbDescreveParcela.Size = new System.Drawing.Size(46, 13);
            this.lbDescreveParcela.TabIndex = 43;
            this.lbDescreveParcela.Text = "Parcela:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 659);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Valor Anual:";
            // 
            // TituloDadosServico
            // 
            this.TituloDadosServico.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloDadosServico.AutoSize = true;
            this.TituloDadosServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloDadosServico.Location = new System.Drawing.Point(561, 193);
            this.TituloDadosServico.Name = "TituloDadosServico";
            this.TituloDadosServico.Size = new System.Drawing.Size(198, 25);
            this.TituloDadosServico.TabIndex = 48;
            this.TituloDadosServico.Text = "Dados do Serviço";
            // 
            // lbDescreveCrianca
            // 
            this.lbDescreveCrianca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveCrianca.AutoSize = true;
            this.lbDescreveCrianca.Location = new System.Drawing.Point(525, 257);
            this.lbDescreveCrianca.Name = "lbDescreveCrianca";
            this.lbDescreveCrianca.Size = new System.Drawing.Size(57, 13);
            this.lbDescreveCrianca.TabIndex = 49;
            this.lbDescreveCrianca.Text = "Criança(s):";
            // 
            // txtNomeCrianca
            // 
            this.txtNomeCrianca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNomeCrianca.BackColor = System.Drawing.SystemColors.Window;
            this.txtNomeCrianca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeCrianca.Location = new System.Drawing.Point(588, 252);
            this.txtNomeCrianca.Name = "txtNomeCrianca";
            this.txtNomeCrianca.Size = new System.Drawing.Size(250, 20);
            this.txtNomeCrianca.TabIndex = 36;
            // 
            // txtEscola
            // 
            this.txtEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEscola.BackColor = System.Drawing.SystemColors.Window;
            this.txtEscola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEscola.Location = new System.Drawing.Point(588, 282);
            this.txtEscola.Name = "txtEscola";
            this.txtEscola.Size = new System.Drawing.Size(250, 20);
            this.txtEscola.TabIndex = 37;
            // 
            // lbDescreveEscola
            // 
            this.lbDescreveEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveEscola.AutoSize = true;
            this.lbDescreveEscola.Location = new System.Drawing.Point(525, 287);
            this.lbDescreveEscola.Name = "lbDescreveEscola";
            this.lbDescreveEscola.Size = new System.Drawing.Size(53, 13);
            this.lbDescreveEscola.TabIndex = 51;
            this.lbDescreveEscola.Text = "Escola(s):";
            // 
            // txtRuaEscola
            // 
            this.txtRuaEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRuaEscola.BackColor = System.Drawing.SystemColors.Window;
            this.txtRuaEscola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuaEscola.Location = new System.Drawing.Point(588, 312);
            this.txtRuaEscola.Name = "txtRuaEscola";
            this.txtRuaEscola.Size = new System.Drawing.Size(250, 20);
            this.txtRuaEscola.TabIndex = 38;
            // 
            // lbDescreveRuaEscola
            // 
            this.lbDescreveRuaEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveRuaEscola.AutoSize = true;
            this.lbDescreveRuaEscola.Location = new System.Drawing.Point(525, 317);
            this.lbDescreveRuaEscola.Name = "lbDescreveRuaEscola";
            this.lbDescreveRuaEscola.Size = new System.Drawing.Size(41, 13);
            this.lbDescreveRuaEscola.TabIndex = 53;
            this.lbDescreveRuaEscola.Text = "Rua(s):";
            // 
            // txtBairroEscola
            // 
            this.txtBairroEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBairroEscola.BackColor = System.Drawing.SystemColors.Window;
            this.txtBairroEscola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairroEscola.Location = new System.Drawing.Point(588, 342);
            this.txtBairroEscola.Name = "txtBairroEscola";
            this.txtBairroEscola.Size = new System.Drawing.Size(250, 20);
            this.txtBairroEscola.TabIndex = 39;
            // 
            // lbDescreveBairroEscola
            // 
            this.lbDescreveBairroEscola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveBairroEscola.AutoSize = true;
            this.lbDescreveBairroEscola.Location = new System.Drawing.Point(525, 347);
            this.lbDescreveBairroEscola.Name = "lbDescreveBairroEscola";
            this.lbDescreveBairroEscola.Size = new System.Drawing.Size(48, 13);
            this.lbDescreveBairroEscola.TabIndex = 55;
            this.lbDescreveBairroEscola.Text = "Bairro(s):";
            // 
            // lbDescreveApanha
            // 
            this.lbDescreveApanha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveApanha.AutoSize = true;
            this.lbDescreveApanha.Location = new System.Drawing.Point(525, 508);
            this.lbDescreveApanha.Name = "lbDescreveApanha";
            this.lbDescreveApanha.Size = new System.Drawing.Size(47, 13);
            this.lbDescreveApanha.TabIndex = 57;
            this.lbDescreveApanha.Text = "Apanha:";
            // 
            // TituloHorarios
            // 
            this.TituloHorarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TituloHorarios.AutoSize = true;
            this.TituloHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloHorarios.Location = new System.Drawing.Point(600, 444);
            this.TituloHorarios.Name = "TituloHorarios";
            this.TituloHorarios.Size = new System.Drawing.Size(101, 25);
            this.TituloHorarios.TabIndex = 59;
            this.TituloHorarios.Text = "Horários";
            // 
            // lbDescreveEntrega
            // 
            this.lbDescreveEntrega.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveEntrega.AutoSize = true;
            this.lbDescreveEntrega.Location = new System.Drawing.Point(525, 538);
            this.lbDescreveEntrega.Name = "lbDescreveEntrega";
            this.lbDescreveEntrega.Size = new System.Drawing.Size(47, 13);
            this.lbDescreveEntrega.TabIndex = 62;
            this.lbDescreveEntrega.Text = "Entrega:";
            // 
            // abreContrato
            // 
            this.abreContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.abreContrato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.abreContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abreContrato.Location = new System.Drawing.Point(50, 720);
            this.abreContrato.Name = "abreContrato";
            this.abreContrato.Size = new System.Drawing.Size(114, 30);
            this.abreContrato.TabIndex = 63;
            this.abreContrato.Text = "Abrir Contrato";
            this.abreContrato.UseVisualStyleBackColor = true;
            this.abreContrato.Click += new System.EventHandler(this.abreContrato_Click);
            // 
            // txtApanha
            // 
            this.txtApanha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtApanha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApanha.Location = new System.Drawing.Point(588, 505);
            this.txtApanha.Mask = "00:00";
            this.txtApanha.Name = "txtApanha";
            this.txtApanha.Size = new System.Drawing.Size(121, 20);
            this.txtApanha.TabIndex = 41;
            this.txtApanha.ValidatingType = typeof(System.DateTime);
            // 
            // txtEntrega
            // 
            this.txtEntrega.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntrega.Location = new System.Drawing.Point(588, 535);
            this.txtEntrega.Mask = "00:00";
            this.txtEntrega.Name = "txtEntrega";
            this.txtEntrega.Size = new System.Drawing.Size(121, 20);
            this.txtEntrega.TabIndex = 42;
            this.txtEntrega.ValidatingType = typeof(System.DateTime);
            // 
            // notifySucesso
            // 
            this.notifySucesso.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifySucesso.BalloonTipText = "Cliente atualizado";
            this.notifySucesso.Icon = ((System.Drawing.Icon)(resources.GetObject("notifySucesso.Icon")));
            // 
            // txtEscTel
            // 
            this.txtEscTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEscTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEscTel.Location = new System.Drawing.Point(588, 380);
            this.txtEscTel.Mask = "(00)0000-0000";
            this.txtEscTel.Name = "txtEscTel";
            this.txtEscTel.Size = new System.Drawing.Size(250, 20);
            this.txtEscTel.TabIndex = 40;
            // 
            // lbDescreveEscTel
            // 
            this.lbDescreveEscTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescreveEscTel.AutoSize = true;
            this.lbDescreveEscTel.Location = new System.Drawing.Point(525, 377);
            this.lbDescreveEscTel.Name = "lbDescreveEscTel";
            this.lbDescreveEscTel.Size = new System.Drawing.Size(53, 26);
            this.lbDescreveEscTel.TabIndex = 110;
            this.lbDescreveEscTel.Text = "Tel(s) das\r\nEscolas:";
            // 
            // txtCel
            // 
            this.txtCel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCel.Location = new System.Drawing.Point(81, 466);
            this.txtCel.Mask = "(00)00000-0000";
            this.txtCel.Name = "txtCel";
            this.txtCel.Size = new System.Drawing.Size(250, 20);
            this.txtCel.TabIndex = 34;
            // 
            // txtTelFixo
            // 
            this.txtTelFixo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTelFixo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelFixo.Location = new System.Drawing.Point(81, 436);
            this.txtTelFixo.Mask = "(00)0000-0000";
            this.txtTelFixo.Name = "txtTelFixo";
            this.txtTelFixo.Size = new System.Drawing.Size(250, 20);
            this.txtTelFixo.TabIndex = 33;
            // 
            // txtCPF
            // 
            this.txtCPF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPF.Location = new System.Drawing.Point(81, 406);
            this.txtCPF.Mask = "000,000,000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(250, 20);
            this.txtCPF.TabIndex = 32;
            // 
            // txtParcela
            // 
            this.txtParcela.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtParcela.AutoSize = true;
            this.txtParcela.Location = new System.Drawing.Point(81, 629);
            this.txtParcela.Name = "txtParcela";
            this.txtParcela.Size = new System.Drawing.Size(61, 13);
            this.txtParcela.TabIndex = 45;
            this.txtParcela.Text = "#txtParcela";
            // 
            // txtTotalAno
            // 
            this.txtTotalAno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalAno.AutoSize = true;
            this.txtTotalAno.Location = new System.Drawing.Point(81, 659);
            this.txtTotalAno.Name = "txtTotalAno";
            this.txtTotalAno.Size = new System.Drawing.Size(68, 13);
            this.txtTotalAno.TabIndex = 47;
            this.txtTotalAno.Text = "#txtTotalAno";
            // 
            // atualizaCliente
            // 
            this.atualizaCliente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.atualizaCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.atualizaCliente.Image = global::TransRose.Properties.Resources.modify_row;
            this.atualizaCliente.Location = new System.Drawing.Point(305, 670);
            this.atualizaCliente.Name = "atualizaCliente";
            this.atualizaCliente.Size = new System.Drawing.Size(103, 85);
            this.atualizaCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.atualizaCliente.TabIndex = 111;
            this.atualizaCliente.TabStop = false;
            this.atualizaCliente.Click += new System.EventHandler(this.atualizaCliente_Click);
            // 
            // buscarRegistro
            // 
            this.buscarRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buscarRegistro.Image = global::TransRose.Properties.Resources.seek_row;
            this.buscarRegistro.Location = new System.Drawing.Point(872, 670);
            this.buscarRegistro.Name = "buscarRegistro";
            this.buscarRegistro.Size = new System.Drawing.Size(103, 85);
            this.buscarRegistro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buscarRegistro.TabIndex = 0;
            this.buscarRegistro.TabStop = false;
            this.buscarRegistro.Click += new System.EventHandler(this.buscarRegistro_Click);
            // 
            // cadastraCliente
            // 
            this.cadastraCliente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cadastraCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cadastraCliente.Image = global::TransRose.Properties.Resources.new_row;
            this.cadastraCliente.Location = new System.Drawing.Point(200, 670);
            this.cadastraCliente.Name = "cadastraCliente";
            this.cadastraCliente.Size = new System.Drawing.Size(99, 85);
            this.cadastraCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cadastraCliente.TabIndex = 23;
            this.cadastraCliente.TabStop = false;
            this.cadastraCliente.Click += new System.EventHandler(this.cadastraCliente_Click);
            // 
            // ultimoRegistro
            // 
            this.ultimoRegistro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ultimoRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ultimoRegistro.Image = global::TransRose.Properties.Resources.last_row;
            this.ultimoRegistro.Location = new System.Drawing.Point(694, 711);
            this.ultimoRegistro.Name = "ultimoRegistro";
            this.ultimoRegistro.Size = new System.Drawing.Size(83, 44);
            this.ultimoRegistro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ultimoRegistro.TabIndex = 22;
            this.ultimoRegistro.TabStop = false;
            this.ultimoRegistro.Click += new System.EventHandler(this.ultimoRegistro_Click);
            // 
            // primeiroRegistro
            // 
            this.primeiroRegistro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.primeiroRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.primeiroRegistro.Image = global::TransRose.Properties.Resources.first_row;
            this.primeiroRegistro.Location = new System.Drawing.Point(427, 706);
            this.primeiroRegistro.Name = "primeiroRegistro";
            this.primeiroRegistro.Size = new System.Drawing.Size(83, 44);
            this.primeiroRegistro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.primeiroRegistro.TabIndex = 21;
            this.primeiroRegistro.TabStop = false;
            this.primeiroRegistro.Click += new System.EventHandler(this.primeiroRegistro_Click);
            // 
            // anteriorRegistro
            // 
            this.anteriorRegistro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.anteriorRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.anteriorRegistro.Image = global::TransRose.Properties.Resources.previous_row;
            this.anteriorRegistro.Location = new System.Drawing.Point(516, 711);
            this.anteriorRegistro.Name = "anteriorRegistro";
            this.anteriorRegistro.Size = new System.Drawing.Size(83, 44);
            this.anteriorRegistro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.anteriorRegistro.TabIndex = 18;
            this.anteriorRegistro.TabStop = false;
            this.anteriorRegistro.Click += new System.EventHandler(this.anteriorRegistro_Click);
            // 
            // excluirRegistro
            // 
            this.excluirRegistro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.excluirRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.excluirRegistro.Image = global::TransRose.Properties.Resources.delete_row;
            this.excluirRegistro.Location = new System.Drawing.Point(783, 706);
            this.excluirRegistro.Name = "excluirRegistro";
            this.excluirRegistro.Size = new System.Drawing.Size(83, 44);
            this.excluirRegistro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.excluirRegistro.TabIndex = 17;
            this.excluirRegistro.TabStop = false;
            this.excluirRegistro.Click += new System.EventHandler(this.excluirRegistro_Click);
            // 
            // proximoRegistro
            // 
            this.proximoRegistro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.proximoRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.proximoRegistro.Image = global::TransRose.Properties.Resources.next_row;
            this.proximoRegistro.Location = new System.Drawing.Point(605, 711);
            this.proximoRegistro.Name = "proximoRegistro";
            this.proximoRegistro.Size = new System.Drawing.Size(83, 44);
            this.proximoRegistro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.proximoRegistro.TabIndex = 14;
            this.proximoRegistro.TabStop = false;
            this.proximoRegistro.Click += new System.EventHandler(this.proximoRegistro_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::TransRose.Properties.Resources.client;
            this.pictureBox2.Location = new System.Drawing.Point(12, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 131);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // picLogoTransRose
            // 
            this.picLogoTransRose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogoTransRose.Image = ((System.Drawing.Image)(resources.GetObject("picLogoTransRose.Image")));
            this.picLogoTransRose.InitialImage = ((System.Drawing.Image)(resources.GetObject("picLogoTransRose.InitialImage")));
            this.picLogoTransRose.Location = new System.Drawing.Point(451, 35);
            this.picLogoTransRose.Name = "picLogoTransRose";
            this.picLogoTransRose.Size = new System.Drawing.Size(457, 102);
            this.picLogoTransRose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoTransRose.TabIndex = 12;
            this.picLogoTransRose.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(473, 427);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(46, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // VerCadastros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(984, 762);
            this.Controls.Add(this.txtTotalAno);
            this.Controls.Add(this.txtParcela);
            this.Controls.Add(this.atualizaCliente);
            this.Controls.Add(this.txtCel);
            this.Controls.Add(this.txtTelFixo);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtEscTel);
            this.Controls.Add(this.lbDescreveEscTel);
            this.Controls.Add(this.txtEntrega);
            this.Controls.Add(this.txtApanha);
            this.Controls.Add(this.abreContrato);
            this.Controls.Add(this.buscarRegistro);
            this.Controls.Add(this.lbDescreveEntrega);
            this.Controls.Add(this.TituloHorarios);
            this.Controls.Add(this.lbDescreveApanha);
            this.Controls.Add(this.txtBairroEscola);
            this.Controls.Add(this.lbDescreveBairroEscola);
            this.Controls.Add(this.txtRuaEscola);
            this.Controls.Add(this.lbDescreveRuaEscola);
            this.Controls.Add(this.txtEscola);
            this.Controls.Add(this.lbDescreveEscola);
            this.Controls.Add(this.txtNomeCrianca);
            this.Controls.Add(this.lbDescreveCrianca);
            this.Controls.Add(this.TituloDadosServico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbDescreveParcela);
            this.Controls.Add(this.txtValContrato);
            this.Controls.Add(this.TituloDadosdoContrato);
            this.Controls.Add(this.lbDescreveValContrato);
            this.Controls.Add(this.lbDescreveCel);
            this.Controls.Add(this.lbDescreveTelFixo);
            this.Controls.Add(this.TituloDadosResponsavel);
            this.Controls.Add(this.lbDescreveCPF);
            this.Controls.Add(this.txtRG);
            this.Controls.Add(this.lbDescreveRG);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.lbDescreveBairro);
            this.Controls.Add(this.txtNumCasa);
            this.Controls.Add(this.lbDescreveCasa);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.lbDescreveRua);
            this.Controls.Add(this.cadastraCliente);
            this.Controls.Add(this.ultimoRegistro);
            this.Controls.Add(this.primeiroRegistro);
            this.Controls.Add(this.anteriorRegistro);
            this.Controls.Add(this.excluirRegistro);
            this.Controls.Add(this.proximoRegistro);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.picLogoTransRose);
            this.Controls.Add(this.lbDescreveNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lbDescreveId);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "VerCadastros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes - Cadastro de Clientes TransRose";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerCadastros_FormClosing);
            this.Load += new System.EventHandler(this.VerCadastros_Load);
            this.Resize += new System.EventHandler(this.VerCadastros_Resize);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atualizaCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscarRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cadastraCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultimoRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.primeiroRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anteriorRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.excluirRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proximoRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTransRose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void abreContrato_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(localizaContrato);
            }
            catch (OleDbException exception)
            {
                MessageBox.Show("Erro: Não foi possível abrir o contrato do cliente, contate o administrador da aplicação." + exception.Message);
            }
        }

        private void proximoRegistro_Click(object sender, EventArgs e)
        {
            if (this.lbDescreveId.Text == "#ID")
            {
                MessageBox.Show("Nenhum cliente cadastrado no banco de dados, por favor, cadastre um cliente para visualizá-lo", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + localizaBanco + "'";
                string cmdText = "SELECT TOP 1 * FROM Cadastros WHERE ID > " + Convert.ToInt32(this.lbDescreveId.Text) + " order by ID ASC";
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand command = new OleDbCommand(cmdText, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        lbDescreveId.Text = Convert.ToInt32(reader["ID"]).ToString();
                        txtNome.Text = reader["Nome"].ToString();
                        txtRua.Text = reader["Rua"].ToString();
                        txtNumCasa.Text = reader["NumCasa"].ToString();
                        txtBairro.Text = reader["Bairro"].ToString();
                        txtRG.Text = reader["RG"].ToString();
                        txtCPF.Text = reader["CPF"].ToString();
                        txtTelFixo.Text = reader["Telefone Fixo"].ToString();
                        txtCel.Text = reader["Celular"].ToString();
                        txtValContrato.Items.Add(reader["Contrato"].ToString());
                        txtValContrato.SelectedItem = reader["Contrato"].ToString();
                        txtParcela.Text = "R$" + reader["Parcela"] + " Reais".ToString();
                        txtTotalAno.Text = "R$" + reader["Valor Anual"] + " Reais".ToString();
                        txtNomeCrianca.Text = reader["Criança"].ToString();
                        txtEscola.Text = reader["Nome da escola"].ToString();
                        txtRuaEscola.Text = reader["Rua da escola"].ToString();
                        txtBairroEscola.Text = reader["Bairro da escola"].ToString();
                        txtEscTel.Text = reader["Telefone da escola"].ToString();
                        txtApanha.Text = reader["Apanha"] + " Hrs.".ToString();
                        txtEntrega.Text = reader["Entrega"] + " Hrs.".ToString();
                        if (txtValContrato.SelectedItem.ToString() == "True")
                        {
                            txtValContrato.Items.Clear();
                            txtValContrato.Items.Add("Ativo");
                            txtValContrato.Items.Add("Inativo");
                            txtValContrato.SelectedItem = "Ativo";
                        }
                        else
                        {
                            this.txtValContrato.Items.Clear();
                            this.txtValContrato.Items.Add("Ativo");
                            this.txtValContrato.Items.Add("Inativo");
                            this.txtValContrato.SelectedItem = "Inativo";
                        }
                    }
                }
                catch (OleDbException exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                }
            }
        }

        private void anteriorRegistro_Click(object sender, EventArgs e)
        {
            if (this.lbDescreveId.Text == "#ID")
            {
                MessageBox.Show("Nenhum cliente cadastrado no banco de dados, por favor, cadastre um cliente para usar esta função", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + localizaBanco + "'";
                string cmdText = "SELECT TOP 1 * FROM Cadastros WHERE ID < " + Convert.ToInt32(this.lbDescreveId.Text) + " order by ID DESC";
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand command = new OleDbCommand(cmdText, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        this.lbDescreveId.Text = Convert.ToInt32(reader["ID"]).ToString();
                        this.txtNome.Text = reader["Nome"].ToString();
                        this.txtRua.Text = reader["Rua"].ToString();
                        this.txtNumCasa.Text = reader["NumCasa"].ToString();
                        this.txtBairro.Text = reader["Bairro"].ToString();
                        this.txtRG.Text = reader["RG"].ToString();
                        this.txtCPF.Text = reader["CPF"].ToString();
                        this.txtTelFixo.Text = reader["Telefone Fixo"].ToString();
                        this.txtCel.Text = reader["Celular"].ToString();
                        this.txtValContrato.Items.Add(reader["Contrato"].ToString());
                        this.txtValContrato.SelectedItem = reader["Contrato"].ToString();
                        this.txtParcela.Text = "R$" + reader["Parcela"] + " Reais".ToString();
                        this.txtTotalAno.Text = "R$" + reader["Valor Anual"] + " Reais".ToString();
                        this.txtNomeCrianca.Text = reader["Criança"].ToString();
                        this.txtEscola.Text = reader["Nome da escola"].ToString();
                        this.txtRuaEscola.Text = reader["Rua da escola"].ToString();
                        this.txtBairroEscola.Text = reader["Bairro da escola"].ToString();
                        this.txtEscTel.Text = reader["Telefone da escola"].ToString();
                        this.txtApanha.Text = reader["Apanha"] + " Hrs.".ToString();
                        this.txtEntrega.Text = reader["Entrega"] + " Hrs.".ToString();
                        if (this.txtValContrato.SelectedItem.ToString() == "True")
                        {
                            this.txtValContrato.Items.Clear();
                            this.txtValContrato.Items.Add("Ativo");
                            this.txtValContrato.SelectedItem = "Ativo";
                        }
                        else
                        {
                            this.txtValContrato.Items.Clear();
                            this.txtValContrato.Items.Add("Inativo");
                            this.txtValContrato.SelectedItem = "Inativo";
                        }
                    }
                }
                catch (OleDbException exception)
                {
                    MessageBox.Show("Error: " + exception.Message);
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                }
            }
        }

        private void atualizaCliente_Click(object sender, EventArgs e)
        {
            if(lbDescreveId.Text == "#ID")
            {
                MessageBox.Show("Nenhum cliente cadastrado no banco de dados!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                idtrat = Convert.ToInt32(lbDescreveId.Text);
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
                object[] objArray1 = new object[] {
                "UPDATE Cadastros SET Nome = '", txtNome.Text, "',Rua = '", txtRua.Text, "',Contrato = ", flag.ToString(), ",CPF = '", txtCPF.Text, "',RG = '", txtRG.Text, "',NumCasa = '", txtNumCasa.Text, "', Bairro = '", txtBairro.Text, "',[Telefone Fixo] = '", txtTelFixo.Text,
                "',Celular = '", txtCel.Text, "',Criança = '", txtNomeCrianca.Text, "',[Nome da escola] = '", txtEscola.Text, "', [Rua da escola] = '", txtRuaEscola.Text, "',[Bairro da escola] = '", txtBairroEscola.Text, "',[Telefone da escola] = '", txtEscTel.Text, "',Apanha = '", txtApanha.Text, "', Entrega = '", txtEntrega.Text,
                "' WHERE ID = ", idtrat
                };
                string cmdText = string.Concat(objArray1);
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand command = new OleDbCommand(cmdText, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    this.notifySucesso.Visible = true;
                    this.notifySucesso.ShowBalloonTip(5);
                    MessageBox.Show("Cliente atualizado com sucesso.");
                    Thread.Sleep(0x7d0);
                    this.notifySucesso.Visible = false;
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

        public void buscarRegistro_Click(object sender, EventArgs e)
        {
            new buscaClientes(this).Show();
        }

        private void cadastraCliente_Click(object sender, EventArgs e)
        {
            new novoCliente().Show();
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        public void CarregaDados()
        {
            if (((BuscaID.ToString() == "") & (BuscaNome == "")) & (BuscaCrianca == ""))
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + localizaBanco + "'";
                string cmdText = "SELECT *FROM Cadastros WHERE ID IS NOT NULL order by ID ASC";
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand command = new OleDbCommand(cmdText, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        this.lbDescreveId.Text = Convert.ToInt32(reader["ID"]).ToString();
                        this.txtNome.Text = reader["Nome"].ToString();
                        this.txtRua.Text = reader["Rua"].ToString();
                        this.txtNumCasa.Text = reader["NumCasa"].ToString();
                        this.txtBairro.Text = reader["Bairro"].ToString();
                        this.txtRG.Text = reader["RG"].ToString();
                        this.txtCPF.Text = reader["CPF"].ToString();
                        this.txtTelFixo.Text = reader["Telefone Fixo"].ToString();
                        this.txtCel.Text = reader["Celular"].ToString();
                        this.txtValContrato.Items.Add(reader["Contrato"].ToString());
                        this.txtValContrato.SelectedItem = reader["Contrato"].ToString();
                        this.txtParcela.Text = "R$" + reader["Parcela"] + " Reais".ToString();
                        this.txtTotalAno.Text = "R$" + reader["Valor Anual"] + " Reais".ToString();
                        this.txtNomeCrianca.Text = reader["Criança"].ToString();
                        this.txtEscola.Text = reader["Nome da escola"].ToString();
                        this.txtRuaEscola.Text = reader["Rua da escola"].ToString();
                        this.txtBairroEscola.Text = reader["Bairro da escola"].ToString();
                        this.txtEscTel.Text = reader["Telefone da escola"].ToString();
                        this.txtApanha.Text = reader["Apanha"] + " Hrs.".ToString();
                        this.txtEntrega.Text = reader["Entrega"] + " Hrs.".ToString();
                        if (this.txtValContrato.SelectedItem.ToString() == "True")
                        {
                            this.txtValContrato.Items.Clear();
                            this.txtValContrato.Items.Add("Ativo");
                            this.txtValContrato.Items.Add("Inativo");
                            this.txtValContrato.SelectedItem = "Ativo";
                        }
                        else
                        {
                            this.txtValContrato.Items.Clear();
                            this.txtValContrato.Items.Add("Ativo");
                            this.txtValContrato.Items.Add("Inativo");
                            this.txtValContrato.SelectedItem = "Inativo";
                        }
                        return;
                    }
                }
                catch (OleDbException exception)
                {
                    MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK);
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                }
            }
            else
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + localizaBanco + "'";
                string query = "";
                if (BuscaID != "")
                {
                    idtrat = Convert.ToInt32(BuscaID);
                }
                if (((BuscaID != "") & (BuscaNome != "")) & (BuscaCrianca != ""))
                {
                    object[] objArray1 = new object[] { "SELECT *FROM Cadastros WHERE ID = ", idtrat, " AND Nome LIKE '%", BuscaNome, "%' AND Criança LIKE '%", BuscaCrianca, "%'" };
                    query = string.Concat(objArray1);
                }
                else if (((BuscaID != "") & (BuscaNome == "")) & (BuscaCrianca == ""))
                {
                    query = ("SELECT *FROM Cadastros WHERE ID = " + idtrat) ?? "";
                }
                else if (((BuscaID == "") & (BuscaNome != "")) & (BuscaCrianca == ""))
                {
                    query = "SELECT *FROM Cadastros WHERE Nome LIKE '%" + BuscaNome + "%'";
                }
                else if (((BuscaID == "") & (BuscaNome == "")) & (BuscaCrianca != ""))
                {
                    query = "SELECT *FROM Cadastros WHERE Criança LIKE '%" + BuscaCrianca + "%'";
                }
                else if (((BuscaID != "") & (BuscaNome != "")) & (BuscaCrianca == ""))
                {
                    object[] objArray2 = new object[] { "SELECT *FROM Cadastros WHERE ID = ", idtrat, " AND Nome LIKE '%", BuscaNome, "%'" };
                    query = string.Concat(objArray2);
                }
                else if (((BuscaID != "") & (BuscaNome == "")) & (BuscaCrianca != ""))
                {
                    object[] objArray3 = new object[] { "SELECT *FROM Cadastros WHERE ID = ", idtrat, " AND Criança LIKE '%", BuscaCrianca, "%'" };
                    query = string.Concat(objArray3);
                }
                else if (((BuscaID == "") & (BuscaNome != "")) & (BuscaCrianca != ""))
                {
                    string[] textArray1 = new string[] { "SELECT *FROM Cadastros WHERE Nome LIKE '%", BuscaNome, "%' AND Criança LIKE '%", BuscaCrianca, "%'" };
                    query = string.Concat(textArray1);
                }
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            this.lbDescreveId.Text = Convert.ToInt32(reader["ID"]).ToString();
                            this.txtNome.Text = reader["Nome"].ToString();
                            this.txtRua.Text = reader["Rua"].ToString();
                            this.txtNumCasa.Text = reader["NumCasa"].ToString();
                            this.txtBairro.Text = reader["Bairro"].ToString();
                            this.txtRG.Text = reader["RG"].ToString();
                            this.txtCPF.Text = reader["CPF"].ToString();
                            this.txtTelFixo.Text = reader["Telefone Fixo"].ToString();
                            this.txtCel.Text = reader["Celular"].ToString();
                            this.txtValContrato.Items.Add(reader["Contrato"].ToString());
                            this.txtValContrato.SelectedItem = reader["Contrato"].ToString();
                            this.txtParcela.Text = "R$" + reader["Parcela"] + " Reais".ToString();
                            this.txtTotalAno.Text = "R$" + reader["Valor Anual"] + " Reais".ToString();
                            this.txtNomeCrianca.Text = reader["Criança"].ToString();
                            this.txtEscola.Text = reader["Nome da escola"].ToString();
                            this.txtRuaEscola.Text = reader["Rua da escola"].ToString();
                            this.txtBairroEscola.Text = reader["Bairro da escola"].ToString();
                            this.txtApanha.Text = reader["Apanha"] + " Hrs.".ToString();
                            this.txtEntrega.Text = reader["Entrega"] + " Hrs.".ToString();
                            if (this.txtValContrato.SelectedItem.ToString() == "True")
                            {
                                this.txtValContrato.Items.Clear();
                                this.txtValContrato.Items.Add("Sim");
                                this.txtValContrato.SelectedItem = "Sim";
                            }
                            else
                            {
                                this.txtValContrato.Items.Clear();
                                this.txtValContrato.Items.Add("Não");
                                this.txtValContrato.SelectedItem = "Não";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foram encontrados clientes com os dados especificados, tente novamente.", "Sem resultados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        reader.Close();
                        connection.Close();
                    }
                }
                catch (OleDbException exception)
                {
                    MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK);
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                }
            }
        }

        public static manipulaArquivos getArquivos()
        {
            return contexto;
        }

        private void excluirRegistro_Click(object sender, EventArgs e)
        {
            if (lbDescreveId.Text == "#ID")
            {
                MessageBox.Show("Nenhum cliente cadastrado no banco de dados!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (MessageBox.Show("Deseja mesmo excluir este cliente?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + localizaBanco + "'";
                    string cmdText = ("DELETE FROM Cadastros WHERE ID = " + Convert.ToInt32(this.lbDescreveId.Text));
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    OleDbCommand command = new OleDbCommand(cmdText, connection);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        this.notifyDeleteSucesso.Visible = true;
                        this.notifyDeleteSucesso.ShowBalloonTip(0);
                        MessageBox.Show("Cliente exclu\x00eddo com sucesso.");
                        Thread.Sleep(0x7d0);
                        this.notifyDeleteSucesso.Visible = false;
                    }
                    catch (OleDbException exception)
                    {
                        MessageBox.Show("Error: " + exception.Message);
                    }
                    finally
                    {
                        connection.Close();
                        this.ultimoRegistro_Click(null,null);
                    }
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyCadastro_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.notifyExecucao.Visible = false;
            base.WindowState = FormWindowState.Normal;
        }

        private void primeiroRegistro_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + localizaBanco + "'";
            string cmdText = "SELECT TOP 1 * FROM Cadastros WHERE ID IS NOT NULL order by ID ASC";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.lbDescreveId.Text = Convert.ToInt32(reader["ID"]).ToString();
                    this.txtNome.Text = reader["Nome"].ToString();
                    this.txtRua.Text = reader["Rua"].ToString();
                    this.txtNumCasa.Text = reader["NumCasa"].ToString();
                    this.txtBairro.Text = reader["Bairro"].ToString();
                    this.txtRG.Text = reader["RG"].ToString();
                    this.txtCPF.Text = reader["CPF"].ToString();
                    this.txtTelFixo.Text = reader["Telefone Fixo"].ToString();
                    this.txtCel.Text = reader["Celular"].ToString();
                    this.txtValContrato.Items.Add(reader["Contrato"].ToString());
                    this.txtValContrato.SelectedItem = reader["Contrato"].ToString();
                    this.txtParcela.Text = "R$" + reader["Parcela"] + " Reais".ToString();
                    this.txtTotalAno.Text = "R$" + reader["Valor Anual"] + " Reais".ToString();
                    this.txtNomeCrianca.Text = reader["Criança"].ToString();
                    this.txtEscola.Text = reader["Nome da escola"].ToString();
                    this.txtRuaEscola.Text = reader["Rua da escola"].ToString();
                    this.txtBairroEscola.Text = reader["Bairro da escola"].ToString();
                    this.txtEscTel.Text = reader["Telefone da escola"].ToString();
                    this.txtApanha.Text = reader["Apanha"] + " Hrs.".ToString();
                    this.txtEntrega.Text = reader["Entrega"] + " Hrs.".ToString();
                    if (this.txtValContrato.SelectedItem.ToString() == "True")
                    {
                        this.txtValContrato.Items.Clear();
                        this.txtValContrato.Items.Add("Ativo");
                        this.txtValContrato.Items.Add("Inativo");
                        this.txtValContrato.SelectedItem = "Ativo";
                    }
                    else
                    {
                        this.txtValContrato.Items.Clear();
                        this.txtValContrato.Items.Add("Ativo");
                        this.txtValContrato.Items.Add("Inativo");
                        this.txtValContrato.SelectedItem = "Inativo";
                    }
                }
            }
            catch (OleDbException exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        private void ultimoRegistro_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + localizaBanco + "'";
            string cmdText = "SELECT TOP 1 * FROM Cadastros WHERE ID IS NOT NULL order by ID DESC";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            try
            {
                
                while (reader.Read())
                {
                        this.lbDescreveId.Text = Convert.ToInt32(reader["ID"]).ToString();
                        this.txtNome.Text = reader["Nome"].ToString();
                        this.txtRua.Text = reader["Rua"].ToString();
                        this.txtNumCasa.Text = reader["NumCasa"].ToString();
                        this.txtBairro.Text = reader["Bairro"].ToString();
                        this.txtRG.Text = reader["RG"].ToString();
                        this.txtCPF.Text = reader["CPF"].ToString();
                        this.txtTelFixo.Text = reader["Telefone Fixo"].ToString();
                        this.txtCel.Text = reader["Celular"].ToString();
                        this.txtValContrato.Items.Add(reader["Contrato"].ToString());
                        this.txtValContrato.SelectedItem = reader["Contrato"].ToString();
                        this.txtParcela.Text = "R$" + reader["Parcela"] + " Reais".ToString();
                        this.txtTotalAno.Text = "R$" + reader["Valor Anual"] + " Reais".ToString();
                        this.txtNomeCrianca.Text = reader["Criança"].ToString();
                        this.txtEscola.Text = reader["Nome da escola"].ToString();
                        this.txtRuaEscola.Text = reader["Rua da escola"].ToString();
                        this.txtBairroEscola.Text = reader["Bairro da escola"].ToString();
                        this.txtEscTel.Text = reader["Telefone da escola"].ToString();
                        this.txtApanha.Text = reader["Apanha"] + " Hrs.".ToString();
                        this.txtEntrega.Text = reader["Entrega"] + " Hrs.".ToString();
                        if (this.txtValContrato.SelectedItem.ToString() == "True")
                        {
                            this.txtValContrato.Items.Clear();
                            this.txtValContrato.Items.Add("Ativo");
                            this.txtValContrato.Items.Add("Inativo");
                            this.txtValContrato.SelectedItem = "Ativo";
                        }
                        else
                        {
                            this.txtValContrato.Items.Clear();
                            this.txtValContrato.Items.Add("Ativo");
                            this.txtValContrato.Items.Add("Inativo");
                            this.txtValContrato.SelectedItem = "Inativo";
                        }
                }
            }
            catch (OleDbException exception)
            {
                MessageBox.Show("Erro: " + exception.Message);
            }
            finally
            {
                connection.Close();
                reader.Close();
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }
        
        private void VerCadastros_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clicouSair)
            {
                mostraDialogoSalvar(e);
                clicouSair = false;
            }
            else
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:
                        mostraDialogoSalvar(e);
                        break;
                    case CloseReason.ApplicationExitCall:
                        Application.Exit();
                        break;
                    default:
                        throw new Exception("Houve um erro ao fechar a aplicação, forçando a interrupção.");
                }
            }            
        }

        public void mostraDialogoSalvar(FormClosingEventArgs e)
        {
            if(contexto == null || contexto.ano == 0)
            {
                Application.Exit();
                return;
            }
            DialogResult mensagemSaindo = MessageBox.Show("Deseja salvar as alterações?", "Já está saindo?", MessageBoxButtons.YesNoCancel);
            if (mensagemSaindo == DialogResult.Yes)
            {
                contexto.uparArquivo("db" + contexto.ano + ".mdb", "application/msaccess");
                contexto.uparArquivo("ct" + contexto.ano + ".doc", "application/msword");
                contexto.uparArquivo("menu.mdb", "application/msaccess");
                Application.Exit();
            }
            else if (mensagemSaindo == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void VerCadastros_Load(object sender, EventArgs e)
        {
            SplashScreen screen = new SplashScreen();
            if (screen.ShowDialog() == DialogResult.OK)
            {
                this.CarregaDados();
            }
        }

        private void VerCadastros_Resize(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Normal)
            {
                this.notifyExecucao.Visible = false;
                base.ShowInTaskbar = true;
            }
            if (base.WindowState == FormWindowState.Minimized)
            {
                this.notifyExecucao.Visible = true;
                base.ShowInTaskbar = false;
                this.notifyExecucao.ShowBalloonTip(5);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicouSair = true;
            Application.Exit();
        }

        private void excluiBanco(object sender, EventArgs e)
        {
            string str;
            if (MessageBox.Show("Deseja mesmo excluir o banco de dados do ano que está a ser utilizado? Esta ação não pode ser revertida!", "Excluir banco de dados do ano atual", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ///Exclui Contrato do ano
                str = "ftp://192.168.15.10/files/ct" + contexto.ano + ".doc";

                ///Se funcionar excluir Banco de Dados do ano
                if (contexto.excluiArquivo(ref str) == true)
                {
                    /// Exclui Banco de Dados do ano
                    str = "ftp://192.168.15.10/files/db" + contexto.ano + ".mdb";

                    ///Se funcionar então exclui o ano do menu da SplashScreen
                    if (contexto.excluiArquivo(ref str) == true)
                    {
                        try
                        {
                            contexto.excluiAnoAtualDoMenu();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
                            contexto.uparArquivo("db" + contexto.ano + ".mdb", "application/msaccess");
                            contexto.uparArquivo("ct" + contexto.ano + ".doc", "application/msword");
                        }
                        finally
                        {
                            Application.Restart();
                        }
                    }
                }
            }
        }

        private void incluirRegistros(object sender, EventArgs e)
        {
            new ConstruindoincluiRegistro().Show();
        }
    }
}

