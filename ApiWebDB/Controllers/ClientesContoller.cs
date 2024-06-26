﻿using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiWebDB.Controllers
{

    /// <summary>
    /// Controlador para gerenciar os clientes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase    
    {
        private readonly ClienteService _service;
        
        private readonly Microsoft.Extensions.Logging.ILogger _logger;


        public ClientesController(ClienteService service, ILogger<EnderecosController> logger)
        {
            _service = service;

            _logger = logger;
        }

        /// <summary>
        /// Insere um novo cliente.
        /// </summary>
        /// <param name="cliente">O cliente a ser inserido.</param>
        /// <returns>O cliente inserido.</returns>
        [HttpPost()]
        public ActionResult<TbCliente> Insert(ClienteDTO cliente)
        {
            try
            {
                var entity = _service.Insert(cliente);
                return Ok(entity);
            }
            catch (InvalidEntity E)
            {

                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 422
                };
            }
            catch (System.Exception E)
            {
                _logger.LogError(E.Message);

                return BadRequest(E.Message);
            }
        }

        /// <summary>
        /// Atualiza um cliente existente.
        /// </summary>
        /// <param name="id">ID - do cliente a ser atualizado.</param>
        /// <param name="dto">Os novos dados do cliente.</param>
        /// <returns>O cliente atualizado.</returns>
        [HttpPut("{id}")]
        public ActionResult<TbCliente> Update(int id, ClienteDTO dto)
        {
            try
            {
                var entity = _service.Update(dto, id);
                return Ok(entity);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta um cliente.
        /// </summary>
        /// <param name="id">ID - do cliente a ser excluído.</param>
        /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public ActionResult<TbCliente> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);

                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }

        /// <summary>
        /// Traz um cliente pelo ID.
        /// </summary>
        /// <param name="id">O ID do cliente a ser obtido.</param>
        /// <returns>O cliente solicitado.</returns>
        [HttpGet("{id}")]
        public ActionResult<TbCliente> GetById(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);

                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }

        /// <summary>
        /// Traz todos os clientes.
        /// </summary>
        /// <returns>Uma lista de todos os clientes.</returns>
        [HttpGet()]
        public ActionResult<TbCliente> Get()
        {
            try
            {
                var entity = _service.Get();
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);

                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
    }
}