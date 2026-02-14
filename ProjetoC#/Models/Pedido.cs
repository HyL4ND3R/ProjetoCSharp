using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Models
{
    internal class Pedido
    {
        public int Controle { get; set; }
        public int Codigo { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public Decimal ValorTotal { get; set; }

        public override string ToString()
        {
            return $"Codigo = {Codigo} " +
                $"CodigoCliente = {Cliente.Codigo} " +
                $"NomeCliente = {Cliente.Nome} " +
                $"DataPedido = {DataPedido} " +
                $"ValorTotal = {ValorTotal}";
        }
    }
}
