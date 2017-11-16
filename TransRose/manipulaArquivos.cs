using System;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TransRose
{
    public class manipulaArquivos
    {
        public int ano;
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
                if (extensaoArquivo == "doc")
                {
                    driveAPI.baixarArquivo("ct2016.doc", "ct" + ano + ".doc", null);
                }
                //Cria o banco
                else
                {
                    driveAPI.baixarArquivo("db2016.mdb", "db" + ano + ".mdb", null);
                    this.limparBanco();
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
                //var task = Task.Run(async () => { await driveAPI.baixarArquivo(nomeArquivo, null); });
                //task.Wait();
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
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Houve um erro durante a conexão com o servidor");
            }
        }

        private void limparBanco()
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

        public bool excluiArquivo(ref string nomeArquivo)
        {
            try
            {
                driveAPI.deletaArquivo(ref nomeArquivo);
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
                else
                {
                    connection.Close();
                    uparArquivo("menu.mdb", "application/msaccess");
                }
            }
            catch (OleDbException exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
                Application.Exit();
            }
        }
    }
}