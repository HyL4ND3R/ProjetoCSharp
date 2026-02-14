using ProjetoC_.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Models
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public eTipoDocumentoCliente TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? Telefone { get; set; }
        public int Inativo { get; set; }

        public override string ToString()
        {
            return $"Codigo = {Codigo} " +
                $"Nome = {Nome} " +
                $"TipoDocumento = {TipoDocumento} " +
                $"Documento = {Documento} " +
                $"Telefone = {Telefone} ";
        }
    }
}
