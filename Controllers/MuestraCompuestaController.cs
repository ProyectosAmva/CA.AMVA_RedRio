using AMVA.REDRIO.Models;
using AMVA.REDRIO.Core;
using AMVA.REDRIO.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MuestraCompuestaController : ControllerBase
    {
        private readonly MuestraCompuestaService _MuestraCompuestaService;

        public MuestraCompuestaController(MuestraCompuestaService MuestraCompuestaService)
        {
            _MuestraCompuestaService = MuestraCompuestaService;
        }

        [Route("ObtenerMuestraCompuesta")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllMuestraCompuestas()
        {
            try
            {
                var MuestraCompuestas = await _MuestraCompuestaService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "MuestraCompuestas retrieved successfull",
                    Result = MuestraCompuestas
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving MuestraCompuestas",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerMuestraCompuesta/{id}")]
        public async Task<ActionResult<Response>> GetByIdMuestraCompuesta(int id)
        {
            try
            {
                var MuestraCompuesta = await _MuestraCompuestaService.GetByIdAsync(id);
                if (MuestraCompuesta == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MuestraCompuesta not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "MuestraCompuesta retrieved successfully",
                    Result = MuestraCompuesta
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving MuestraCompuesta",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarMuestraCompuesta")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddMuestraCompuesta([FromBody] MuestraCompuesta MuestraCompuesta)
        {
            try
            {
                MuestraCompuesta.Fecha_creacion =DateTime.Now;
                await _MuestraCompuestaService.AddAsync(MuestraCompuesta);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "MuestraCompuesta created successfully",
                    Result = MuestraCompuesta
                };
                return CreatedAtAction(nameof(GetByIdMuestraCompuesta), new { id = MuestraCompuesta.IdMuestraCompuesta }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating MuestraCompuesta",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarLaboratorio/{id}")]
        public async Task<IActionResult> UpdateMuestraCompuesta(int id, [FromBody] MuestraCompuesta MuestraCompuesta)
        {
            try
            {
                var existingMuestraCompuesta = await _MuestraCompuestaService.GetByIdAsync(id);
                if (existingMuestraCompuesta == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MuestraCompuesta not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingMuestraCompuesta.IdInsitu = MuestraCompuesta.IdInsitu;
                existingMuestraCompuesta.IdNutriente = MuestraCompuesta.IdNutriente;
                existingMuestraCompuesta.IdQuimico = MuestraCompuesta.IdQuimico;
                existingMuestraCompuesta.IdFisico = MuestraCompuesta.IdFisico;
                existingMuestraCompuesta.IdMetalAgua = MuestraCompuesta.IdMetalAgua;
                existingMuestraCompuesta.IdBiologico = MuestraCompuesta.IdBiologico;
                existingMuestraCompuesta.Fecha_actualizacion = DateTime.Now;
                existingMuestraCompuesta.Fecha_Muestra = MuestraCompuesta.Fecha_Muestra;


                await _MuestraCompuestaService.UpdateAsync(existingMuestraCompuesta);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "MuestraCompuesta updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating MuestraCompuesta",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarMuestraCompuesta/{id}")]
        public async Task<IActionResult> DeleteMuestraCompuesta(int id)
        {
            try
            {
                var existingMuestraCompuesta = await _MuestraCompuestaService.GetByIdAsync(id);
                if (existingMuestraCompuesta == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MuestraCompuesta not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _MuestraCompuestaService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "MuestraCompuesta deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting MuestraCompuesta",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
