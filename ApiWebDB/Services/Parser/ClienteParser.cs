using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using ApiWebDB.Services.Validate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ApiWebDB.Services.Parser
{
    public static class ClienteParser
    {
        public static TbCliente ToEntity(ClienteDTO dto)
        {

            var time = new TimeOnly(0, 0);
            var nascimento = new DateTime((DateOnly)dto.Nascimento, time);

            return new TbCliente
            {
                Nascimento = nascimento,
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Tipodoc = dto.Tipodoc,
                Documento = dto.Documento,
                Criadoem = DateTime.Now,
                Alteradoem = DateTime.Now,
            };

        }
        public static void UpdateEntityFromDTO(ClienteDTO dto, TbCliente entity)
        {
            var time = new TimeOnly(0, 0);
            var nascimento = new DateTime(
                (DateOnly)dto.Nascimento, time);

            entity.Nome = dto.Nome;
            entity.Nascimento = nascimento;
            entity.Telefone = dto.Telefone;
            entity.Tipodoc = dto.Tipodoc;
            entity.Documento = dto.Documento;
            entity.Alteradoem = DateTime.Now; // Atualiza a data de alteração
        }
    }
}
