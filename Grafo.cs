// André Y. Terada - 20122 Rafael L.Silva - 20734

using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

class Grafo
{
    private Vertice[] vertices;
    private int[,,] adjMatrix;
    int numVerts;
    DataGridView dgv;   // para exibir a matriz de adjacência num formulário

    /// DJIKSTRA
    DistOriginal[] percurso;
    int infinity = 100000;
    int verticeAtual;   // global usada para indicar o vértice atualmente sendo visitado 
    int doInicioAteAtual;   // global usada para ajustar menor caminho com Djikstra
    int precoIniAtual;   // global usada para ajustar menor caminho com Djikstra

    public Grafo(DataGridView dgv, int nVertices)
    {
        this.dgv = dgv;
        vertices = new Vertice[nVertices];
        adjMatrix = new int[nVertices, nVertices, 2];
        numVerts = 0;

        for (int j = 0; j < nVertices; j++)      // zera toda a matriz
            for (int k = 0; k < nVertices; k++)
                adjMatrix[j, k, 0] = infinity; // distância tão grande que não existe

        percurso = new DistOriginal[nVertices];
    }

    public void NovoVertice(string label)
    {
        if(vertices.Length == numVerts)
        {
            Vertice[] _vertices = new Vertice[numVerts * 2];
            vertices.CopyTo(_vertices, 0);
            vertices = _vertices;

            int[,,] _adjMatrix = new int[numVerts * 2, numVerts * 2, 2];
            for (int j = 0; j < numVerts * 2; j++)      // zera toda a matriz
                for (int k = 0; k < numVerts * 2; k++)
                    _adjMatrix[j, k, 0] = infinity; // distância tão grande que não existe

            for (int i = 0; i < numVerts; i++)
                for(int j = 0; j < numVerts; j++)
                {
                    _adjMatrix[i, j, 0]= adjMatrix[i, j, 0];
                    _adjMatrix[i, j, 1] = adjMatrix[i, j, 1];
                }

            DistOriginal[] _percurso = new DistOriginal[numVerts * 2];
            percurso.CopyTo(_percurso, 0);
            percurso = _percurso;

            adjMatrix = _adjMatrix;
        }
        vertices[numVerts] = new Vertice(label);
        numVerts++;
        if (dgv != null)  // se foi passado como parâmetro um dataGridView para exibição
        {              // se realiza o seu ajuste para a quantidade de vértices
            dgv.RowCount = numVerts + 1;
            dgv.ColumnCount = numVerts + 1;
            dgv.Columns[numVerts].Width = 80;
        }
    }

    public void NovaAresta(int origem, int destino)
    {
        adjMatrix[origem, destino, 0] = 1;
    }

    public void NovaAresta(int origem, int destino, int peso, int preco)
    {
        adjMatrix[origem, destino, 0] = peso;
        adjMatrix[origem, destino, 1] = preco;
    }

    public void ExibirVertice(int v)
    {
        Console.Write(vertices[v].Rotulo + " ");
    }

    public void ExibirVertice(int v, TextBox txt)
    {
        txt.Text += vertices[v].Rotulo + " ";
    }

    public int SemSucessores() 	// encontra e retorna a linha de um vértice sem sucessores
    {
        bool temAresta;
        for (int linha = 0; linha < numVerts; linha++)
        {
            temAresta = false;
            for (int col = 0; col < numVerts; col++)
                if (adjMatrix[linha, col, 0] != infinity)
                {
                    temAresta = true;
                    break;
                }
            if (!temAresta)
                return linha;
        }
        return -1;
    }

    public void removerVertice(int vert)
    {
        if (dgv != null)
        {
            ExibirAdjacencias();
        }
        if (vert != numVerts - 1)
        {
            for (int j = vert; j < numVerts - 1; j++)   // remove vértice do vetor
                vertices[j] = vertices[j + 1];

            // remove vértice da matriz
            for (int row = vert; row < numVerts; row++)
                moverLinhas(row, numVerts - 1);
            for (int col = vert; col < numVerts; col++)
                moverColunas(col, numVerts - 1);
        }
        numVerts--;
        if (dgv != null)
            ExibirAdjacencias();
    }
    
    private void moverLinhas(int row, int length)
    {
        if (row != numVerts - 1)
            for (int col = 0; col < length; col++)
            {
                adjMatrix[row, col, 0] = adjMatrix[row + 1, col, 0];  // desloca para excluir
                adjMatrix[row, col, 1] = adjMatrix[row + 1, col, 1];  // desloca para excluir

            }

    }
    
    private void moverColunas(int col, int length)
    {
        if (col != numVerts - 1)
            for (int row = 0; row < length; row++)
            {
                adjMatrix[row, col, 0] = adjMatrix[row, col + 1, 0]; // desloca para excluir
                adjMatrix[row, col, 1] = adjMatrix[row, col + 1, 1]; // desloca para excluir

            }
    }
    
    public void ExibirAdjacencias()
    {
        dgv.RowCount = numVerts + 1;
        dgv.ColumnCount = numVerts + 1;
        for (int j = 0; j < numVerts; j++)
        {
            dgv[0, j + 1].Value = vertices[j].Rotulo;
            dgv[j + 1, 0].Value = vertices[j].Rotulo;
            for (int k = 0; k < numVerts; k++)
            {
                if (adjMatrix[j, k, 0] != infinity)
                {
                    dgv[k + 1, j + 1].Style.BackColor = System.Drawing.Color.Yellow;
                    dgv[k + 1, j + 1].Value = adjMatrix[j, k, 0] + "km " + adjMatrix[j, k, 1] + "€";
                }
                else
                {
                    dgv[k + 1, j + 1].Value = "";
                    dgv[k + 1, j + 1].Style.BackColor = System.Drawing.Color.White;
                }

            }
        }
    }

    public String OrdenacaoTopologica()
    {
        if (dgv != null)
            ExibirAdjacencias();
        Stack<String> gPilha = new Stack<String>(); // para guardar a sequência de vértices
        int origVerts = numVerts;
        while (numVerts > 0)
        {
            int currVertex = SemSucessores();
            if (currVertex == -1)
                return "Erro: grafo possui ciclos.";
            gPilha.Push(vertices[currVertex].Rotulo);   // empilha vértice
            removerVertice(currVertex);
        }
        String resultado = "Sequência da Ordenação Topológica: ";
        while (gPilha.Count > 0)
            resultado += gPilha.Pop() + " ";    // desempilha para exibir
        return resultado;
    }

    private int ObterVerticeAdjacenteNaoVisitado(int v)
    {
        for (int j = 0; j <= numVerts - 1; j++)
            if ((adjMatrix[v, j, 0] != infinity) && (!vertices[j].FoiVisitado))
                return j;
        return -1;
    }

    public void PercursoEmProfundidade(TextBox txt)
    {
        txt.Clear();
        Stack<int> gPilha = new Stack<int>(); // para guardar a sequência de vértices
        for (int j = 0; j <= numVerts - 1; j++)
            vertices[j].FoiVisitado = false;
        vertices[0].FoiVisitado = true;
        ExibirVertice(0, txt);
        gPilha.Push(0);
        int v;
        while (gPilha.Count > 0)
        {
            v = ObterVerticeAdjacenteNaoVisitado(gPilha.Peek());
            if (v == -1)
                gPilha.Pop();
            else
            {
                vertices[v].FoiVisitado = true;
                ExibirVertice(v, txt);
                gPilha.Push(v);
            }
        }
        for (int j = 0; j <= numVerts - 1; j++)
            vertices[j].FoiVisitado = false;
    }

    void ProcessarNo(int i, TextBox txt)
    {
        txt.Text += vertices[i].Rotulo;
    }

    public void PercursoEmProfundidadeRec(int[,] adjMatrix, int numVerts, int part, TextBox txt)
    {
        int i;
        ProcessarNo(part, txt);
        vertices[part].FoiVisitado = true;
        for (i = 0; i < numVerts; ++i)
            if (adjMatrix[part, i] != infinity && !vertices[i].FoiVisitado)
                PercursoEmProfundidadeRec(adjMatrix, numVerts, i, txt);
    }

    public void percursoPorLargura(TextBox txt)
    {
        txt.Clear();
        Queue<int> gQueue = new Queue<int>();
        vertices[0].FoiVisitado = true;
        ExibirVertice(0, txt);
        gQueue.Enqueue(0);
        int vert1, vert2;
        while (gQueue.Count > 0)
        {
            vert1 = gQueue.Dequeue();
            vert2 = ObterVerticeAdjacenteNaoVisitado(vert1);
            while (vert2 != -1)
            {
                vertices[vert2].FoiVisitado = true;
                ExibirVertice(vert2, txt);
                gQueue.Enqueue(vert2);
                vert2 = ObterVerticeAdjacenteNaoVisitado(vert1);
            }
        }
        for (int i = 0; i < numVerts; i++)
            vertices[i].FoiVisitado = false;
    }

    public void ArvoreGeradoraMinima(int primeiro, TextBox txt)
    {
        txt.Clear();
        Stack<int> gPilha = new Stack<int>(); // para guardar a sequência de vértices
        vertices[primeiro].FoiVisitado = true;
        gPilha.Push(primeiro);
        int currVertex, ver;
        while (gPilha.Count > 0)
        {
            currVertex = gPilha.Peek();
            ver = ObterVerticeAdjacenteNaoVisitado(currVertex);
            if (ver == -1)
                gPilha.Pop();
            else
            {
                vertices[ver].FoiVisitado = true;
                gPilha.Push(ver);
                ExibirVertice(currVertex, txt);
                txt.Text += "-->";
                ExibirVertice(ver, txt);
                txt.Text += "  ";
            }
        }
        for (int j = 0; j <= numVerts - 1; j++)
            vertices[j].FoiVisitado = false;
    }

    public ArrayList Caminho(int inicioDoPercurso, int finalDoPercurso, ListBox lista)
    {
        for (int j = 0; j < numVerts; j++)
            vertices[j].FoiVisitado = false;

        vertices[inicioDoPercurso].FoiVisitado = true;
        for (int j = 0; j < numVerts; j++)
        {
            // anotamos no vetor percurso a distância entre o inicioDoPercurso e cada vértice
            // se não há ligação direta, o valor da distância será infinity
            int dist = adjMatrix[inicioDoPercurso, j, 0];
            int preco = adjMatrix[inicioDoPercurso, j, 1];
            //MessageBox.Show("" + dist + ":" + preco);

            percurso[j] = new DistOriginal(inicioDoPercurso, dist, preco);
        }

        for (int nTree = 0; nTree < numVerts; nTree++)
        {
            // Procuramos a saída não visitada do vértice inicioDoPercurso com a menor distância
            int indiceDoMenor = ObterMenor();

            // e anotamos essa menor distância
            int distanciaMinima = percurso[indiceDoMenor].Distancia;

            // o vértice com a menor distância passa a ser o vértice atual
            // para compararmos com a distância calculada em AjustarMenorCaminho()
            verticeAtual = indiceDoMenor;
            doInicioAteAtual = percurso[indiceDoMenor].Distancia;
            precoIniAtual = percurso[indiceDoMenor].Preco;
            // visitamos o vértice com a menor distância desde o inicioDoPercurso
            vertices[verticeAtual].FoiVisitado = true;
            AjustarMenorCaminho(lista);
        }

        return ExibirPercursos(inicioDoPercurso, finalDoPercurso, lista);
    }

    public int ObterMenor()
    {
        int distanciaMinima = infinity;
        int indiceDaMinima = 0;
        for (int j = 0; j < numVerts; j++)
            if (!(vertices[j].FoiVisitado) && (percurso[j].Distancia < distanciaMinima))
            {
                distanciaMinima = percurso[j].Distancia;
                indiceDaMinima = j;
            }
        return indiceDaMinima;
    }

    public void AjustarMenorCaminho(ListBox lista)
    {
        for (int coluna = 0; coluna < numVerts; coluna++)
            if (!vertices[coluna].FoiVisitado)       // para cada vértice ainda não visitado
            {
                // acessamos a distância desde o vértice atual (pode ser infinity)
                int atualAteMargem = adjMatrix[verticeAtual, coluna, 0];
                int preco = adjMatrix[verticeAtual, coluna, 1];

                // calculamos a distância desde inicioDoPercurso passando por vertice atual até
                // esta saída
                int doInicioAteMargem = doInicioAteAtual + atualAteMargem;
                int precoIniMargem = precoIniAtual + preco;

                // quando encontra uma distância menor, marca o vértice a partir do
                // qual chegamos no vértice de índice coluna, e a soma da distância
                // percorrida para nele chegar
                int distanciaDoCaminho = percurso[coluna].Distancia;
                if (doInicioAteMargem < distanciaDoCaminho)
                {
                    percurso[coluna].VerticePai = verticeAtual;
                    percurso[coluna].Distancia = doInicioAteMargem;
                    percurso[coluna].Preco = precoIniMargem;
                    //ExibirTabela(lista);
                }
            }
        //lista.Items.Add("==================Caminho ajustado==============");
    }

    public void ExibirTabela(ListBox lista)
    {
        string dist = "";
        lista.Items.Add("Vértice\t\tVisitado?\tDistancia\tVindo de");
        for (int i = 0; i < numVerts; i++)
        {
            if (percurso[i].Distancia == infinity)
                dist = "inf";
            else
                dist = Convert.ToString(percurso[i].Distancia);

            lista.Items.Add(vertices[i].Rotulo.PadRight(16) + "\t"+ vertices[i].FoiVisitado +
                  "\t" + dist + "\t" + vertices[percurso[i].VerticePai].Rotulo);
        }
        lista.Items.Add("-----------------------------------------------------");
    }

    public ArrayList ExibirPercursos(int inicioDoPercurso, int finalDoPercurso, ListBox lista)
    {
        ArrayList resultado = new ArrayList();

        lista.Items.Add("Caminho entre " + vertices[inicioDoPercurso].Rotulo +
                                   " e " + vertices[finalDoPercurso].Rotulo);
        lista.Items.Add("");

        int onde = finalDoPercurso;
        Stack<string> pilha = new Stack<string>();
        if (percurso[onde].Distancia != infinity)
        {
            lista.Items.Add("Distancia: " + percurso[onde].Distancia + "km");
            lista.Items.Add("Preço: " + percurso[onde].Preco + "€");
            lista.Items.Add("Tempo: " + percurso[onde].Hora.ToString().PadLeft(2, '0') 
                                      + ":" + percurso[onde].Min.ToString().PadLeft(2,'0'));
        }

        int cont = 0;
        while (onde != inicioDoPercurso)
        {
            onde = percurso[onde].VerticePai;
            pilha.Push(vertices[onde].Rotulo);
            cont++;
        }
        
        while (pilha.Count != 0)
            resultado.Add(pilha.Pop());

        if ((cont == 1) && (percurso[finalDoPercurso].Distancia == infinity))
        {
            resultado.Clear();
            resultado.Add("Não há caminho");

        }
        else
            resultado.Add(vertices[finalDoPercurso].Rotulo);
        return resultado;
    }

    public void GravarArquivoDeRegistros(string nomeArquivo)
    {
        using StreamWriter arquivo = new StreamWriter(nomeArquivo);
        for(int i = 0; i < numVerts; i++)
        {
            for(int j = 0; j < numVerts; j++)
            {
                if(adjMatrix[i, j, 0] != infinity)
                {
                    string orig = vertices[i].Rotulo;
                    string dest = vertices[j].Rotulo;
                    int    dist = adjMatrix[i, j, 0];
                    int   preco = adjMatrix[i, j, 1];
                    string linha = orig.PadRight(15) + dest.PadRight(16) + dist.ToString().PadLeft(3) + preco.ToString().PadLeft(5);
                    arquivo.WriteLine(linha);
                }
            }
        }
        
        arquivo.Close();

       
    }

    public void DesenharCaminho(Cidade origin,Cidade dest, Graphics g, PictureBox pbxMapa)
    {
        Pen caneta = new Pen(Color.Red);
        caneta.Width = 2;
        
        float x = (float)(pbxMapa.Width * origin.X);
        float y = (float)(pbxMapa.Height * origin.Y);
        float xf = (float)(pbxMapa.Width * dest.X);
        float yf = (float)(pbxMapa.Height * dest.Y);

        g.DrawLine(caneta, x, y, xf, yf);
    }
}
