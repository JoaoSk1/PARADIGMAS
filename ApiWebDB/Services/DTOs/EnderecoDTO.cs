using System;

namespace ApiWebDB.Services.DTOs
{
    public class EnderecoDTO
    {

        /// <example>
        /// 99999999
        /// </example>
        public int Cep { get; set; }

        /// <example>
        /// Rua João Kist
        /// </example>
        public string Logradouro { get; set; }

        /// <example>
        /// 999
        /// </example>
        public string Numero { get; set; }

        /// <example>
        /// Casa
        /// </example>
        public string Complemento { get; set; }

        /// <example>
        /// Belvedere
        /// </example>

        public string Bairro { get; set; }

        /// <example>
        /// Saudades
        /// </example>
        public string Cidade { get; set; }

        /// <example>
        /// SC
        /// </example>
        public string Uf { get; set; }

        /// <example>
        /// 5
        /// </example>
        public int Clienteid { get; set; }

        /// <example>
        /// 1
        /// </example>
        public int Status { get; set; }
    }
}
