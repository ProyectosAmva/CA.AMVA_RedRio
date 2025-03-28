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
/// Controlador de API para gestionar las fases. Permite realizar operaciones CRUD sobre las fases, que incluyen obtener todas las fases,
/// buscar una fase por su ID, crear nuevas fases, actualizar las existentes y eliminar fases. Las respuestas de la API
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FaseController : ControllerBase
    {
        private readonly IRepository<Fase> _faseRepository;

        public FaseController(IRepository<Fase> faseRepository)
        {
            _faseRepository = faseRepository;
        }


        [Route("ObtenerFases")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllFases()
        {
            try
            {
                var fases = await _faseRepository.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Fases retrieved successfully",
                    Result = fases
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving fases",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerFase/{id}")]
        public async Task<ActionResult<Response>> GetByIdFase(int id)
        {
            try
            {
                var fase = await _faseRepository.GetByIdAsync(id);
                if (fase == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Fase not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Fase retrieved successfully",
                    Result = fase
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving fase",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarFase")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddFase([FromBody] Fase fase)
        {
            try
            {
                fase.Fecha_creacion =  DateTime.Now;
                await _faseRepository.AddAsync(fase);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Fase created successfully",
                    Result = fase
                };
                return CreatedAtAction(nameof(GetByIdFase), new { id = fase.IdFase }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating fase",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarFase/{id}")]
        public async Task<IActionResult> UpdateFase(int id, [FromBody] Fase fase)
        {
            try
            {
                var existingFase = await _faseRepository.GetByIdAsync(id);
                if (existingFase == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Fase not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingFase.NombreFase = fase.NombreFase;
                existingFase.IdTipoFase = fase.IdTipoFase;
                existingFase.Año = fase.Año;
                existingFase.Fecha_actualizacion = DateTime.Now;

                await _faseRepository.UpdateAsync(existingFase);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Fase updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating fase",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarFase/{id}")]
        public async Task<IActionResult> DeleteFase(int id)
        {
            try
            {
                var existingFase = await _faseRepository.GetByIdAsync(id);
                if (existingFase == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Fase not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _faseRepository.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Fase deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting fase",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
