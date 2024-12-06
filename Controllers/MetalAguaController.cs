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
/// Controlador de API para gestionar los registros de mediciones de datos "Metal Agua". 
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los registros, 
/// </summary>    [ApiController]
    [Route("api/[controller]")]
    public class MetalAguaController : ControllerBase
    {
        private readonly MetalAguaService _metalAguaService;

        public MetalAguaController(MetalAguaService metalAguaService)
        {
            _metalAguaService = metalAguaService;
        }

        [Route("ObtenerMetalesAgua")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllMetalAguas()
        {
            try
            {
                var MetalAguas = await _metalAguaService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "MetalAguas retrieved successfully",
                    Result = MetalAguas
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving MetalAguas",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }


        [HttpGet("ObtenerMetalAgua/{id}")]
        public async Task<ActionResult<Response>> GetByIdMetalAgua(int id)
        {
            try
            {
                var MetalAgua = await _metalAguaService.GetByIdAsync(id);
                if (MetalAgua == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MetalAgua not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "MetalAgua retrieved successfully",
                    Result = MetalAgua
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving MetalAgua",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarMetalAgua")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddMetalAgua([FromBody] MetalAgua metalAgua)
        {
            try
            {
                metalAgua.Fecha_creacion = DateTime.Now;
                await _metalAguaService.AddAsync(metalAgua);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "MetalAgua created successfully",
                    Result = metalAgua
                };
                return CreatedAtAction(nameof(GetByIdMetalAgua), new { id = metalAgua.IdMetalAgua }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating MetalAgua",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarMetalAgua/{id}")]
        public async Task<IActionResult> UpdateMetalAgua(int id, [FromBody] MetalAgua metalAgua)
        {
            try
            {
                var existingMetalAgua = await _metalAguaService.GetByIdAsync(id);
                if (existingMetalAgua == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MetalAgua not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingMetalAgua.Cadmio = metalAgua.Cadmio;
                existingMetalAgua.Niquel = metalAgua.Niquel;
                existingMetalAgua.Cobre = metalAgua.Cobre;
                existingMetalAgua.Mercurio = metalAgua.Mercurio;
                existingMetalAgua.Cromo = metalAgua.Cromo;
                existingMetalAgua.Plomo = metalAgua.Plomo;
                existingMetalAgua.Cromo_hexavalente = metalAgua.Cromo_hexavalente;
                existingMetalAgua.Fecha_actualizacion = DateTime.Now;
                existingMetalAgua.Fecha_Muestra = metalAgua.Fecha_Muestra;



                await _metalAguaService.UpdateAsync(existingMetalAgua);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "MetalAgua updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating MetalAgua",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarMetalAgua/{id}")]
        public async Task<IActionResult> DeleteMetalAgua(int id)
        {
            try
            {
                var existingMetalAgua = await _metalAguaService.GetByIdAsync(id);
                if (existingMetalAgua == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MetalAgua not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _metalAguaService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "MetalAgua deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting MetalAgua",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
