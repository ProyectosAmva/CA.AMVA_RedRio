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
/// Controlador de API para gestionar las estaciones. Permite realizar operaciones CRUD (crear, leer, actualizar y eliminar) sobre las estaciones.
/// Incluye métodos para obtener todas las estaciones, buscar por ID o código, crear nuevas estaciones, actualizar sus datos y eliminarlas.
/// Las respuestas de la API indican el éxito o fracaso de cada operación y devuelven los datos correspondientes cuando es necesario.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionController : ControllerBase
    {
        private readonly IRepositoryEstacion<Estacion> _estacionRepository;

        public EstacionController(IRepositoryEstacion<Estacion> estacionRepository)
        {
            _estacionRepository = estacionRepository;
        }

        [Route("ObtenerEstaciones")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllEstaciones()
        {
            try
            {
                var Estacions = await _estacionRepository.GetAllAsync();
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
                var estacion = await _estacionRepository.GetByIdAsync(id);
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
                var estacion = await _estacionRepository.GetByCodigoAsync(codigo);
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
                await _estacionRepository.AddAsync(estacion);
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
                var existingEstacion = await _estacionRepository.GetByIdAsync(id);
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

                await _estacionRepository.UpdateAsync(existingEstacion);

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
                var existingEstacion = await _estacionRepository.GetByIdAsync(id);
                if (existingEstacion == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Estacion not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _estacionRepository.DeleteAsync(id);

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
