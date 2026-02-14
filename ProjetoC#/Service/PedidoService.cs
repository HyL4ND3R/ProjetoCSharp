using ProjetoC_.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Service
{
    public class PedidoService
    {
        private readonly DatabaseService _dbService = new DatabaseService();

        public async Task<List<Pedido>> CarregarPedidos()
        {
            String query = "Select Pedido.Controle Controle, " +
                "Pedido.Codigo Codigo, " +
                "Cliente.Codigo ClienteCodigo, " +
                "Cliente.Nome ClienteNome, " +
                "FORMAT(Pedido.data,'dd/MM/yyyy') DataPedido, " +
                "Pedido.ValorTotal ValorTotal " +
                "from Pedido " +
                "Inner join Cliente on Cliente.Codigo = Pedido.ClienteCodigo " +
                "Order by Pedido.Codigo Asc";
            var parametros = new Dictionary<string, object>();

            List<Pedido> resultado = await _dbService.ExecutarConsultaAsync<Pedido>(query, parametros);

            return resultado;
        }

        public async Task<Pedido> BuscarPedidoPorCodigo(int codigo)
        {

            String query = "Select Pedido.Controle Controle, " +
                "Pedido.Codigo Codigo, " +
                "Cliente.Codigo ClienteCodigo, " +
                "Cliente.Nome ClienteNome, " +
                "FORMAT(Pedido.data,'dd/MM/yyyy') DataPedido, " +
                "Pedido.ValorTotal ValorTotal " +
                "from Pedido " +
                "Inner join Cliente on Cliente.Codigo = Pedido.ClienteCodigo " +
                "Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>()
            {
                {"@Codigo",codigo}
            };

            List<Pedido> resultado = await _dbService.ExecutarConsultaAsync<Pedido>(query, parametros);

            return resultado[0];
        }

        public async Task<int> InserirPedido(Pedido pedido)
        {
            String query = "Insert into pedido (Codigo, ClienteCodigo, Data) values (@Codigo, @ClienteCodigo, @Data)";
            var parametros = new Dictionary<string, object>
            {
                { "@Codigo", pedido.Codigo},
                { "@ClienteCodigo", pedido.ClienteCodigo},
                { "@Data", pedido.DataPedido}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null ? resultado.NovoId : 0;
        }

        public async Task<bool> AlterarPedido(Pedido pedido)
        {
            String query = "UPDATE Pedido Set " +
                "Codigo = @Codigo, " +
                "ClienteCodigo = @ClienteCodigo, " +
                "Data = @Data " +
                "Where Controle = @Controle";
            var parametros = new Dictionary<string, object>
            {
                { "@Codigo", pedido.Codigo},
                { "@ClienteCodigo", pedido.ClienteCodigo},
                { "@Data", pedido.DataPedido},
                { "@Controle", pedido.Controle}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }

        public async Task<bool> ExcluirPedido(int controle)
        {
            String query = "Delete from Pedido Where Controle = @Controle";
            var parametros = new Dictionary<string, object>
            {
                { "@Controle", controle }
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }
    }
}
