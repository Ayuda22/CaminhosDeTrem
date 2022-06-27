// André Y. Terada - 20122 Rafael L.Silva - 20734

using System;
using System.IO;

interface IRegistro
{
    void LerString(string str, int qualRegistro);
    void LerRegistro(BinaryReader arquivo, int qualRegistro);
    void GravarRegistro(StreamWriter arquivo);
    int TamanhoRegistro { get; }
    int Indice { get; set; }

}