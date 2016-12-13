namespace WindowsFormsApplication2
{
    using System;
    using System.ComponentModel;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class SplashScreen : Form
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static int ano;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string ct;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string db;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static bool novoDb;
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static int recebeAnoNovoDB;
        private Button botaoEntrar;
        private Button botaoSair;
        private IContainer components = null;
        private Label label1;
        private Label labelVersion;
        private PictureBox logoTransrose;
        private ComboBox recebeAno;

        public SplashScreen(int recebeAnoNovoDB)
        {
            this.InitializeComponent();
            ano = recebeAnoNovoDB;
            this.label1.BackColor = Color.Transparent;
            this.logoTransrose.BackColor = Color.Transparent;
            this.botaoSair.BackColor = Color.Transparent;
            this.botaoEntrar.BackColor = Color.Transparent;
            this.labelVersion.BackColor = Color.Transparent;
            this.labelVersion.Text = $"Versão {this.AssemblyVersion}";
        }

        private void apagaRows()
        {
            string str = @"C:\Windows\Temp\transrosedb\" + db + ".mdb";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + str + "'";
            string cmdText = "DELETE * FROM Cadastros";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
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

        public void BaixaFiles(bool novoDb)
        {
            if (!novoDb)
            {
                ano = Convert.ToInt32(this.recebeAno.SelectedItem);
                db = "db" + ano;
                ct = "ct" + ano;
                try
                {
                    WebClient client = new WebClient();
                    byte[] buffer = new WebClient { Credentials = new NetworkCredential("", "") }.DownloadData("ftp://192.168.1.101/files/" + db + ".mdb");
                    FileStream stream = System.IO.File.Create(@"C:\Windows\Temp\transrosedb\" + db + ".mdb");
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro fatal: Não foi possível iniciar a aplicação, contate o suporte, contate o suporte.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Application.Exit();
                }
                try
                {
                    WebClient client3 = new WebClient();
                    byte[] buffer2 = new WebClient { Credentials = new NetworkCredential("", "") }.DownloadData("ftp://192.168.1.101/files/" + ct + ".doc");
                    FileStream stream2 = System.IO.File.Create(@"C:\Windows\Temp\transrosedb\" + ct + ".doc");
                    stream2.Write(buffer2, 0, buffer2.Length);
                    stream2.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro fatal: Não foi possível iniciar a aplicação, contate o suporte, contate o suporte.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Application.Exit();
                }
            }
            if (novoDb)
            {
                db = "db" + ano;
                ct = "ct" + ano;
                try
                {
                    WebClient client5 = new WebClient();
                    byte[] buffer3 = new WebClient { Credentials = new NetworkCredential("", "") }.DownloadData("ftp://192.168.1.101/files/db2016.mdb");
                    FileStream stream3 = System.IO.File.Create(@"C:\Windows\Temp\transrosedb\" + db + ".mdb");
                    stream3.Write(buffer3, 0, buffer3.Length);
                    stream3.Close();
                    this.apagaRows();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro fatal: Não foi possível iniciar a aplicação, contate o suporte, contate o suporte.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Application.Exit();
                }
                try
                {
                    WebClient client7 = new WebClient();
                    byte[] buffer4 = new WebClient { Credentials = new NetworkCredential("", "") }.DownloadData("ftp://192.168.1.101/files/ct2016.doc");
                    FileStream stream4 = System.IO.File.Create(@"C:\Windows\Temp\transrosedb\" + ct + ".doc");
                    stream4.Write(buffer4, 0, buffer4.Length);
                    stream4.Close();
                    VerCadastros.UpaArquivos(db, ct);
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro fatal: Não foi possível iniciar a aplicação, contate o suporte, contate o suporte.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Application.Exit();
                }
            }
        }

        private void BaixaMenu()
        {
            DirectoryInfo info = new DirectoryInfo(@"C:\Windows\Temp\transrosedb\");
            try
            {
                info.Create();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro fatal: Não foi possível iniciar a aplicação, contate o suporte pois n\x00e3o foi poss\x00edvel criar o diret\x00f3rio, contate o suporte.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
            try
            {
                WebClient client = new WebClient();
                byte[] buffer = new WebClient { Credentials = new NetworkCredential("", "") }.DownloadData("ftp://192.168.1.101/files/array.txt");
                FileStream stream = System.IO.File.Create(@"C:\Windows\Temp\transrosedb\array.txt");
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro fatal: Não foi possível baixar o banco de dados, contate o administrador da rede." , "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
        }

        private void botaoEntrar_Click(object sender, EventArgs e)
        {
            if (this.recebeAno.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um banco de dados", "Eita", MessageBoxButtons.OK);
            }
            else
            {
                int num;
                bool flag = int.TryParse(this.recebeAno.SelectedItem.ToString(), out num);
                try
                {
                    if (Convert.ToString(this.recebeAno.SelectedItem) == "Novo Banco de Dados")
                    {
                        try
                        {
                            novoDB odb = new novoDB(ano);
                            if (odb.ShowDialog() == DialogResult.OK)
                            {
                                bool novoDb = true;
                                StreamWriter writer = System.IO.File.AppendText(@"C:\Windows\Temp\transrosedb\array.txt");
                                writer.WriteLine("\n" + ano);
                                writer.Close();
                                this.BaixaFiles(novoDb);
                                this.preencheCombo();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Erro fatal: " + exception, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            Application.Exit();
                        }
                    }
                    else if (flag)
                    {
                        this.BaixaFiles(SplashScreen.novoDb);
                        VerCadastros cadastros = new VerCadastros(db, ct, "", "", "");
                        base.DialogResult = DialogResult.OK;
                    }
                    else if (Convert.ToString(this.recebeAno.SelectedItem) == "Anos anteriores")
                    {
                        MessageBox.Show("N\x00e3o existem bancos de dados de outros anos, ainda.", "Eita", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Banco de dados inv\x00e1lido, tente novamente.", "Eita", MessageBoxButtons.OK);
                    }
                }
                catch (Exception exception2)
                {
                    MessageBox.Show("Erro: " + exception2, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void botaoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.logoTransrose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recebeAno = new System.Windows.Forms.ComboBox();
            this.botaoSair = new System.Windows.Forms.Button();
            this.botaoEntrar = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoTransrose)).BeginInit();
            this.SuspendLayout();
            // 
            // logoTransrose
            // 
            this.logoTransrose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoTransrose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logoTransrose.Image = global::TransRose.Properties.Resources._4_Grayscale_logo_on_transparent_533x75;
            this.logoTransrose.Location = new System.Drawing.Point(59, 69);
            this.logoTransrose.Name = "logoTransrose";
            this.logoTransrose.Size = new System.Drawing.Size(316, 61);
            this.logoTransrose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoTransrose.TabIndex = 13;
            this.logoTransrose.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(33, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecione o ano desejado:";
            // 
            // recebeAno
            // 
            this.recebeAno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recebeAno.FormattingEnabled = true;
            this.recebeAno.Location = new System.Drawing.Point(270, 298);
            this.recebeAno.Name = "recebeAno";
            this.recebeAno.Size = new System.Drawing.Size(121, 21);
            this.recebeAno.Sorted = true;
            this.recebeAno.TabIndex = 1;
            // 
            // botaoSair
            // 
            this.botaoSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botaoSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoSair.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F);
            this.botaoSair.ForeColor = System.Drawing.SystemColors.Window;
            this.botaoSair.Location = new System.Drawing.Point(357, 527);
            this.botaoSair.Name = "botaoSair";
            this.botaoSair.Size = new System.Drawing.Size(75, 23);
            this.botaoSair.TabIndex = 3;
            this.botaoSair.Text = "Sair";
            this.botaoSair.UseVisualStyleBackColor = true;
            this.botaoSair.Click += new System.EventHandler(this.botaoSair_Click);
            // 
            // botaoEntrar
            // 
            this.botaoEntrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botaoEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoEntrar.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F);
            this.botaoEntrar.ForeColor = System.Drawing.SystemColors.Window;
            this.botaoEntrar.Location = new System.Drawing.Point(12, 527);
            this.botaoEntrar.Name = "botaoEntrar";
            this.botaoEntrar.Size = new System.Drawing.Size(75, 23);
            this.botaoEntrar.TabIndex = 2;
            this.botaoEntrar.Text = "Entrar";
            this.botaoEntrar.UseVisualStyleBackColor = true;
            this.botaoEntrar.Click += new System.EventHandler(this.botaoEntrar_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.SystemColors.Window;
            this.labelVersion.Location = new System.Drawing.Point(0, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(47, 13);
            this.labelVersion.TabIndex = 14;
            this.labelVersion.Text = "#Versão";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(444, 562);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.botaoEntrar);
            this.Controls.Add(this.botaoSair);
            this.Controls.Add(this.recebeAno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoTransrose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoTransrose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void preencheCombo()
        {
            string[] strArray = System.IO.File.ReadAllLines(@"C:\Windows\Temp\transrosedb\array.txt");
            try
            {
                this.recebeAno.Items.Clear();
                for (int i = 0; i < strArray.Length; i++)
                {
                    if ((strArray[i] != null) && (strArray[i] != ""))
                    {
                        this.recebeAno.Items.Add(strArray[i]);
                    }
                    if (i == (strArray.Length - 1))
                    {
                        this.recebeAno.Items.Add("");
                        this.recebeAno.SelectedItem = "";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro fatal ao preencher menu: " + exception, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            this.BaixaMenu();
            this.preencheCombo();
        }

        /*public static int ano
        {
            get; set;
        }*/

        public string AssemblyVersion =>
            Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /*public static string ct
        {
            get; set;
        }

        public static string db
        {
            get; set;
        }

        public static bool novoDb
        {
            get; set;
        }

        public static int recebeAnoNovoDB
        {
            get; set;
        }*/
    }
}

