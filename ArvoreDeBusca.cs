// André Y. Terada - 20122 Rafael L.Silva - 20734

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace CaminhosDeTrem
{
    class ArvoreDeBusca<Dado> where Dado : IComparable<Dado>, IRegistro, new()
    {
        NoArvore<Dado> raiz,
                       atual,       // indica o nó que está sendo visitado no momento
                       antecessor;  // indica o nó ancestral daquele que está sendo visitado no momento

        int[] quantosNoNivel = new int[1000];
        bool achou = false;
        public PictureBox painelArvore;

        public PictureBox OndeExibir
        {
            get => painelArvore;
            set => painelArvore = value;
        }

        public ArvoreDeBusca()
        {
            raiz = null;
            atual = null;
            antecessor = null;
        }

        public NoArvore<Dado> Raiz
        {
            get => raiz; set => raiz = value;
        }
        public NoArvore<Dado> Atual { get => atual; set => atual = value; }

        public String InOrdem  // propriedade que gera a string do percurso in-ordem da árvore
        {
            get { return FazInOrdem(raiz); }
        }
        public String PreOrdem  // propriedade que gera a string do percurso pre-ordem da árvore
        {
            get { return FazPreOrdem(raiz); }
        }
        public String PosOrdem  // propriedade que gera a string do percurso pos-ordem da árvore
        {
            get { return FazPosOrdem(raiz); }
        }

        private String FazInOrdem(NoArvore<Dado> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia

            return FazInOrdem(r.Esq) + " " +
                   r.Info.ToString() + " " +
                   FazInOrdem(r.Dir);
        }
        private String FazPreOrdem(NoArvore<Dado> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia

            return r.Info.ToString() + " " +
                   FazPreOrdem(r.Esq) + " " +
                   FazPreOrdem(r.Dir);
        }
        private String FazPosOrdem(NoArvore<Dado> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia

            return FazPosOrdem(r.Esq) + " " +
                   FazPosOrdem(r.Dir) + " " +
                   r.Info.ToString();
        }

        private bool Eq(NoArvore<Dado> atualA,
                        NoArvore<Dado> atualB)
        {
            if (atualA == null && atualB == null)
                return true;

            if ((atualA == null) != (atualB == null)) // apenas um dos nós é
                return false; // uma é nulo e outra não é

            // os dois nós não são nulos
            if (atualA.Info.CompareTo(atualB.Info) != 0)
                return false; // Infos diferentes

            return Eq(atualA.Esq, atualB.Esq) &&
                   Eq(atualA.Dir, atualB.Dir);
        }

        public bool EquivaleA(ArvoreDeBusca<Dado> outraArvore)
        {
            /* . ambas são vazias
            ou
            .. Info(A) = Info(B) e
            ... Esq(A) eq Esq(B) e Dir(A) eq Dir(B)
            */
            return Eq(this.raiz, outraArvore.raiz);
        }

        private int QtosNos(NoArvore<Dado> noAtual)
        {
            if (noAtual == null)  // árvore vazia ou descendente de folha
                return 0;

            return 1 +                 // conta o nó atual
                QtosNos(noAtual.Esq) + // conta nós da subárvore esquerda
                QtosNos(noAtual.Dir);  // conta nós da subárvore direita
        }
        public int QtosNos()
        {
            return QtosNos(raiz);
        }

        private int QtasFolhas(NoArvore<Dado> noAtual)
        {
            if (noAtual == null)
                return 0;
            if (noAtual.Esq == null && noAtual.Dir == null) // noAtual é folha
                return 1;

            // noAtual não é folha, portanto procuramos as folhas de cada ramo e as contamos
            return QtasFolhas(noAtual.Esq) + // conta folhas da subárvore esquerda
                   QtasFolhas(noAtual.Dir); // conta folhas da subárvore direita
        }
        public int QtasFolhas()
        {
            return QtasFolhas(raiz);
        }

        private bool EstritamenteBinaria(NoArvore<Dado> noAtual)
        {
            if (noAtual == null)
                return true;

            // noAtual não é nulo
            if (noAtual.Esq == null && noAtual.Dir == null)
                return true;

            // um dos descendentes é nulo e o outro não é
            if (noAtual.Esq == null && noAtual.Dir != null)
                return false;
            if (noAtual.Esq != null && noAtual.Dir == null)
                return false;

            // se chegamos aqui, nenhum dos descendentes é nulo, dai testamos a
            // "estrita binariedade" das duas subárvores descendentes do nó atual
            return EstritamenteBinaria(noAtual.Esq) &&
                   EstritamenteBinaria(noAtual.Dir);
        }
        public bool EstritamenteBinaria()
        {
            return EstritamenteBinaria(raiz);
        }

        private int Altura(NoArvore<Dado> noAtual)
        {
            int alturaEsquerda,
                alturaDireita;
            if (noAtual == null)
                return 0;
            alturaEsquerda = Altura(noAtual.Esq);
            alturaDireita = Altura(noAtual.Dir);
            if (alturaEsquerda >= alturaDireita)
                return 1 + alturaEsquerda;
            return 1 + alturaDireita;
        }
        public int Altura()
        {
            return Altura(raiz);
        }

        private string EntreParenteses(NoArvore<Dado> noAtual)
        {
            string saida = "(";
            if (noAtual != null)
                saida += noAtual.Info + ":" +
                EntreParenteses(noAtual.Esq) +
                "," +
                EntreParenteses(noAtual.Dir);
            saida += ")";
            return saida;
        }
        public string EntreParenteses()
        {
            return EntreParenteses(raiz);
        }

        private void Trocar(NoArvore<Dado> noAtual)
        {
            if (noAtual != null)
            {
                NoArvore<Dado> auxiliar = noAtual.Esq;
                noAtual.Esq = noAtual.Dir;
                noAtual.Dir = auxiliar;
                Trocar(noAtual.Esq);
                Trocar(noAtual.Dir);
            }
        }
        public void Trocar()
        {
            Trocar(raiz);
        }

        private string PercursoPorNiveis(NoArvore<Dado> noAtual)
        {
            string saida = "";
            //Filalista<NoArvore<Dado>> umaFila = new FilaLista<NoArvore<Dado>>();

            var umaFila = new Queue<NoArvore<Dado>>();
            while (noAtual != null)
            {
                if (noAtual.Esq != null)
                    umaFila.Enqueue(noAtual.Esq);
                if (noAtual.Dir != null)
                    umaFila.Enqueue(noAtual.Dir);
                saida += " " + noAtual.Info;
                if (umaFila.Count == 0)
                    noAtual = null;
                else
                    noAtual = umaFila.Dequeue();
            }
            return saida;
        }
        public string PercursoPorNiveis()
        {
            return PercursoPorNiveis(raiz);
        }

        private int Largura(NoArvore<Dado> noAtual)
        {
            for (int i = 0; i < 1000; i++)
                quantosNoNivel[i] = 0;
            ContarNosNosNiveis(noAtual, 0);
            // acha o nível com o maior contador de nós
            int indiceMaior = 0;
            for (int i = 0; i < 1000; i++)
                if (quantosNoNivel[i] > quantosNoNivel[indiceMaior])
                    indiceMaior = i;
            return quantosNoNivel[indiceMaior];
        }
        public int Largura()
        {
            return Largura(raiz);
        }
       
        public void ContarNosNosNiveis(NoArvore<Dado> noAtual, int qualNivel)
        {
            if (noAtual != null)
            {
                ++quantosNoNivel[qualNivel];
                ContarNosNosNiveis(noAtual.Esq, qualNivel + 1);
                ContarNosNosNiveis(noAtual.Dir, qualNivel + 1);
            }
        }

        private string EscreverAntecessores(NoArvore<Dado> atual, Dado procurado)
        {
            string saida = "";
            if (atual != null)
            {
                if (!achou)
                    EscreverAntecessores(atual.Esq, procurado);
                if (!achou)
                    EscreverAntecessores(atual.Dir, procurado);
                if (atual.Info.CompareTo(procurado) == 0)
                    achou = true;
                if (achou)
                    saida += " " + atual.Info;
            }
            return saida;
        }
        public string PreparaEscritaDosAntecessores(Dado procurado)
        {
            achou = false;
            return EscreverAntecessores(Raiz, procurado);
        }
        
        public void DesenharArvore(bool primeiraVez, NoArvore<Cidade> raiz,
                                  int x, int y, double angulo, double incremento,
                                  double comprimento, Graphics g)
        {
            int xf, yf;
            if (raiz != null)
            {
                Pen caneta = new Pen(Color.Red);
                xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento);
                yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento);

                if (primeiraVez)
                    yf = 25;

                g.DrawLine(caneta, x, y, xf, yf);
                DesenharArvore(false, raiz.Esq, xf, yf, Math.PI / 2 + incremento,
                                       incremento * 0.75, comprimento * 0.60, g);
                DesenharArvore(false, raiz.Dir, xf, yf, Math.PI / 2 - incremento,
                                        incremento * 0.75, comprimento * 0.60, g);
                SolidBrush preenchimento = new SolidBrush(Color.MediumAquamarine);
                g.FillEllipse(preenchimento, xf - 25, yf - 15, 42, 30);
                g.DrawString(Convert.ToString(raiz.Info.ToString()),
                             new Font("Comic Sans", 10),
                             new SolidBrush(Color.Black), xf - 23, yf - 7);
            }
        }
        public bool Existe(Dado procurado)
        {
            antecessor = null;
            atual = raiz;
            while (atual != null)
            {
                if (atual.Info.CompareTo(procurado) == 0) // atual aponta o nó com o registro procurado, antecessor aponta seu "pai"
                    return true;

                antecessor = atual;
                if (procurado.CompareTo(atual.Info) < 0)
                    atual = atual.Esq;     // Desloca apontador para o ramo à esquerda
                else
                    atual = atual.Dir;     // Desloca apontador para o ramo à direita
            }
            return false;       // Se local == null, a chave não existe
        }
        private bool ExisteRec(NoArvore<Dado> local, Dado procurado)
        {
            if (local == null)
                return false;
            else
              if (local.Info.CompareTo(procurado) == 0)
            {
                atual = local;
                return true;
            }
            else
            {
                antecessor = local;
                if (procurado.CompareTo(local.Info) < 0)
                    return ExisteRec(local.Esq, procurado);	 // Desloca apontador na 
                else                                         // próxima instância do 
                    return ExisteRec(local.Dir, procurado);	 // método
            }
        }
        public bool ExisteRegistro(Dado procurado)
        {
            return ExisteRec(raiz, procurado);
        }

        public void Incluir(Dado dadoLido)
        {
            Incluir(ref raiz, dadoLido);
        }
        private void Incluir(ref NoArvore<Dado> atual, Dado dadoLido)
        {
            if (atual == null)
            {
                atual = new NoArvore<Dado>(dadoLido);
            }
            else if (dadoLido.CompareTo(atual.Info) == 0)
                throw new Exception("Já existe esse registro!");
            else if (dadoLido.CompareTo(atual.Info) > 0)
            {
                NoArvore<Dado> apDireito = atual.Dir;
                Incluir(ref apDireito, dadoLido);
                atual.Dir = apDireito;
            }
            else
            {
                NoArvore<Dado> apEsquerdo = atual.Esq;
                Incluir(ref apEsquerdo, dadoLido);
                atual.Esq = apEsquerdo;
            }
        }

        public void LerArquivoDeRegistros(string nomeArquivo)
        {
            string[] linhasTxt = File.ReadAllLines(nomeArquivo);
            Array.Sort(linhasTxt);

            raiz = null;
            Dado dado;
            try
            {
                Particionar(0, linhasTxt.Length - 1, ref raiz);
                void Particionar(int inicio, int fim, ref NoArvore<Dado> atual)
                {
                    if (inicio <= fim)
                    {
                        int meio = (inicio + fim) / 2;

                        dado = new Dado();       // cria um objeto para armazenar os dados
                        dado.LerString(linhasTxt[meio], meio); // 
                        atual = new NoArvore<Dado>(dado);
                        var novoEsq = atual.Esq;
                        Particionar(inicio, meio - 1, ref novoEsq);   // Particiona à esquerda 
                        atual.Esq = novoEsq;
                        var novoDir = atual.Dir;
                        Particionar(meio + 1, fim, ref novoDir);        // Particiona à direita  
                        atual.Dir = novoDir;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }



        }
        public void GravarArquivoDeRegistros(string nomeArquivo)
        {
            using StreamWriter arquivo = new StreamWriter(nomeArquivo);
            GravarInOrdem(raiz);
            arquivo.Close();

            void GravarInOrdem(NoArvore<Dado> r)
            {
                if (r != null)
                {
                    GravarInOrdem(r.Esq);

                    r.Info.GravarRegistro(arquivo);

                    GravarInOrdem(r.Dir);
                }
            }
        }

        public void Inserir(Dado novosDados)
        {
            bool achou = false, fim = false;
            NoArvore<Dado> novoNo = new NoArvore<Dado>(novosDados);
            if (raiz == null)         // árvore vazia
                raiz = novoNo;
            else                      // árvore não-vazia
            {
                antecessor = null;
                atual = raiz;
                while (!achou && !fim)
                {
                    antecessor = atual;
                    if (novosDados.CompareTo(atual.Info) < 0)
                    {
                        atual = atual.Esq;
                        if (atual == null)
                        {
                            antecessor.Esq = novoNo;
                            fim = true;
                        }
                    }
                    else
                        if (novosDados.CompareTo(atual.Info) == 0)
                        achou = true;  // pode-se disparar uma exceção neste caso
                    else
                    {
                        atual = atual.Dir;
                        if (atual == null)
                        {
                            antecessor.Dir = novoNo;
                            fim = true;
                        }
                    }
                }
            }
        }
        public void IncluirNovoRegistro(Dado novoRegistro)
        {
            if (Existe(novoRegistro))
                throw new Exception("Registro com chave repetida!");
            else
            {
                // o novoRegistro tem uma chave inexistente, então criamos 
                // um novo nó para armazená-lo e depois ligamos esse nó na
                // árvore
                var novoNo = new NoArvore<Dado>(novoRegistro);

                // se a árvore está vazia, a raiz passará a apontar esse novo nó
                if (raiz == null)
                    raiz = novoNo;
                else
                  // nesse caso, antecessor aponta o pai do novo registro e
                  // verificamos em qual ramo o novo nó será ligado
                  if (novoRegistro.CompareTo(antecessor.Info) < 0)  // novo é menor que antecessor 
                    antecessor.Esq = novoNo;        // vamos para a esquerda
                else
                    antecessor.Dir = novoNo;		 // ou vamos para a direita

            }
        }
        public bool Excluir(Dado procurado)
        {
            return Excluir(ref raiz);


            bool Excluir(ref NoArvore<Dado> atual)
            {
                NoArvore<Dado> atualAnt;
                if (atual == null)
                    return false;
                else if (atual.Info.CompareTo(procurado) > 0)
                {
                    var temp = atual.Esq;
                    bool result = Excluir(ref temp);
                    atual.Esq = temp;
                    return result;
                }
                else if (atual.Info.CompareTo(procurado) < 0)
                {
                    var temp = atual.Dir;
                    bool result = Excluir(ref temp);
                    atual.Dir = temp;
                    return result;
                }
                else
                {
                    int indice = atual.Info.Indice;
                    atualAnt = atual;   // nó a retirar 
                    if (atual.Dir == null)
                        atual = atual.Esq;
                    else if (atual.Esq == null)
                        atual = atual.Dir;
                    else
                    {   // pai de 2 filhos 
                        var temp = atual.Esq;
                        Rearranjar(ref temp, ref atualAnt);
                        atual.Esq = temp;
                        atualAnt = null;  // libera o nó excluído
                    }
                    CorrigirIndices(raiz, indice);
                    return true;
                }
                void CorrigirIndices(NoArvore<Dado> dado, int indice)
                {
                    if (dado != null)
                    {
                        CorrigirIndices(dado.Esq, indice);
                        if(dado.Info.Indice > indice)
                            dado.Info.Indice--;
                        CorrigirIndices(dado.Dir, indice);
                    }
                }
            }


            void Rearranjar(ref NoArvore<Dado> aux, ref NoArvore<Dado> atualAnt)
            {
                if (aux.Dir != null)
                {
                    NoArvore<Dado> temp = aux.Dir;
                    Rearranjar(ref temp, ref atualAnt);  // Procura Maior
                    aux.Dir = temp;
                }
                else
                {                           // Guarda os dados do nó a excluir
                    atualAnt.Info = aux.Info;   // troca conteúdo!
                    atualAnt = aux;             // funciona com a passagem por referência
                    aux = aux.Esq;
                }
            }

        }

        public bool ApagarNo(Dado registroARemover)
        {
            atual = raiz;
            antecessor = null;
            bool ehFilhoEsquerdo = true;
            while (atual.Info.CompareTo(registroARemover) != 0)  // enqto não acha a chave a remover
            {
                antecessor = atual;
                if (atual.Info.CompareTo(registroARemover) > 0)
                {
                    ehFilhoEsquerdo = true;
                    atual = atual.Esq;
                }
                else
                {
                    ehFilhoEsquerdo = false;
                    atual = atual.Dir;
                }

                if (atual == null)  // neste caso, a chave a remover não existe e não pode
                    return false;   // ser excluída, dai retornamos falso indicando isso
            }  // fim do while

            // se fluxo de execução vem para este ponto, a chave a remover foi encontrada
            // e o ponteiro atual indica o nó que contém essa chave

            if ((atual.Esq == null) && (atual.Dir == null))  // é folha, nó com 0 filhos
            {
                if (atual == raiz)
                    raiz = null;   // exclui a raiz e a árvore fica vazia
                else
                    if (ehFilhoEsquerdo)        // se for filho esquerdo, o antecessor deixará 
                    antecessor.Esq = null;  // de ter um descendente esquerdo
                else                        // se for filho direito, o antecessor deixará de 
                    antecessor.Dir = null;  // apontar para esse filho

                atual = antecessor;  // feito para atual apontar um nó válido ao sairmos do método
            }
            else   // verificará as duas outras possibilidades, exclusão de nó com 1 ou 2 filhos
                if (atual.Dir == null)   // neste caso, só tem o filho esquerdo
            {
                if (atual == raiz)
                    raiz = atual.Esq;
                else
                    if (ehFilhoEsquerdo)
                    antecessor.Esq = atual.Esq;
                else
                    antecessor.Dir = atual.Esq;
                atual = antecessor;
            }
            else
                    if (atual.Esq == null)  // neste caso, só tem o filho direito
            {
                if (atual == raiz)
                    raiz = atual.Dir;
                else
                    if (ehFilhoEsquerdo)
                    antecessor.Esq = atual.Dir;
                else
                    antecessor.Dir = atual.Dir;
                atual = antecessor;
            }
            else // tem os dois descendentes
            {
                NoArvore<Dado> menorDosMaiores = ProcuraMenorDosMaioresDescendentes(atual);
                atual.Info = menorDosMaiores.Info;
                menorDosMaiores = null; // para liberar o nó trocado da memória
            }
            return true;
        }

        public NoArvore<Dado> ProcuraMenorDosMaioresDescendentes(NoArvore<Dado> noAExcluir)
        {
            NoArvore<Dado> paiDoSucessor = noAExcluir;
            NoArvore<Dado> sucessor = noAExcluir;
            NoArvore<Dado> atual = noAExcluir.Dir;   // vai ao ramo direito do nó a ser excluído, pois este ramo contém
            // os descendentes que são maiores que o nó a ser excluído 
            while (atual != null)
            {
                if (atual.Esq != null)
                    paiDoSucessor = atual;
                sucessor = atual;
                atual = atual.Esq;
            }

            if (sucessor != noAExcluir.Dir)
            {
                paiDoSucessor.Esq = sucessor.Dir;
                sucessor.Dir = noAExcluir.Dir;
            }
            return sucessor;
        }

        public int AlturaArvore(NoArvore<Dado> atual, ref bool balanceada)
        {
            int alturaDireita, alturaEsquerda, result;
            if (atual != null && balanceada)
            {
                alturaEsquerda = 1 + AlturaArvore(atual.Esq, ref balanceada);
                alturaDireita = 1 + AlturaArvore(atual.Dir, ref balanceada);
                result = Math.Max(alturaEsquerda, alturaDireita);

                //if (alturaDireita > alturaEsquerda)
                //    result = alturaDireita;
                //else
                //  result = alturaEsquerda;

                if (Math.Abs(alturaDireita - alturaEsquerda) > 1)
                    balanceada = false;
            }
            else
                result = 0;
            return result;
        }

        public string[] GetCidades()
        {
            string[] cidades = new string[QtosNos()];
            int count = 0;
            GetCidades(Raiz);
            void GetCidades(NoArvore<Dado> dado)
            {
                if (dado != null)
                {
                    GetCidades(dado.Esq);

                    cidades[count] = dado.Info.ToString();
                    count++;

                    GetCidades(dado.Dir);
                }
            }
            return cidades;
        }
    }
}
