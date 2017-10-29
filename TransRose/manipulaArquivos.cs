using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2;

namespace TransRose
{
    public class manipulaArquivos
    {
        public int ano;
        public string ct;
        public string db;
        public bool novoDb;

        public void criaArquivo(string nomeArquivo, string extensaoArquivo)
        {
            //Tenta criar os arquivos localmente
            try
            {
                //Cria o contrato
                WebClient client = new WebClient();
                if (extensaoArquivo == "doc")
                {
                    byte[] buffer = new WebClient { Credentials = new NetworkCredential("", "") }.DownloadData("ftp://192.168.15.10/files/ct2016.doc");
                    FileStream stream = System.IO.File.Create(@"C:\Windows\Temp\transrosedb\ct" + ano + ".doc");
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Close();
                }
                //Cria o banco
                else
                {
                    byte[] buffer = new WebClient { Credentials = new NetworkCredential("", "") }.DownloadData("ftp://192.168.15.10/files/db2016.mdb");
                    FileStream stream = System.IO.File.Create(@"C:\Windows\Temp\transrosedb\db" + ano + ".mdb");
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Close();
                    this.apagaBanco();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
        }
        public void baixarArquivo()
        {
            db = "db" + ano;
            ct = "ct" + ano;
            try
            {
                WebClient client = new WebClient();
                byte[] buffer = new WebClient { Credentials = new NetworkCredential("", "") }.DownloadData("ftp://192.168.15.10/files/" + db + ".mdb");
                FileStream stream = System.IO.File.Create(@"C:\Windows\Temp\transrosedb\" + db + ".mdb");
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
            try
            {
                WebClient client3 = new WebClient();
                byte[] buffer2 = new WebClient { Credentials = new NetworkCredential("", "") }.DownloadData("ftp://192.168.15.10/files/" + ct + ".doc");
                FileStream stream2 = System.IO.File.Create(@"C:\Windows\Temp\transrosedb\" + ct + ".doc");
                stream2.Write(buffer2, 0, buffer2.Length);
                stream2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
        }

        public void uparArquivo(string nomeArquivo)
        {
            try
            {
                FtpWebRequest request;
                request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://192.168.15.10/files/" + nomeArquivo));
                request.Method = "STOR";
                request.Proxy = null;
                request.UseBinary = true;
                request.UsePassive = true;
                request.Credentials = new NetworkCredential("", "");
                FileInfo info3 = new FileInfo(@"C:\Windows\Temp\transrosedb\" + nomeArquivo);
                byte[] buffer3 = new byte[info3.Length];
                using (FileStream stream5 = info3.OpenRead())
                {
                    stream5.Read(buffer3, 0, Convert.ToInt32(info3.Length));
                }
                using (Stream stream6 = request.GetRequestStream())
                {
                    stream6.Write(buffer3, 0, buffer3.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Houve um erro durante a conexão com o servidor");
            }
        }

        private void apagaBanco()
        {
            string str = @"C:\Windows\Temp\transrosedb\db" + ano + ".mdb";
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
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool excluiArquivo(ref string str)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(str);
                request.Credentials = new NetworkCredential("", "");
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro fatal: Não foi possível realizar a operação solicitada, contate o suporte.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

        public void excluiAnoAtualDoMenu()
        {
            string str = @"C:\Windows\Temp\transrosedb\menu.mdb";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + str + "'";
            string cmdText = "DELETE * FROM menu WHERE ano = '" + ano + "'";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            try
            {
                connection.Open();
                int linhasAfetadas = command.ExecuteNonQuery();
                if(linhasAfetadas != 1)
                {
                    throw new Exception("Não foi possível remover o ano atual do menu.");
                }
            }
            catch (OleDbException exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
                uparArquivo("menu.mdb");
                Application.Exit();
            }
        }
    }
}