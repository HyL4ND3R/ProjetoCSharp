using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Models
{
    public class Pedido
    {
        public int Controle { get; set; }
        public int Codigo { get; set; }
        public int ClienteCodigo { get; set; }
        public string? ClienteNome { get; set; }
        public DateTime DataPedido { get; set; }
        public Decimal ValorTotal { get; set; }

        public override string ToString()
        {
            return $"Codigo = {Codigo} " +
                $"CodigoCliente = {ClienteCodigo} " +
                $"NomeCliente = {ClienteNome} " +
                $"DataPedido = {DataPedido} " +
                $"ValorTotal = {ValorTotal}";
        }
    }
}
