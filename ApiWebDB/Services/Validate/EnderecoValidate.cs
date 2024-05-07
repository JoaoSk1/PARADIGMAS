using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using System;

namespace ApiWebDB.Services.Validate
{
    public class EnderecoValidate 
    {
        public enum UFsValidas
        {
            AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO
        }

        public static bool Execute(EnderecoDTO dto)
        {

            if (dto.Cep.ToString().Length != 8)
            {
                throw new BadRequestException("O CEP precisa ter 8 digitos");
            }

            if (string.IsNullOrEmpty(dto.Logradouro))
            {
                throw new InvalidEntity("Campo Logradouro é obrigatório");
            }
            if (string.IsNullOrEmpty(dto.Numero))
            {
                throw new InvalidEntity("Campo Numero é obrigatório");
            }
            if (string.IsNullOrEmpty(dto.Bairro))
            {
                throw new InvalidEntity("Campo Bairro é obrigatório");
            }
            if (string.IsNullOrEmpty(dto.Cidade))
            {
                throw new ("Campo Cidade é obrigatório");
            }
            if (dto.Clienteid <= 0)
            {
                throw new InvalidEntity("Campo Clienteid é obrigatório");
            }
            if (dto.Status < 0 || dto.Status > 1)
            {
                throw new InvalidEntity("O Status informado é inválido. Status aceito: 0 - inativo; 1 - ativo;");
            }
            ValidateUF(dto.Uf);
            return true;
        }

        private static void ValidateUF(string uf)
        {
            uf = uf.ToUpper();

            if (!Enum.TryParse<UFsValidas>(uf, out UFsValidas ufValidas)) // Tenta converter a entrada para o enum
            {
                throw new BadRequestException("Não foi informada uma UF válida (Estado Brasileiro)");
            }
        }
    }
}
