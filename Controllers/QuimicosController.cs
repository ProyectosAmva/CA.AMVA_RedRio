using AMVA.REDRIO.Models;
using AMVA.REDRIO.Core;
using AMVA.REDRIO.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AMVA.REDRIO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuimicoController : ControllerBase
    {
        private readonly QuimicoService _quimicoService;

        public QuimicoController(QuimicoService quimicoService)
        {
            _quimicoService = quimicoService;
        }

        [Route("ObtenerQuimicos")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllQuimicos()
        {
            try
            {
                var Quimicos = await _quimicoService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Quimicos retrieved successfully",
                    Result = Quimicos
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Quimicos",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerQuimico/{id}")]
        public async Task<ActionResult<Response>> GetByIdQuimico(int id)
        {
            try
            {
                var Quimico = await _quimicoService.GetByIdAsync(id);
                if (Quimico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Quimico not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Quimico retrieved successfully",
                    Result = Quimico
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Quimico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarQuimico")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddQuimico([FromBody] Quimico quimico)
        {
            try
            {
                quimico.Fecha_creacion = DateTime.Now;
                await _quimicoService.AddAsync(quimico);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Quimico created successfully",
                    Result = quimico
                };
                return CreatedAtAction(nameof(GetByIdQuimico), new { id = quimico.IdQuimico }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating Quimico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarQuimico/{id}")]
        public async Task<IActionResult> UpdateQuimico(int id, [FromBody] Quimico Quimico)
        {
            try
            {
                var existingQuimico = await _quimicoService.GetByIdAsync(id);
                if (existingQuimico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Quimico not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingQuimico.sustanciaActivaAzulMetileno = Quimico.sustanciaActivaAzulMetileno;
                existingQuimico.Grasa_Aceite = Quimico.Grasa_Aceite;
                existingQuimico.Db05 = Quimico.Db05;
                existingQuimico.Dq0 = Quimico.Dq0;
                existingQuimico.HierroTotal = Quimico.HierroTotal;
                existingQuimico.Sulfatos = Quimico.Sulfatos;
                existingQuimico.Sulfuros = Quimico.Sulfuros;
                existingQuimico.Cloruros = Quimico.Cloruros;
                existingQuimico.Fecha_actualizacion = DateTime.Now;
                existingQuimico.Fecha_Muestra = Quimico.Fecha_Muestra;


                await _quimicoService.UpdateAsync(existingQuimico);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Quimico updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating Quimico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarQuimico/{id}")]
        public async Task<IActionResult> DeleteQuimico(int id)
        {
            try
            {
                var existingQuimico = await _quimicoService.GetByIdAsync(id);
                if (existingQuimico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Quimico not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _quimicoService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Quimico deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting Quimico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
