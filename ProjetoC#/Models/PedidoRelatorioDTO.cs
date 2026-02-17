using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Models
{
    public class PedidoRelatorioDTO
    {
        public int PedidoCodigo { get; set; }
        public int ClienteCodigo { get; set; }
        public string ClienteNome { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal? QuantidadeTotalPedido { get; set; }
        public decimal? ValorTotalPedido { get; set; }
        public int ProdutoCodigo { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal ProdutoQuantidade { get; set; }
        public decimal ProdutoValorUn { get; set; }
        public decimal ProdutoValorTotal { get; set; }
    }
}
