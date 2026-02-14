using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Models
{
    internal class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public byte Inativo { get; set; }

        public override string ToString()
        {
            return $"Codigo = {Codigo} " +
                $"Nome = {Nome} " +
                $"Valor = {Valor} ";
        }
    }
}
