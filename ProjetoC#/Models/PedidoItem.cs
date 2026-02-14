using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Models
{
    internal class PedidoItem
    {
        public int Controle { get; set; }
        public int ControlePedido { get; set; }
        public int Item { get; set; }
        public int ProdutoCodigo { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
