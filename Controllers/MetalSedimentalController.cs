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
    public class MetalSedimentalController : ControllerBase
    {
        private readonly MetalSedimentalService _metalSedimentalService;

        public MetalSedimentalController(MetalSedimentalService metalSedimentalService)
        {
            _metalSedimentalService = metalSedimentalService;
        }

        [Route("ObtenerMetalesSedimentales")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllMetalSedimentals()
        {
            try
            {
                var MetalSedimentals = await _metalSedimentalService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "MetalSedimentals retrieved successfully",
                    Result = MetalSedimentals
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving MetalSedimentals",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }


        [HttpGet("ObtenerMetalSedimental/{id}")]
        public async Task<ActionResult<Response>> GetByIdMetalSedimental(int id)
        {
            try
            {
                var MetalSedimental = await _metalSedimentalService.GetByIdAsync(id);
                if (MetalSedimental == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MetalSedimental not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "MetalSedimental retrieved successfully",
                    Result = MetalSedimental
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving MetalSedimental",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarMetalSedimental")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddMetalSedimental([FromBody] MetalSedimental metalSedimental)
        {
            try
            {
                metalSedimental.Fecha_creacion = DateTime.Now;
                await _metalSedimentalService.AddAsync(metalSedimental);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "MetalSedimental created successfully",
                    Result = metalSedimental
                };
                return CreatedAtAction(nameof(GetByIdMetalSedimental), new { id = metalSedimental.IdMetalSedimental }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating MetalSedimental",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarMetalSedimental/{id}")]
        public async Task<IActionResult> UpdateMetalSedimental(int id, [FromBody] MetalSedimental metalSedimental)
        {
            try
            {
                var existingMetalSedimental = await _metalSedimentalService.GetByIdAsync(id);
                if (existingMetalSedimental == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MetalSedimental not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingMetalSedimental.Cadmio_sedimentable = metalSedimental.Cadmio_sedimentable;
                existingMetalSedimental.Cobre_sedimentable = metalSedimental.Cobre_sedimentable;
                existingMetalSedimental.Cromo_sedimentable = metalSedimental.Cromo_sedimentable;
                existingMetalSedimental.Plomo_sedimentable = metalSedimental.Plomo_sedimentable;
                existingMetalSedimental.Mercurio_sedimentable = metalSedimental.Mercurio_sedimentable;
                existingMetalSedimental.Fecha_actualizacion = DateTime.Now;
                existingMetalSedimental.Fecha_Muestra = metalSedimental.Fecha_Muestra;


                await _metalSedimentalService.UpdateAsync(existingMetalSedimental);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "MetalSedimental updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating MetalSedimental",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarMetalSedimental/{id}")]
        public async Task<IActionResult> DeleteMetalSedimental(int id)
        {
            try
            {
                var existingMetalSedimental = await _metalSedimentalService.GetByIdAsync(id);
                if (existingMetalSedimental == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MetalSedimental not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _metalSedimentalService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "MetalSedimental deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting MetalSedimental",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
