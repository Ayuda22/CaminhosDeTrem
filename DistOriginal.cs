// André Y. Terada - 20122 Rafael L.Silva - 20734

class DistOriginal
{
    private int distancia;
    private int verticePai;
    private int preco;

    public DistOriginal(int vp, int d, int p)
    {
        distancia = d;
        verticePai = vp;
        preco = p;
    }

    public int Distancia { get => distancia; set => distancia = value; }
    public int VerticePai { get => verticePai; set => verticePai = value; }
    public int Preco { get => preco; set => preco = value; }
    public int Hora { get => Distancia / 200; }
    public int Min { get => (int)( Distancia % 200.0 / 10.0 * 3); }
}

