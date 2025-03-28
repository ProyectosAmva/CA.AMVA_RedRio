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
/// Controlador de API para gestionar los registros de mediciones de datos "Insitu". 
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los registros.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class InsituController : ControllerBase
    {
        private readonly IRepository<Insitu> _insituRepository;

        public InsituController(IRepository<Insitu> insituRepository)
        {
            _insituRepository = insituRepository;
        }
        [Route("ObtenerInsitus")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllInsitus()
        {
            try
            {
                var Insitus = await _insituRepository.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Insitus retrieved successfully",
                    Result = Insitus
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Insitus",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerInsitu/{id}")]
        public async Task<ActionResult<Response>> GetByIdInsitu(int id)
        {
            try
            {
                var Insitu = await _insituRepository.GetByIdAsync(id);
                if (Insitu == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Insitu not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Insitu retrieved successfully",
                    Result = Insitu
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Insitu",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarInsitu")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddInsitu([FromBody] Insitu insitu)
        {
            try
            {
                insitu.Fecha_creacion = DateTime.Now;
                await _insituRepository.AddAsync(insitu);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Insitu created successfully",
                    Result = insitu
                };
                return CreatedAtAction(nameof(GetByIdInsitu), new { id = insitu.IdInsitu }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating Insitu",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarInsitu/{id}")]
        public async Task<IActionResult> UpdateInsitu(int id, [FromBody] Insitu insitu)
        {
            try
            {
                var existingInsitu = await _insituRepository.GetByIdAsync(id);
                if (existingInsitu == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Insitu not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingInsitu.OrpInsitu = insitu.OrpInsitu;
                existingInsitu.Oxigeno_disuelto = insitu.Oxigeno_disuelto;
                existingInsitu.Turbiedad = insitu.Turbiedad;
                existingInsitu.Tem_agua = insitu.Tem_agua;
                existingInsitu.Temp_ambiente = insitu.Temp_ambiente;
                existingInsitu.Conductiviidad_electrica = insitu.Conductiviidad_electrica;
                existingInsitu.PhInsitu = insitu.PhInsitu;
                existingInsitu.Fecha_actualizacion = DateTime.Now;
                existingInsitu.Fecha_Muestra =insitu.Fecha_Muestra;


                await _insituRepository.UpdateAsync(existingInsitu);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Insitu updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating Insitu",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarInsitu/{id}")]
        public async Task<IActionResult> DeleteInsitu(int id)
        {
            try
            {
                var existingInsitu = await _insituRepository.GetByIdAsync(id);
                if (existingInsitu == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Insitu not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _insituRepository.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Insitu deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting Insitu",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
