using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TransRose
{
    public class googleDriveAPI
    {
        private static string[] Scopes = { DriveService.Scope.Drive };
        private static string ApplicationName = "Cadastro de Clientes - TransRose";
        private static UserCredential credential;
        private static DriveService service;

        public googleDriveAPI()
        {
            credential = GetCredentials();
            // Create Drive API service.

            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        private static UserCredential GetCredentials()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                // Console.WriteLine("Credential file saved to: " + credPath);
            }

            return credential;
        }

        private void salvarArquivo(System.IO.MemoryStream stream, string saveTo)
        {
            using (System.IO.FileStream file = new System.IO.FileStream(saveTo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                stream.WriteTo(file);
            }
        }

        public void baixarArquivo(string nomeDoArquivo, string pageToken)
        {
            try
            {
                Google.Apis.Drive.v3.Data.File file = buscarArquivo(ref nomeDoArquivo, pageToken);
                var request = service.Files.Get(file.Id);
                var stream = new MemoryStream();

                // Add a handler which will be notified on progress changes.
                // It will notify on each chunk download and when the
                // download is completed or failed.
                request.MediaDownloader.ProgressChanged +=
                    (IDownloadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    salvarArquivo(stream, @"C:\Windows\Temp\transrosedb\" + file.Name);
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    throw new Exception("O download falhou.");
                                }
                        }
                    };
                request.Download(stream);
                stream.Close();
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                MessageBox.Show(ex.Message, "Erro durante a conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch(Exception ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
        }

        private Google.Apis.Drive.v3.Data.File buscarArquivo(ref string nomeDoArquivo, string pageToken)
        {
            try
            {
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.Fields = "nextPageToken, files(name,id,parents,trashed)";
                listRequest.PageToken = pageToken;
                listRequest.Q = "name='" + nomeDoArquivo + "' and trashed = false";

                //Procura pelo arquivo para efetuar o download
                var request = listRequest.Execute();

                //Encontrou um arquivo e recuperou o seu Id, então, baixe-o
                if (request.Files != null && request.Files.Count == 1)
                {
                    foreach (var file in request.Files)
                    {
                        return file;
                    }
                    pageToken = request.NextPageToken;
                }
                else if (request.Files.Count == 2)
                {
                    throw new FileNotFoundException("Há mais de um arquivo com o nome \"" + nomeDoArquivo + "\" no Google Drive, delete um deles.");
                }
                else
                {
                    throw new FileNotFoundException("Não foi possível encontrar o arquivo.");
                }
                return null;
            }
            catch (System.Net.Http.HttpRequestException)
            {
                throw new System.Net.Http.HttpRequestException("Não foi possível procurar os arquivos na nuvem, verifique sua conexão com à internet.");
            }
        }

        private static void listarArquivos(DriveService service, ref string pageToken)
        {
            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            //listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.Fields = "nextPageToken, files(name,id)";
            listRequest.PageToken = pageToken;
            listRequest.Q = "mimeType='application/msaccess'";

            // List files.
            var request = listRequest.Execute();

            if (request.Files != null && request.Files.Count > 0)
            {
                foreach (var file in request.Files)
                {
                    Console.WriteLine("{0}", file.Name);
                    //baixarArquivo(service, file);
                }

                pageToken = request.NextPageToken;

                if (request.NextPageToken != null)
                {
                    Console.WriteLine("Press any key to conti...");
                    Console.ReadLine();
                }
            }
            else
            {
                throw new FileNotFoundException("Não foi possível encontrar o arquivo.");
            }
        }

        public void uparArquivo(string nomeArquivo, string mimetype)
        {
            try
            {
                //Configura o caminho do arquivo
                string path = @"C:\Windows\Temp\transrosedb\" + nomeArquivo;
                var arquivo = buscarArquivo(ref nomeArquivo, null);
                //Configura o nome e a pasta onde o arquivo deve ser upado
                var novoArquivo = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = arquivo.Name,
                    Parents = arquivo.Parents
                };

                //Tenta ler e upar o arquivo
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(novoArquivo, stream, mimetype);
                    request.Upload();
                }
                //Recupera a resposta da tentativa de upload
                var file = request.ResponseBody;
                //Se upou, então deleta o arquivo antigo
                if (file != null)
                {
                    service.Files.Delete(arquivo.Id).Execute();
                }
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
        }
    }
}