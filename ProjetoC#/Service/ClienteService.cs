using ProjetoC_.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Service
{
    internal class ClienteService
    {
        private readonly DatabaseService _dbService = new DatabaseService();

        public async Task<List<Cliente>> CarregarClientes()
        {

            String query = "Select * from Cliente Order By Codigo Asc";
            var parametros = new Dictionary<string, object>();

            List<Cliente> resultado = await _dbService.ExecutarConsultaAsync<Cliente>(query, parametros);

            return resultado;
        }

        public async Task<Cliente> BuscarClientePorCodigo(int codigo)
        {

            String query = "Select * from Cliente Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>()
            {
                {"@Codigo",codigo}
            };

            List<Cliente> resultado = await _dbService.ExecutarConsultaAsync<Cliente>(query, parametros);

            return resultado[0];
        }

        public async Task<int> InserirCliente(Cliente cliente)
        {
            String query = "Insert into Cliente (Nome, TipoDocumento, Documento, Telefone, Inativo) " +
                "Values (@Nome, @TipoDocumento, @Documento, @Telefone, @Inativo)";
            var parametros = new Dictionary<string, object>
            {
                { "@Nome", cliente.Nome },
                { "@TipoDocumento", cliente.TipoDocumento },
                { "@Documento", cliente.Documento},
                { "@Telefone", cliente.Telefone},
                { "@Inativo", cliente.Inativo}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null ? resultado.NovoId : 0;
        }
        public async Task<bool> AlterarCliente(Cliente cliente)
        {
            String query = "UPDATE Cliente " +
                "Set Nome = @Nome, TipoDocumento = @TipoDocumento, Documento = @Documento, Telefone = @Telefone, Inativo = @Inativo " +
                "Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>
            {
                { "@Nome", cliente.Nome },
                { "@TipoDocumento", cliente.TipoDocumento },
                { "@Documento", cliente.Documento},
                { "@Telefone", cliente.Telefone},
                { "@Inativo", cliente.Inativo},
                { "@Codigo", cliente.Codigo}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }

        public async Task<bool> ExcluirCliente(int codigo)
        {
            String query = "Delete from Cliente Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>
            {
                { "@Codigo", codigo }
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }
    }
}
