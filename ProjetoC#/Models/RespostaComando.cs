using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Models
{
    public class RespostaComando
    {
        public String Mensagem { get; set; } = "";
        public int LinhasAfetadas { get; set; }
        public int NovoId { get; set; } // Para operações de Insert, pode retornar o ID gerado (se aplicável)
    }
}