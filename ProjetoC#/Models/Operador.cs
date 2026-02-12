using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoC_.Classes
{
    public class Operador
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public byte Admin { get; set; }
        public byte Inativo { get; set; }

        public override string ToString()
        {
            return $"{Codigo} {Nome}";
        }
    }
}