using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using System;

namespace ApiWebDB.Services.Validate
{
    public class ClienteValidate
    {
        private static bool ValidateDocument(TipoDocumento tipo, string documento)
        {
            switch (tipo)
            {
                case TipoDocumento.CPF:
                    if (documento.Length != 11)
                        throw new BadRequestException("O CPF precisa ter 11 dígitos.");
                    return true;
                case TipoDocumento.CNPJ:
                    if (documento.Length != 14)
                        throw new BadRequestException("O CNPJ precisa ter 14 dígitos.");
                    return true;
                case TipoDocumento.Passaporte:
                    if (documento.Length != 8)
                        throw new BadRequestException("O Passaporte precisa ter 8 dígitos.");
                    return true;
                case TipoDocumento.CNH:
                    if (documento.Length != 11)
                        throw new BadRequestException("A CNH precisa ter 11 dígitos.");
                    return true;
                default:
                    return true;
            }
        }
        public static bool Execute(ClienteDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Nome))
                throw new InvalidEntity("Campo Nome é obrigatório.");

            if(string.IsNullOrEmpty(dto.Documento))
                throw new InvalidEntity("Campo Documento é obrigatório.");

            if (dto.Tipodoc <= 0)
                throw new InvalidEntity("Campo TipoDoc é obrigatório");

            TipoDocumento tipo;
            try
            {
                tipo = (TipoDocumento)dto.Tipodoc;
                
            }
            catch 
            {
                throw new InvalidEntity($"O TipoDoc {dto.Tipodoc} é inválido.");
            }

            return ValidateDocument(tipo, dto.Documento);
        }

    }
}
