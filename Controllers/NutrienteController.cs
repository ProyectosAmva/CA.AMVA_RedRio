using AMVA.REDRIO.Models;
using AMVA.REDRIO.Core;
using AMVA.REDRIO.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AMVA.REDRIO.Controllers
{
    /// <summary>
/// Controlador de API para gestionar los registros de nutrientes. 
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los registros de nutrientes,
/// así como obtener información detallada de un nutriente específico o todos los nutrientes.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NutrienteController : ControllerBase
    {
        private readonly NutrienteService _nutrienteService;

        public NutrienteController(NutrienteService nutrienteService)
        {
            _nutrienteService = nutrienteService;
        }

        [Route("ObtenerNutrientes")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllNutrientes()
        {
            try
            {
                var Nutrientes = await _nutrienteService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Nutrientes retrieved successfully",
                    Result = Nutrientes
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Nutrientes",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerNutriente/{id}")]
        public async Task<ActionResult<Response>> GetByIdNutriente(int id)
        {
            try
            {
                var Nutriente = await _nutrienteService.GetByIdAsync(id);
                if (Nutriente == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Nutriente not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Nutriente retrieved successfully",
                    Result = Nutriente
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Nutriente",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarNutriente")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddNutriente([FromBody] Nutriente nutriente)
        {
            try
            {
                nutriente.Fecha_creacion = DateTime.Now;
                await _nutrienteService.AddAsync(nutriente);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Nutriente created successfully",
                    Result = nutriente
                };
                return CreatedAtAction(nameof(GetByIdNutriente), new { id = nutriente.IdNutriente }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating Nutriente",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarNutriente/{id}")]
        public async Task<IActionResult> UpdateNutriente(int id, [FromBody] Nutriente nutriente)
        {
            try
            {
                var existingNutriente = await _nutrienteService.GetByIdAsync(id);
                if (existingNutriente == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Nutriente not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingNutriente.Nitrogeno_total_kjeldahl = nutriente.Nitrogeno_total_kjeldahl;
                existingNutriente.Fosforo_organico = nutriente.Fosforo_organico;
                existingNutriente.Nitratos = nutriente.Nitratos;
                existingNutriente.Fosforo_total = nutriente.Fosforo_total;
                existingNutriente.Nitrogeno_organico = nutriente.Nitrogeno_organico;
                existingNutriente.Fecha_actualizacion = DateTime.Now;
                existingNutriente.Fecha_Muestra = nutriente.Fecha_Muestra;



                await _nutrienteService.UpdateAsync(existingNutriente);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Nutriente updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating Nutriente",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarNutriente/{id}")]
        public async Task<IActionResult> DeleteNutriente(int id)
        {
            try
            {
                var existingNutriente = await _nutrienteService.GetByIdAsync(id);
                if (existingNutriente == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Nutriente not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _nutrienteService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Nutriente deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting Nutriente",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
