using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;
using System.Drawing;



namespace ComparacaoNomes
{

    public partial class Form1 : Form
    {
        GestaoArquivo gA = new GestaoArquivo();


        public Form1()
        {
            InitializeComponent();


        }
        private OpenFileDialog ofd = new OpenFileDialog();




        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            textBox1.Text = "                                     Instruções" + Environment.NewLine +
              "Os arquivos que forem carregados devem " +
              "conter o nome 'DocAtual' para o documento já existente e 'DocNovo' para o documento Novo"
              + Environment.NewLine
              + Environment.NewLine +
               "Os arquivos 'DocNovo' e 'DocAtual' que forem carregados, serão salvos na pasta 'Arquivos de Nomes Gerados' "
              + Environment.NewLine
              + Environment.NewLine +
              "Após verificar a lista de nomes, o arquivo gerado será salvo na pasta 'Arquivos de Nomes Incluídos', " +
              "que, por sua vez, está localizada dentro da pasta 'Arquivos de Nomes Gerados'," +
              " que se encontra na pasta 'Documentos'. ";


        }

        private void btn_CarrArqDocAtual(object sender, EventArgs e)
        {
            ofd.Filter = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Ler o conteúdo do arquivo de texto selecionado
                string filePath = ofd.FileName;
                string fileContent = File.ReadAllText(filePath);

                // Obter o caminho da pasta "Meus Documentos" do usuário
                string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Definir o nome da pasta que desejamos criar
                string subfolderName = "Arquivos de Nomes Gerados";

                // Combinar o caminho da pasta "Meus Documentos" com o nome da subpasta
                string subfolderPath = Path.Combine(documentsFolder, subfolderName);

                // Certificar-se de que a subpasta exista ou criá-la se não existir
                Directory.CreateDirectory(subfolderPath);

                // Extrair o nome do arquivo selecionado
                string fileName = Path.GetFileName(filePath);

                // Gerar um prefixo de data e hora no formato "yyyyMMddHHmmss"
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

                // Combinar o prefixo, nome original do arquivo e extensão
                string newFileName = $"{timestamp}_{fileName}";

                // Definir o caminho completo para salvar o arquivo na subpasta
                string savePath = Path.Combine(subfolderPath, newFileName);

                // Salvar o arquivo na subpasta
                File.WriteAllText(savePath, fileContent);

                // Exibir o conteúdo no TextBox
                textBox1.Text = fileContent;
            }

        }

        private void btn_CarrArqDocNovo(object sender, EventArgs e)
        {
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Ler o conteúdo do arquivo de texto selecionado
                    string filePath = ofd.FileName;
                    string fileContent = File.ReadAllText(filePath);

                    // Obter o caminho da pasta "Meus Documentos" do usuário
                    string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    // Definir o nome da pasta que desejamos criar
                    string subfolderName = "Arquivos de Nomes Gerados";

                    // Combinar o caminho da pasta "Meus Documentos" com o nome da subpasta
                    string subfolderPath = Path.Combine(documentsFolder, subfolderName);

                    // Certificar-se de que a subpasta exista ou criá-la se não existir
                    Directory.CreateDirectory(subfolderPath);

                    // Extrair o nome do arquivo selecionado
                    string fileName = Path.GetFileName(filePath);

                    // Gerar um prefixo de data e hora no formato "yyyyMMddHHmmss"
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

                    // Combinar o prefixo, nome original do arquivo e extensão
                    string newFileName = $"{timestamp}_{fileName}";

                    // Definir o caminho completo para salvar o arquivo na subpasta
                    string savePath = Path.Combine(subfolderPath, newFileName);

                    // Salvar o arquivo na subpasta
                    File.WriteAllText(savePath, fileContent);

                    // Exibir o conteúdo no TextBox
                    textBox1.Text = fileContent;
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções aqui, por exemplo, exibir uma mensagem de erro
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btn_ComparaNome(object sender, EventArgs e)
        {
            (string[] nomesNaoIncluidos, string[] nomesIncluidos, string[] nomesDocAtual) = gA.compararNomes();
            string concatenatedText = string.Join(Environment.NewLine, nomesNaoIncluidos);
            textBox1.Text = concatenatedText;
            gA.CriarTxtNovo(nomesIncluidos, nomesDocAtual);
            textBox2.Text = nomesIncluidos.Length.ToString();
            textBox3.Text = nomesNaoIncluidos.Length.ToString();

        }

        private void textBox_Tela(object sender, EventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Both;

        }


        private void btn_Limpar(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }


        private void textBox_Tela_Qtd_Nome(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Tela_Qtd_Iguais(object sender, EventArgs e)
        {

        }
    }


    public class GestaoArquivo
    {


        public string[] lerDocAtual()
        {
            string[] namesDocAtual = new string[0];
            string pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string namePast = "Arquivos de Nomes Gerados";
            string pathNamePast = Path.Combine(pathMyDocuments, namePast);
            // string filePath = Path.Combine(pathNamePast, "DocAtual.txt");



            try
            {
                if (!Directory.Exists(pathNamePast))
                {
                    Directory.CreateDirectory(pathNamePast);
                }

                var arquivosDocAtual = Directory.GetFiles(pathNamePast)
            .Where(f => Path.GetFileNameWithoutExtension(f).EndsWith("DocAtual"))
            .ToArray();

                if (arquivosDocAtual.Length > 0)
                {
                    // Ordena os arquivos por data de modificação em ordem decrescente (o último será o primeiro)
                    var arquivosOrdenados = arquivosDocAtual
                        .Select(f => new FileInfo(f))
                        .OrderByDescending(f => f.LastWriteTime);

                    // Pega o último arquivo da lista ordenada
                    FileInfo ultimoArquivo = arquivosOrdenados.First();

                    // Lê o conteúdo do último arquivo
                    namesDocAtual = File.ReadAllLines(ultimoArquivo.FullName);
                }
                else
                {
                    MessageBox.Show("Nenhum arquivo com o nome terminando em 'DocAtual' foi encontrado.");
                }


                return namesDocAtual;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao ler o arquivo: " + ex.Message);
            }

            return Array.Empty<string>();
        }



        public string[] lerDocNovo()
        {
            string[] nomesDocNovo = new string[0];
            string pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string namePast = "Arquivos de Nomes Gerados";
            string pathNamePast = Path.Combine(pathMyDocuments, namePast);

            try
            {
                if (Directory.Exists(pathNamePast))
                {
                    Directory.CreateDirectory(pathNamePast);
                }
                var arquivoDocNovo = Directory.GetFiles(pathNamePast).Where(f =>
                Path.GetFileNameWithoutExtension(f).EndsWith("DocNovo")).ToArray();

                if (arquivoDocNovo.Length > 0)
                {
                    var arquivosOrdenados = arquivoDocNovo
                        .Select(f => new FileInfo(f))
                        .OrderByDescending(f => f.LastWriteTime);

                    FileInfo ultimoArquivo = arquivosOrdenados.First();

                    nomesDocNovo = File.ReadAllLines(ultimoArquivo.FullName);

                }
                else
                {
                    MessageBox.Show("Nenhum arquivo com o nome terminando em 'DocNovo' foi encontrado");
                }

                return nomesDocNovo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao ler o arquivo DocNovo: " + ex.Message);
            }

            return new string[0];
        }

        public (string[], string[], string[]) compararNomes()
        {
            string[] nomesDocAtual = lerDocAtual();
            string[] nomesDocNovo = lerDocNovo();

            HashSet<string> hashNomesDocAtual = new HashSet<string>(nomesDocAtual);


            List<string> nomesIncluidos = new List<string>();
            List<string> nomesNaoIncluidos = new List<string>();

            foreach (string nomeNovo in nomesDocNovo)
            {
                if (!hashNomesDocAtual.Contains(nomeNovo))
                {
                    nomesIncluidos.Add(nomeNovo);
                }
                else
                {
                    nomesNaoIncluidos.Add(nomeNovo);
                }

            }


            return (nomesNaoIncluidos.ToArray(), nomesIncluidos.ToArray(), nomesDocAtual);
        }

        public void CriarTxtNovo(string[] nomesIncluidos, string[] nomesDocAtual)
        {
            string[] todosNomes;

            if (nomesDocAtual != null && nomesDocAtual.Length > 0)
            {
                todosNomes = nomesDocAtual;

                if (nomesIncluidos != null && nomesIncluidos.Length > 0)
                {
                    todosNomes = todosNomes.Concat(nomesIncluidos).ToArray();
                }
            }
            else if (nomesIncluidos != null && nomesIncluidos.Length > 0)
            {
                todosNomes = nomesIncluidos;  // Se não há nomes não incluídos, usa os nomes incluídos
            }
            else
            {
                todosNomes = Array.Empty<string>();  // Se ambos estão vazios, usa um array vazio
            }

            if (todosNomes.Length == 0)
            {
                MessageBox.Show("Arquivos comparados, não existem nomes incluídos ou não incluídos");
                return;
            }

            string nomeDoArquivo = "ListadeNomesIncluidos.txt";
            string pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string namePast = "Arquivos de Nomes Gerados";
            string namePastDiferent = "Arquivos de Nomes Incluídos";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string newFileName = $"{timestamp}_{nomeDoArquivo}";
            string pathNamePast = Path.Combine(pathMyDocuments, namePast, namePastDiferent, newFileName);
            string folderPath = Path.Combine(pathMyDocuments, namePast, namePastDiferent);

            try
            {
                if (Directory.Exists(folderPath))
                {
                    // Exclui todos os arquivos dentro da pasta
                    foreach (var file in Directory.GetFiles(folderPath))
                    {
                        File.Delete(file);
                    }
                }
                else
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Escreve o conteúdo no arquivo
                string conteudoDoArquivo = string.Join(Environment.NewLine, todosNomes);
                File.WriteAllText(pathNamePast, conteudoDoArquivo);
                MessageBox.Show("Arquivo gerado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar o arquivo: " + ex.Message);
            }
        }





        //public void criarTxtNovo(string[] nomesIncluidos)
        //{
        //    if (nomesIncluidos != null)
        //    {
        //        string nomeDoArquivo = "NomesIncluidos.txt";
        //        string pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //        string namePast = "Arquivos de Nomes Gerados";
        //        string namePastDiferent = "Arquivos de Nomes Incluídos";
        //        string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        //        string newFileName = $"{timestamp}_{nomeDoArquivo}";
        //        string pathNamePast = Path.Combine(pathMyDocuments, namePast, namePastDiferent, newFileName);
        //        string folderPath = Path.Combine(pathMyDocuments, namePast, namePastDiferent);

        //        try
        //        {
        //            // Se o diretório existir, exclua todos os arquivos dentro dele
        //            if (Directory.Exists(folderPath))
        //            {
        //                string[] files = Directory.GetFiles(folderPath);
        //                foreach (var file in files)
        //                {
        //                    File.Delete(file);
        //                }
        //            }
        //            else
        //            {
        //                Directory.CreateDirectory(folderPath);
        //            }

        //            string conteudoDoArquivo = string.Join(Environment.NewLine, nomesIncluidos);

        //            File.WriteAllText(pathNamePast, conteudoDoArquivo);
        //            MessageBox.Show("Arquivo gerado com sucesso.");

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Ocorreu um erro ao atualizar o arquivo: " + ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Arquivos comparados, não existem nomes incluídos");
        //    }
        //}




    }
}
