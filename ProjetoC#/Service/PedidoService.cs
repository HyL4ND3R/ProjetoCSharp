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
            string query = "Select Pedido.Controle Controle, " +
                "Pedido.Codigo Codigo, " +
                "Cliente.Codigo ClienteCodigo, " +
                "Cliente.Nome ClienteNome, " +
                //"FORMAT(Pedido.data,'dd/MM/yyyy') DataPedido, " +
                "Pedido.data DataPedido, " +
                "ISNULL(Pedido.QtdeTotal, 0) QtdeTotal, " +
                "ISNULL(Pedido.ValorTotal, 0) ValorTotal " +
                "from Pedido " +
                "Inner join Cliente on Cliente.Codigo = Pedido.ClienteCodigo " +
                "Order by Pedido.Codigo Asc";
            var parametros = new Dictionary<string, object>();

            List<Pedido> resultado = await _dbService.ExecutarConsultaAsync<Pedido>(query, parametros);

            return resultado;
        }

        public async Task<int> BuscarProximoCodigoDisponivel()
        {
            // Esta query encontra o menor (codigo + 1) que não existe na tabela
            string query = @"
                SELECT ISNULL(MIN(t1.Codigo + 1), 1) AS Proximo 
                FROM Pedido t1 
                WHERE NOT EXISTS (
                    SELECT 1 FROM Pedido t2 WHERE t2.Codigo = t1.Codigo + 1
                )";

            var resultado = await _dbService.ExecutarConsultaAsync<dynamic>(query, null);

            // Se a tabela estiver vazia, retornamos 1, caso contrário o vago encontrado
            return (int)resultado[0].Proximo;
        }

        public async Task<Pedido> BuscarPedidoPorCodigo(int codigo)
        {

            string query = "Select Pedido.Controle Controle, " +
                "Pedido.Codigo Codigo, " +
                "Cliente.Codigo ClienteCodigo, " +
                "Cliente.Nome ClienteNome, " +
                "FORMAT(Pedido.data,'dd/MM/yyyy') DataPedido, " +
                "Pedido.ValorTotal ValorTotal " +
                "from Pedido " +
                "Inner join Cliente on Cliente.Codigo = Pedido.ClienteCodigo " +
                "Where Pedido.Codigo = @Codigo";
            var parametros = new Dictionary<string, object>()
            {
                {"@Codigo",codigo}
            };

            List<Pedido> resultado = await _dbService.ExecutarConsultaAsync<Pedido>(query, parametros);

            if (resultado.Count == 0) return null;
            return resultado[0];
        }

        public async Task<int> InserirPedido(Pedido pedido)
        {
            string query = "Insert into pedido (Codigo, ClienteCodigo, Data) values (@Codigo, @ClienteCodigo, @Data)";
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
            string query = "UPDATE Pedido Set " +
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
            string query = "Delete from Pedido Where Controle = @Controle";
            var parametros = new Dictionary<string, object>
            {
                { "@Controle", controle }
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }

        public async Task<bool> RecalcularTotaisPedido(int controle)
        {
            string query = "EXEC sp_RecalcularTotaisPedido @Controle";

            var parametros = new Dictionary<string, object>
            {
                { "@Controle", controle }
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }
    }
}
