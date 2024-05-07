using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using ApiWebDB.Services.Parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Serilog;
using System;

namespace ApiWebDB.Controllers
{
    /// <summary>
    /// Controlador para gerenciar os endereços.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly EnderecoService _service;

        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public EnderecosController(EnderecoService service, ILogger<EnderecosController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Adicionar um novo endereço.
        /// </summary>
        /// <param name="endereco">O endereço a ser inserido.</param>
        /// <returns>O endereço inserido com sucesso.</returns>
        [HttpPost()]
        public ActionResult<TbEndereco> Insert(EnderecoDTO endereco)
        {
            try
            {
                var entity = _service.Insert(endereco);
                return Ok(entity);
            }
            catch (InvalidEntity E)
            {

                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 422
                };

            }
            catch (Exception E)
            {
                _logger.LogError(E.Message);

                return BadRequest(E.Message);
            }

        }
        /// <summary>
        /// Obtém todos os endereços.
        /// </summary>
        /// <returns>Uma lista de todos os endereços.</returns>
        [HttpGet()]
        public ActionResult<TbEndereco> Get()
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


        /// <summary>
        /// Atualiza um endereço existente.
        /// </summary>
        /// <param name="id"> ID do endereço a ser atualizado.</param>
        /// <param name="dto">Os novos dados do endereço.</param>
        /// <returns>O endereço atualizado.</returns>

        [HttpPut("{id}")]
        public ActionResult<TbEndereco> Update(int id, EnderecoDTO endereco)
        {
            try
            {
                var entity = _service.Update(endereco, id);
                return Ok(entity);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Exclui um endereço.
        /// </summary>
        /// <param name="id">ID do endereço a ser excluído.</param>
        /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        public ActionResult<TbEndereco> Delete(int id)
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
        /// Traz um endereço pelo ID do cliente.
        /// </summary>
        /// <param name="id">ID do Cliente.</param>
        /// <returns>O endereço solicitado.</returns>
        [HttpGet("{id}")]
        public ActionResult<TbEndereco> GetByIdEnder(int id)
        {
            try
            {
                var entity = _service.GetByIdEnder(id);
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