// André Y. Terada - 20122 Rafael L.Silva - 20734

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace CaminhosDeTrem
{
    public partial class FrmCaminhosDeTrem : Form
    {
        //Criar objetos de Arvore, Grafo e ArrayList caminho globais
        ArvoreDeBusca<Cidade> arvore = null;
        Grafo oGrafo;
        ArrayList listaCaminho;
        public FrmCaminhosDeTrem()
        {
            InitializeComponent();
            txtNome.MaxLength = Cidade.tamanhoNome;
            arvore = new ArvoreDeBusca<Cidade>();  //Inicializa a arvore
        }

        private void pbxArvore_Paint(object sender, PaintEventArgs e)
        {
            if (arvore != null)
            {
                //Chama o metodo DesenharArvore de arvore
                Graphics g = e.Graphics;
                arvore.DesenharArvore(true, arvore.Raiz, (int)pbxArvore.Width / 2, 0,
                  Math.PI / 2, Math.PI / 2.5, 600, g);
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Tenta pegar o nome da cidade, o X e Y e passar para varáveis
                string nomeCidade = txtNome.Text.Trim();
                if (nomeCidade.Equals(""))
                    throw new Exception("Digite um nome para a cidade!");
                int indice = arvore.QtosNos();
                double X, Y;
                if(!double.TryParse(txtX.Text, out X))
                    throw new Exception("Digite uma latitude válida!");
                if(X < 0 || X > 1)
                    throw new Exception("Digite uma latitude entre 0 e 1!");
                if (!double.TryParse(txtY.Text, out Y))
                    throw new Exception("Digite uma longitude válida!");
                if (Y < 0 || Y > 1)
                    throw new Exception("Digite uma longitude entre 0 e 1!");

                //Cria uma nova cidade, inclui ela na arvore, nos comboBox e no grafo
                var umaCidade = new Cidade(indice, nomeCidade, X, Y);
                arvore.IncluirNovoRegistro(umaCidade);
                pbxArvore.Invalidate();
                cmbOrigin.Items.Add(umaCidade.Nome);
                cmbDest.Items.Add(umaCidade.Nome);
                oGrafo.NovoVertice(umaCidade.Nome);
                oGrafo.ExibirAdjacencias();
                MessageBox.Show("Cidade Incluida!");
            }
            catch (Exception mens)
            {
                MessageBox.Show(mens.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Pega o Index dos itens selecionados nos comboBox
            lsbSaida.Items.Clear();
            int ori = cmbOrigin.SelectedIndex;
            int des = cmbDest.SelectedIndex;
            if (ori < 0 || des < 0)
                MessageBox.Show("Selecione uma cidade!");
            else
            {
                //Busca o caminho mais curto usando algoritmo de Dijktra e guarda ele em um ArrayList
                listaCaminho = oGrafo.Caminho(ori, des, lsbSaida);
                string caminho = "";
                //Percorre o ArrayList e concatena todas as cidades em uma string
                for(int i=0; i < listaCaminho.Count; i++)
                {
                    caminho += listaCaminho[i];
                    if (i < listaCaminho.Count-1)
                        caminho += " --> ";
                }             
                //Adiciona ao listBox a string com o caminho
                lsbSaida.Items.Add(caminho);
                //Recarrega a pictureBox do mapa para limbar qualquer outro possivel caminho
                pbxMapa.Refresh();  
                string cidadeAnt = null;
                Graphics g = pbxMapa.CreateGraphics();
                //Percorre o Arraylist e usando cidadeAnt como origem e cidade como destino
                //traça linhas ligando as cidades usando desenharCaminho.
                foreach (string cidade in listaCaminho)
                {
                    if (cidadeAnt != null)
                    {
                        arvore.Existe(new Cidade(cidadeAnt));
                        Cidade origin = arvore.Atual.Info;
                        arvore.Existe(new Cidade(cidade));
                        Cidade dest = arvore.Atual.Info;

                        oGrafo.DesenharCaminho(origin, dest, g, pbxMapa);
                    }
                    cidadeAnt = cidade;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "")
            {
                //Verifica se existe uma cidade com o nome passado no txtNome e se existir remove do
                //grafo e dos comboBox o item do indice encontrado.
                var dadoProcurado = new Cidade(txtNome.Text);
                if (arvore.Existe(dadoProcurado))
                {
                    int indice = arvore.Atual.Info.Indice;
                    oGrafo.removerVertice(indice);
                    cmbOrigin.Items.RemoveAt(indice);
                    cmbDest.Items.RemoveAt(indice);
                }
                //Exclui da arvore o dado procurado e caso haja um caminho desenhado, ele limpa o arraylist
                if (arvore.Excluir(dadoProcurado))
                {
                    MessageBox.Show("Excluido com sucesso!");
                    if(listaCaminho != null)
                        listaCaminho.Clear();
                    pbxMapa.Refresh();
                }
                else
                    MessageBox.Show("Falha ao Excluir!");
            }
        }

        private void FrmArvore_Load(object sender, EventArgs e)
        {
            //Ao carregar, se o usuario não escolher nenhum arquivo, ele usará ou criará o cidades.txt
            if (dlgAbrir.ShowDialog() != DialogResult.OK)
            {
                dlgAbrir.FileName = "C:\\temp\\cidades.txt";
            }
            //Instancia arvore como uma nova ArvoreDeBusca do tipo Cidade
            arvore = new ArvoreDeBusca<Cidade>();
            arvore.OndeExibir = pbxArvore;
            //Se o arquivo não existir ele cria
            if (!File.Exists(dlgAbrir.FileName))
            {
                var arquivoCriado = File.Create(dlgAbrir.FileName);
                arquivoCriado.Close();
            }
            try
            {
                //Tenta Ler os Registros
                arvore.LerArquivoDeRegistros(dlgAbrir.FileName);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            pbxArvore.Invalidate();  // disparar o evento Paint, que desenha a árvore

            //Faz a mesma coisa com o arquivo de caminhos
            if (dlgCaminhos.ShowDialog() != DialogResult.OK)
                dlgCaminhos.FileName = "C:\\temp\\grafoTrem.txt";
            if (!File.Exists(dlgCaminhos.FileName))
            {
                var arquivoCriado = File.Create(dlgCaminhos.FileName);
                arquivoCriado.Close();
            }
            //Instancia Grafo
            oGrafo = new Grafo(dgvGrafo, arvore.QtosNos());
            string[] cidades = arvore.GetCidades();
            //Percorre o cidades e adiciona ao comboBox itens usando cidade.toString()
            foreach (string cidade in cidades)
            {
                cmbOrigin.Items.Add(cidade);
                cmbDest.Items.Add(cidade);
                oGrafo.NovoVertice(cidade);
            }
            int origin = 0, dest = 0;
            //Le todas as linhas do arquivo de caminhos
            string[] linhasTxt = File.ReadAllLines(dlgCaminhos.FileName);

            try
            {
                //Percorre o vetor de string e tenta incluir novas arestas
                foreach (string linha in linhasTxt)
                {
                    string orinTxt = linha.Substring(0, 15).Trim();
                    string destTxt = linha.Substring(15, 16).Trim();
                    for (int i = 0; i < cidades.Length; i++)
                    {
                        if (orinTxt.Equals(cidades[i]))
                            origin = i;
                        if (destTxt.Equals(cidades[i]))
                            dest = i;
                    }
                    int distancia = int.Parse(linha.Substring(31, 3));
                    int preco = int.Parse(linha.Substring(36, 3));
                    oGrafo.NovaAresta(origin, dest, distancia, preco);
                }
                oGrafo.ExibirAdjacencias();
            }
            catch(Exception err)
            {
                MessageBox.Show("Não foi possível retirar os dados do Arquivo! \nErro: " + err);
            }

        }

        private void FrmArvore_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Pergunta se deseja salvar os arquivos e se sim grava os dados nos arquivos escolhidos anteriormente
            DialogResult dialogResult = MessageBox.Show("Deseja salvar os arquivos?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                arvore.GravarArquivoDeRegistros(dlgAbrir.FileName);
                oGrafo.GravarArquivoDeRegistros(dlgCaminhos.FileName);
            }
        }

        private void btnCaminho_Click(object sender, EventArgs e)
        {
            try
            {
                //Tenta pegar o indice das cidades escolhidas no comboBox e o valor de preço e distancia
                if (cmbOrigin.SelectedIndex < 0 || cmbDest.SelectedIndex < 0)
                    throw new Exception("Selecine uma cidade!");
                int origin    = cmbOrigin.SelectedIndex;
                int dest      = cmbDest.SelectedIndex;
                int distancia =(int)numDist.Value;
                int preco     = (int)numPreco.Value;
                //Cria um novo caminho passando os dados como parametro
                oGrafo.NovaAresta(origin, dest, distancia, preco);
                oGrafo.ExibirAdjacencias();
                MessageBox.Show("Caminho Criado!");
            }
            catch (Exception mens)
            {
                MessageBox.Show(mens.Message);
            }
        }
    }
}