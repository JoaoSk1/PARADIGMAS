using ApiWebDB.BaseDados;
using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using ApiWebDB.Services.Parser;
using ApiWebDB.Services.Validate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ApiWebDB.Services
{
    public class ClienteService
    {
        private readonly PostgresContext _dbCDbContext;

        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public ClienteService(PostgresContext dbCDbContext) 
        {
            _dbCDbContext = dbCDbContext;
        }

        public TbCliente Insert(ClienteDTO dto)
        {
            if (!ClienteValidate.Execute(dto))
                return null;

            var entity = ClienteParser.ToEntity(dto);

            _dbCDbContext.Add(entity);
            _dbCDbContext.SaveChanges();

            return entity;
        }
        public TbCliente Update(ClienteDTO dto, int id)
        {
            if (!ClienteValidate.Execute(dto))
                return null;

            var existingEntity = GetById(id);

            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
            }

            var entity = ClienteParser.ToEntity(dto);

            var ClienteById = GetById(id);

            ClienteById.Nome = entity.Nome;
            ClienteById.Nascimento = entity.Nascimento;
            ClienteById.Telefone = entity.Telefone;
            ClienteById.Documento = entity.Documento;
            ClienteById.Tipodoc = entity.Tipodoc;
            ClienteById.Alteradoem = System.DateTime.Now;

            _dbCDbContext.Update(ClienteById);
            _dbCDbContext.SaveChanges();

            return entity;
        }

        public TbCliente GetById(int id)
        {
            var existingEntity = _dbCDbContext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
            }
            return existingEntity;
        }
        public IEnumerable<TbCliente> Get()
        {
            var existingEntity = _dbCDbContext.TbClientes.ToList();

            if (existingEntity == null || existingEntity.Count == 0)
            {
                throw new NotFoundException("Nenhum registro encontrado");
            }
            return existingEntity;
        }
        public void Delete(int id)
        {
            var existingEntity = GetById(id);

            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
            }
            _dbCDbContext.Remove(existingEntity);
            _dbCDbContext.SaveChanges();

        }

        internal object Update(TbCliente existingEntity)
        {
            throw new NotImplementedException();
        }
    }
}
