using System;

namespace ApiWebDB.Services.DTOs
{
    public class ClienteDTO
    {
        /// <example>
        /// João Mallmann
        /// </example>
        public string Nome { get; set; }

        /// <example>
        /// 2003-09-24
        /// </example>
        public DateOnly? Nascimento { get; set; }

        /// <example>
        /// 49999999999
        /// </example>
        public string Telefone { get; set; }

        /// <example>
        /// 99999999999
        /// </example>
        public string Documento { get; set; }
       
        /// <summary>
        /// 1 - CPF 2 - CNPJ 3 - Passaporte 4 - CNH 99 - Outros
        /// </summary>
        /// <example>
        /// 3
        /// </example>
        public int Tipodoc { get; set; }
    }
}
