using ProjetoC_.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Service
{
    public class OperadorService
    {

        private readonly DatabaseService _dbService = new DatabaseService();

        public async Task<List<Operador>> CarregarOperadores()
        {

            String query = "Select * from Operador Order By Codigo Asc";
            var parametros = new Dictionary<string, object>();

            List<Operador> resultado = await _dbService.ExecutarConsultaAsync<Operador>(query, parametros);

            return resultado;
        }
    }
}
