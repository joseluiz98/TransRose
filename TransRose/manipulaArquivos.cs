using System;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Windows.Forms;
namespace TransRose
{
    public class manipulaArquivos
    {
        public int ano;
        public string ct;
        public string db;
        public bool novoDb;
        private static googleDriveAPI driveAPI;

        public manipulaArquivos()
        {
            try
            {
                driveAPI = new googleDriveAPI();
            }
            catch(AggregateException e)
            {
                MessageBox.Show("Houve um erro ao tentar acessar os arquivos na nuvem, cheque as permissões.\n" + e.Message,
                    "Erro ao contatar nuvem", MessageBoxButtons.OK);
                Application.Exit();
            }
        }
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
        public void baixarArquivo(string nomeArquivo)
        {
            try
            {
                driveAPI.baixarArquivo(nomeArquivo, null);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Erro durante a conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void uparArquivo(string nomeArquivo, string mimetype)
        {
            try
            {
                driveAPI.uparArquivo(nomeArquivo, mimetype);
                /*FtpWebRequest request;
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
                }*/
            }
            catch (IOException ex)
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
                uparArquivo("menu.mdb", "application/msaccess");
                Application.Exit();
            }
        }
    }
}