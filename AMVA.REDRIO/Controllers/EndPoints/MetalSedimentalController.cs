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
/// Controlador de API para gestionar los registros de mediciones de datos "Metal sedimental". 
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los registros.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MetalSedimentalController : ControllerBase
    {
         private readonly IRepository<MetalSedimental> _metalSedimentalRepository;

        public MetalSedimentalController(IRepository<MetalSedimental> MetalSedimentalRepository)
        {
            _metalSedimentalRepository = MetalSedimentalRepository;
        }


        [Route("ObtenerMetalesSedimentales")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllMetalSedimentals()
        {
            try
            {
                var MetalSedimentals = await _metalSedimentalRepository.GetAllAsync();
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
                var MetalSedimental = await _metalSedimentalRepository.GetByIdAsync(id);
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
                await _metalSedimentalRepository.AddAsync(metalSedimental);
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
                var existingMetalSedimental = await _metalSedimentalRepository.GetByIdAsync(id);
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


                await _metalSedimentalRepository.UpdateAsync(existingMetalSedimental);

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
                var existingMetalSedimental = await _metalSedimentalRepository.GetByIdAsync(id);
                if (existingMetalSedimental == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "MetalSedimental not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _metalSedimentalRepository.DeleteAsync(id);

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
