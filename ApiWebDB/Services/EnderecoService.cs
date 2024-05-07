using ApiWebDB.BaseDados.Models;
using ApiWebDB.BaseDados;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Parser;
using ApiWebDB.Services.Validate;
using System.Collections.Generic;
using System.Linq;
using ApiWebDB.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ApiWebDB.Services
{
    public class EnderecoService
    {
        private readonly PostgresContext _dbCDbContext;
        public EnderecoService(PostgresContext dbCDbContext)
        {
            _dbCDbContext = dbCDbContext;
        }

        public TbEndereco Insert(EnderecoDTO dto)
        {

            if (!EnderecoValidate.Execute(dto))
            {
                return null;
            }

            var entity = EnderecoParser.ToEntity(dto);

            _dbCDbContext.Add(entity);
            _dbCDbContext.SaveChanges();

            return entity;
        }
        public IEnumerable<TbEndereco> Get()
        {
            var existingEntity = _dbCDbContext.TbEnderecos.ToList();

            if (existingEntity == null || existingEntity.Count == 0)
            {
                throw new NotFoundException("Nenhum registro foi encontrado");
            }
            return existingEntity;
        }
        public TbEndereco Update(EnderecoDTO dto, int id)
        {
            var existingEntity = GetById(id);

            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
            }

            if (!EnderecoValidate.Execute(dto))
                return null;

            var entity = EnderecoParser.ToEntity(dto);

            var endereco = GetById(id);

            endereco.Cep = entity.Cep;
            endereco.Logradouro = entity.Logradouro;
            endereco.Numero = entity.Numero;
            endereco.Complemento = entity.Complemento;
            endereco.Bairro = entity.Bairro;
            endereco.Cidade = entity.Cidade;
            endereco.Uf = entity.Uf;
            endereco.Status = entity.Status;
            endereco.Clienteid = entity.Clienteid;

            _dbCDbContext.Update(endereco);
            _dbCDbContext.SaveChanges();

            return entity;
        }
        public TbEndereco GetById(int id)
        {
            var existingEntity = _dbCDbContext.TbEnderecos.FirstOrDefault(c => c.Id == id);

            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
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
        public IEnumerable<TbEndereco> GetByIdEnder(int id)
        {
            var existingEntity = _dbCDbContext.TbEnderecos.Where(c => c.Clienteid == id).ToList();

            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
            }

            return existingEntity;
        }
    }
}
