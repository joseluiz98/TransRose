namespace WindowsFormsApplication2
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Windows.Forms;
    using TransRose;

    public class SplashScreen : Form
    {
        private Button btEntrar;
        private Button btSair;
        private Label lbSelecioneAno;
        private Label lbVersão;
        private PictureBox imgLogoTransrose;
        private ComboBox cbRecebeAno;
        private manipulaArquivos contexto;

        public SplashScreen()
        {
            this.contexto = new manipulaArquivos();
            this.InitializeComponent();
            this.lbSelecioneAno.BackColor = Color.Transparent;
            this.imgLogoTransrose.BackColor = Color.Transparent;
            this.btSair.BackColor = Color.Transparent;
            this.btEntrar.BackColor = Color.Transparent;
            this.lbVersão.BackColor = Color.Transparent;
            this.lbVersão.Text = $"Versão {this.AssemblyVersion}";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.imgLogoTransrose = new System.Windows.Forms.PictureBox();
            this.lbSelecioneAno = new System.Windows.Forms.Label();
            this.cbRecebeAno = new System.Windows.Forms.ComboBox();
            this.btSair = new System.Windows.Forms.Button();
            this.btEntrar = new System.Windows.Forms.Button();
            this.lbVersão = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoTransrose)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLogoTransrose
            // 
            this.imgLogoTransrose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLogoTransrose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgLogoTransrose.Image = global::TransRose.Properties.Resources._4_Grayscale_logo_on_transparent_533x75;
            this.imgLogoTransrose.Location = new System.Drawing.Point(59, 69);
            this.imgLogoTransrose.Name = "imgLogoTransrose";
            this.imgLogoTransrose.Size = new System.Drawing.Size(316, 61);
            this.imgLogoTransrose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogoTransrose.TabIndex = 13;
            this.imgLogoTransrose.TabStop = false;
            // 
            // lbSelecioneAno
            // 
            this.lbSelecioneAno.AutoSize = true;
            this.lbSelecioneAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelecioneAno.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbSelecioneAno.Location = new System.Drawing.Point(20, 240);
            this.lbSelecioneAno.Name = "lbSelecioneAno";
            this.lbSelecioneAno.Size = new System.Drawing.Size(236, 24);
            this.lbSelecioneAno.TabIndex = 4;
            this.lbSelecioneAno.Text = "Selecione o ano desejado:";
            // 
            // cbRecebeAno
            // 
            this.cbRecebeAno.BackColor = System.Drawing.SystemColors.Control;
            this.cbRecebeAno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRecebeAno.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cbRecebeAno.FormattingEnabled = true;
            this.cbRecebeAno.Location = new System.Drawing.Point(270, 298);
            this.cbRecebeAno.Name = "cbRecebeAno";
            this.cbRecebeAno.Size = new System.Drawing.Size(121, 21);
            this.cbRecebeAno.Sorted = true;
            this.cbRecebeAno.TabIndex = 1;
            // 
            // btSair
            // 
            this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSair.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F);
            this.btSair.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btSair.Location = new System.Drawing.Point(357, 527);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(75, 23);
            this.btSair.TabIndex = 3;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.botaoSair_Click);
            // 
            // btEntrar
            // 
            this.btEntrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btEntrar.BackColor = System.Drawing.SystemColors.Control;
            this.btEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEntrar.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F);
            this.btEntrar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btEntrar.Location = new System.Drawing.Point(12, 527);
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.Size = new System.Drawing.Size(75, 23);
            this.btEntrar.TabIndex = 2;
            this.btEntrar.Text = "Entrar";
            this.btEntrar.UseVisualStyleBackColor = true;
            this.btEntrar.Click += new System.EventHandler(this.botaoEntrar_Click);
            // 
            // lbVersão
            // 
            this.lbVersão.AutoSize = true;
            this.lbVersão.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbVersão.Location = new System.Drawing.Point(0, 0);
            this.lbVersão.Name = "lbVersão";
            this.lbVersão.Size = new System.Drawing.Size(47, 13);
            this.lbVersão.TabIndex = 14;
            this.lbVersão.Text = "#Versão";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(444, 562);
            this.Controls.Add(this.lbVersão);
            this.Controls.Add(this.btEntrar);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.cbRecebeAno);
            this.Controls.Add(this.lbSelecioneAno);
            this.Controls.Add(this.imgLogoTransrose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoTransrose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void criaDiretorioTemporario()
        {
            
            DirectoryInfo info = new DirectoryInfo(@"C:\Windows\Temp\transrosedb\");
            try
            {
                info.Create();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro fatal: Não foi possível iniciar a aplicação, contate o suporte pois não foi possível criar o diret\x00f3rio, contate o suporte.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
        }

        private void botaoSair_Click(object sender, EventArgs e)
        {
            VerCadastros.clicouSair = true;
            Application.Exit();
        }

        private void preencheMenu()
        {
            //List<string> arrayTxt = File.ReadAllLines(@"C:\Windows\Temp\transrosedb\array.txt").ToList();
            string arquivoBanco= @"C:\Windows\Temp\transrosedb\menu.mdb";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + arquivoBanco + "'";
            string query = "SELECT ano FROM menu";
            OleDbConnection connection = new OleDbConnection(connString);
            try
            {                
                // Create data adapter object 
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connection);
                // Create a dataset object and fill with data using data adapter's Fill method 
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "menu");
                // Attach dataset's DefaultView to the combobox 
                cbRecebeAno.DataSource = dataSet.Tables["menu"].DefaultView;
                cbRecebeAno.DisplayMember = "ano";
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Houve um erro ao receber os anos disponíveis.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
            catch (OleDbException)
            {
                MessageBox.Show("Houve um erro ao acessar o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                cbRecebeAno.Text = null;
                connection.Close();
            }
        }

        private void botaoEntrar_Click(object sender, EventArgs e)
        {
            /// Verifica se usuário não selecionou um banco de dados válido
            if (cbRecebeAno.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um banco de dados", "Erro", MessageBoxButtons.OK);
            }
            /// Se selecionou então valida demais opções
            else
            {
                DataRowView oDataRowView = cbRecebeAno.SelectedItem as DataRowView;
                string selectedItem = string.Empty;

                if (oDataRowView != null)
                {
                    selectedItem = oDataRowView.Row["ano"] as string;
                }
                int ano;
                bool opcaoEUmNumero = int.TryParse(selectedItem, out ano);

                try
                {

                    /// Verifica se usuário solicitou a criação de novo db (novo ano)
                    if (selectedItem == "Novo Banco de Dados")
                    {
                        try
                        {
                            /// Usuário selecionou 'novo ano', verifica se ano já existe
                            novoDB criaNovoDb = new novoDB();
                            if (criaNovoDb.ShowDialog() == DialogResult.OK)
                            {
                                contexto.ano = criaNovoDb.getAno();
                                string localizaBanco = @"C:\Windows\Temp\transrosedb\menu.mdb";
                                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + localizaBanco + "'";
                                string query = "INSERT INTO menu VALUES('" + contexto.ano + "')";
                                OleDbConnection connection = new OleDbConnection(connectionString);
                                OleDbCommand command = new OleDbCommand(query, connection);
                                try
                                {
                                    connection.Open();
                                    command.ExecuteNonQuery();
                                }
                                catch (OleDbException exception)
                                {
                                    MessageBox.Show("Erro: " + exception.Message, "Erro");
                                    Application.Exit();
                                }
                                finally
                                {
                                    connection.Close();
                                }
                                //Inseriu o ano no menu, então cria os contexto localmente e faz upload deles
                                try
                                {
                                    contexto.criaArquivo("ct" + contexto.ano, "doc");
                                    contexto.criaArquivo("db" + contexto.ano, "mdb");
                                    contexto.uparArquivo("ct" + contexto.ano + ".doc", "application/msword");
                                    contexto.uparArquivo("db" + contexto.ano + ".mdb", "application/msaccess");
                                    contexto.uparArquivo("menu.mdb", "application/msaccess");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro: " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                                //Atualiza o menu da SplashScreen
                                finally
                                {
                                    this.preencheMenu();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro: " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            Application.Exit();
                        }
                    }
                    else if (opcaoEUmNumero)
                    {
                        contexto.ano = ano;
                        try
                        {
                            contexto.baixarArquivo("db" + contexto.ano + ".mdb");
                            contexto.baixarArquivo("ct" + ano + ".doc");
                        }
                        catch(FileNotFoundException ex)
                        {
                            MessageBox.Show("Erro: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            Application.Exit();
                        }
                        VerCadastros cadastros = new VerCadastros(contexto,"", "", "");
                        base.DialogResult = DialogResult.OK;
                    }
                    else if (Convert.ToString(cbRecebeAno.SelectedItem) == "Anos anteriores")
                    {
                        MessageBox.Show("Não existem bancos de dados de outros anos, ainda.", "Eita", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Opção inválida, tente novamente.", "Eita", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            this.criaDiretorioTemporario();
            contexto.baixarArquivo("menu.mdb");
            this.preencheMenu();
        }

        public string AssemblyVersion =>
            Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}

