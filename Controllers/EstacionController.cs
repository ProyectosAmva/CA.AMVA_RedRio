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
    public class EstacionController : ControllerBase
    {
        private readonly EstacionService _estacionService;

        public EstacionController(EstacionService estacionService)
        {
            _estacionService = estacionService;
        }

        [Route("ObtenerEstaciones")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllEstaciones()
        {
            try
            {
                var Estacions = await _estacionService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Estacions retrieved successfully",
                    Result = Estacions
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Estacions",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerEstacion/{id}")]
        public async Task<ActionResult<Response>> GetByIdEstacion(int id)
        {
            try
            {
                var estacion = await _estacionService.GetByIdAsync(id);
                if (estacion == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Estacion not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Estacion retrieved successfully",
                    Result = estacion
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Estacion",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerEstacionCodigo/{codigo}")]
        public async Task<IActionResult> GetEstacionByCodigo(string codigo)
        {
            try
            {
                var estacion = await _estacionService.GetByCodigoAsync(codigo);
                if (estacion == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Estacion not found with the given code."
                    };
                    return NotFound(responseNotFound); 
                }
                var responseGetByCode = new Response
                {
                    IsSuccess = true,
                    Message = "Estacion retrieved successfully.",
                    Result = estacion
                };
                return Ok(responseGetByCode);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Estacion by code.",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
            
        [Route("AgregarEstacion")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddEstacion([FromBody] Estacion estacion)
        {
            try
            {
                estacion.Fecha_creacion = DateTime.Now;
                await _estacionService.AddAsync(estacion);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Estacion created successfully",
                    Result = estacion
                };
                return CreatedAtAction(nameof(GetByIdEstacion), new { id = estacion.IdEstacion }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating Estacion",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarEstacion/{id}")]
        public async Task<IActionResult> UpdateEstacion(int id, [FromBody] Estacion estacion)
        {
            try
            {
                var existingEstacion = await _estacionService.GetByIdAsync(id);
                if (existingEstacion == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Estacion not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingEstacion.codigo = estacion.codigo;
                existingEstacion.nombreEstacion = estacion.nombreEstacion;
                existingEstacion.IdMunicipio = estacion.IdMunicipio;
                existingEstacion.IdTipoFuente = estacion.IdTipoFuente;
                existingEstacion.Elevacion = estacion.Elevacion;
                existingEstacion.Grados_latitud= estacion.Grados_latitud;
                existingEstacion.Grados_longitud = estacion.Grados_longitud;
                existingEstacion.Segundos_latitud = estacion.Segundos_latitud;
                existingEstacion.Segundos_longitud = estacion.Segundos_longitud;
                existingEstacion.Minutos_latitud = estacion.Minutos_latitud;
                existingEstacion.Minutos_longitud = estacion.Minutos_longitud;
                existingEstacion.Fecha_actualizacion = DateTime.Now;


                await _estacionService.UpdateAsync(existingEstacion);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Estacion updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating Estacion",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarEstacion/{id}")]
        public async Task<IActionResult> DeleteEstacion(int id)
        {
            try
            {
                var existingEstacion = await _estacionService.GetByIdAsync(id);
                if (existingEstacion == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Estacion not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _estacionService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Estacion deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting Estacion",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
