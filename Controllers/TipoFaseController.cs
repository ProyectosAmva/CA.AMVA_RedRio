using AMVA.REDRIO.Models;
using AMVA.REDRIO.Core;
using AMVA.REDRIO.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Controllers
{
    /// <summary>
/// Controlador de API para gestionar los tipos de fase.
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los tipos de fase.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipoFaseController : ControllerBase
    {
        private readonly TipoFaseService _tipoFaseService;

        public TipoFaseController(TipoFaseService tipoFaseService)
        {
            _tipoFaseService = tipoFaseService;
        }

        [Route("ObtenerTiposFases")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllTiposFases()
        {
            try
            {
                var tipoFases = await _tipoFaseService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Tipos de fase retrieved successfully",
                    Result = tipoFases
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving tipos de fase",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerTipoFase/{id}")]
        public async Task<ActionResult<Response>> GetByIdTipoFase(int id)
        {
            try
            {
                var tipoFase = await _tipoFaseService.GetByIdAsync(id);
                if (tipoFase == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Tipo de fase not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Tipo de fase retrieved successfully",
                    Result = tipoFase
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving tipo de fase",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarTipoFase")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddTipoFase([FromBody] TipoFase tipoFase)
        {
            try
            {
                await _tipoFaseService.AddAsync(tipoFase);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Tipo de fase created successfully",
                    Result = tipoFase
                };
                return CreatedAtAction(nameof(GetByIdTipoFase), new { id = tipoFase.IdTipoFase }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating tipo de fase",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarTipoFase/{id}")]
        public async Task<IActionResult> UpdateTipoFase(int id, [FromBody] TipoFase tipoFase)
        {
            try
            {
                var existingTipoFase = await _tipoFaseService.GetByIdAsync(id);
                if (existingTipoFase == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Tipo de fase not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingTipoFase.NombreTipoFase = tipoFase.NombreTipoFase;

                await _tipoFaseService.UpdateAsync(existingTipoFase);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Tipo de fase updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating tipo de fase",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarTipoFase/{id}")]
        public async Task<IActionResult> DeleteTipoFase(int id)
        {
            try
            {
                var existingTipoFase = await _tipoFaseService.GetByIdAsync(id);
                if (existingTipoFase == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Tipo de fase not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _tipoFaseService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Tipo de fase deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting tipo de fase",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
