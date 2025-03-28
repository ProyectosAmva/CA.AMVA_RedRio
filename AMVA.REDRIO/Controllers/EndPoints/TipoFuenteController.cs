using AMVA.REDRIO.Core.DTO;
using AMVA.REDRIO.Core.Models;
using AMVA.REDRIO.Infrastructure.Data;
using AMVA.REDRIO.Core.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Controllers
{
    /// <summary>
/// Controlador de API para gestionar los tipos de fuente.
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los tipos de fuente.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipoFuenteController : ControllerBase
    {
       private readonly IRepository<TipoFuente> _tipoFuenteRepository;

    public TipoFuenteController(IRepository<TipoFuente> tipoFuenteRepository)
    {
        _tipoFuenteRepository = tipoFuenteRepository;
    }


        [Route("ObtenerTiposFuentes")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllTiposFuentes()
        {
            try
            {
                var tipoFuentes = await _tipoFuenteRepository.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Tipos de Fuente retrieved successfully",
                    Result = tipoFuentes
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving tipos de Fuente",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerTipoFuente/{id}")]
        public async Task<ActionResult<Response>> GetByIdTipoFuente(int id)
        {
            try
            {
                var tipoFuente = await _tipoFuenteRepository.GetByIdAsync(id);
                if (tipoFuente == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Tipo de Fuente not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Tipo de Fuente retrieved successfully",
                    Result = tipoFuente
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving tipo de Fuente",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarTipoFuente")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddTipoFuente([FromBody] TipoFuente tipoFuente)
        {
            try
            {
                await _tipoFuenteRepository.AddAsync(tipoFuente);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Tipo de Fuente created successfully",
                    Result = tipoFuente
                };
                return CreatedAtAction(nameof(GetByIdTipoFuente), new { id = tipoFuente.IdTipoFuente }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating tipo de Fuente",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarTipoFuente/{id}")]
        public async Task<IActionResult> UpdateTipoFuente(int id, [FromBody] TipoFuente tipoFuente)
        {
            try
            {
                var existingTipoFuente = await _tipoFuenteRepository.GetByIdAsync(id);
                if (existingTipoFuente == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Tipo de Fuente not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingTipoFuente.NombreTipoFuente = tipoFuente.NombreTipoFuente;

                await _tipoFuenteRepository.UpdateAsync(existingTipoFuente);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Tipo de Fuente updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating tipo de Fuente",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarTipoFuente/{id}")]
        public async Task<IActionResult> DeleteTipoFuente(int id)
        {
            try
            {
                var existingTipoFuente = await _tipoFuenteRepository.GetByIdAsync(id);
                if (existingTipoFuente == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Tipo de Fuente not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _tipoFuenteRepository.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Tipo de Fuente deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting tipo de Fuente",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
