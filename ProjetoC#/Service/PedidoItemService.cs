using ProjetoC_.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ProjetoC_.Service
{
    public class PedidoItemService
    {
        private readonly DatabaseService _dbService = new DatabaseService();

        public async Task<List<PedidoItem>> CarregarItensPedido(int ControlePedido)
        {
            String query = "Select Controle, ControlePedido, Item, ProdutoCodigo, Descricao, Quantidade, ValorUn, ValorTotal " +
            "From PedidoItem " +
            "Where ControlePedido = @ControlePedido " +
            "Order By Item";
            var parametros = new Dictionary<string, object>()
            {
                {"@ControlePedido",ControlePedido}
            };

            List<PedidoItem> resultado = await _dbService.ExecutarConsultaAsync<PedidoItem>(query, parametros);

            return resultado;
        }

        public async Task<int> InserirItemPedido(PedidoItem pedidoItem)
        {
            String query = "INSERT INTO PedidoItem " +
                "(ControlePedido, Item, ProdutoCodigo, Descricao, Quantidade, ValorUn, ValorTotal) " +
                "VALUES (@ControlePedido, @Item, @ProdutoCodigo, @Descricao, @Quantidade, @ValorUn, @ValorTotal)";
            var parametros = new Dictionary<string, object>
            {
                { "@ControlePedido", pedidoItem.ControlePedido},
                { "@Item", pedidoItem.Item},
                { "@ProdutoCodigo", pedidoItem.ProdutoCodigo},
                { "@Descricao", pedidoItem.ProdutoDescricao},
                { "@Quantidade", pedidoItem.Quantidade},
                { "@ValorUn", pedidoItem.ValorUnitario},
                { "@ValorTotal", pedidoItem.ValorTotal}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null ? resultado.NovoId : 0;
        }

        public async Task<bool> AlterarItemPedido(PedidoItem pedidoItem)
        {
            String query = "UPDATE PedidoItem SET " + 
                "Item = @Item, " +
                "ProdutoCodigo = @ProdutoCodigo, " +
                "Descricao = @Descricao, " +
                "Quantidade = @Quantidade, " +
                "ValorUn = @ValorUn, " +
                "ValorTotal = @ValorTotal " +
                "Where Controle = @Controle ";
            var parametros = new Dictionary<string, object>
            {
                { "@Item", pedidoItem.Item},
                { "@ProdutoCodigo", pedidoItem.ProdutoCodigo},
                { "@Descricao", pedidoItem.ProdutoDescricao},
                { "@Quantidade", pedidoItem.Quantidade},
                { "@ValorUn", pedidoItem.ValorUnitario},
                { "@ValorTotal", pedidoItem.ValorTotal},
                { "@Controle", pedidoItem.Controle}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }

        public async Task<bool> ExcluirItemPedido(int controle)
        {
            String query = "Delete from PedidoItem Where Controle = @Controle";
            var parametros = new Dictionary<string, object>
            {
                { "@Controle", controle }
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }
    }
}
