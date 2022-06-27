// André Y. Terada - 20122 Rafael L.Silva - 20734

using System;
using System.IO;
using System.Windows.Forms;
class Cidade : IComparable<Cidade>, IRegistro
{
    public const int tamanhoNome = 14;
    private int indice;
    private string nome;
    private double x, y;
    const int tamanhoRegistro = tamanhoNome + sizeof(double) + sizeof(double);

    public Cidade()
    {
        indice = 0;
        nome = "";
        x = 0;
        y = 0;
    }

    public Cidade(int indice, string nome, double x, double y)
    {
        this.indice = indice;
        this.nome = nome;
        this.x = x;
        this.y = y;
    }
    public Cidade(string nome)
    {
        this.indice = 0;
        this.nome = nome;
    }
    public void LerString(string cidadeStr, int qualRegistro)
    {
        try
        {
            Indice = qualRegistro;
            Nome = cidadeStr.Substring(0, 16).Trim();
            X = double.Parse(cidadeStr.Substring(17, 5));
            Y = double.Parse(cidadeStr.Substring(22, 5));
        }
        catch(Exception e)
        {
            throw new Exception("Não foi possível ler a string! Erro: " + e.Message);
        }
    }
    public void LerRegistro(BinaryReader arquivo, int qualRegistro)
    {
        if (arquivo != null)
            try
            {
                int qtosBytes = qualRegistro * TamanhoRegistro;
                arquivo.BaseStream.Seek(qtosBytes, SeekOrigin.Begin);
                this.Indice = qualRegistro;
                char[] umNome = new char[tamanhoNome];
                umNome = arquivo.ReadChars(tamanhoNome);
                string nomeLido = "";
                for (int i = 0; i < tamanhoNome; i++)
                    nome += umNome[i];
                Nome = nomeLido;
                this.X = arquivo.ReadDouble();
                this.Y = arquivo.ReadDouble();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
    }

    public void GravarRegistro(StreamWriter arquivo)
    {
        if (arquivo != null)
        {
            string linha = Nome.PadRight(15) + " " + Math.Round(X,3).ToString().PadRight(5,'0') + " " + Math.Round(Y, 3).ToString().PadRight(5, '0');
            arquivo.WriteLine(linha);
        }
    }

    public string Nome { get => nome; set => nome = value; }
    public int Indice { get => indice; set => indice = value; }
    public int TamanhoRegistro { get => tamanhoRegistro; }
    public double X { get => x; set { if(x >= 0) x = value; } }
    public double Y { get => y; set { if(x >= 0) y = value; } }

    public int CompareTo(Cidade outraCidade)
    {
        return nome.CompareTo(outraCidade.nome);
    }

    public override string ToString()
    {
        return Nome;
    }
}