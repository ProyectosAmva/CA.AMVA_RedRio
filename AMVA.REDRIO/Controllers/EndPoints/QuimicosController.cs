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
/// Controlador de API para gestionar los registros de químicos.
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los registros de químicos,
/// así como obtener información detallada de un químico específico o todos los químicos.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class QuimicoController : ControllerBase
    {
        private readonly IRepository<Quimico> _quimicoRepository;

        public QuimicoController(IRepository<Quimico> quimicoRepository)
        {
            _quimicoRepository = quimicoRepository;
        }

        [Route("ObtenerQuimicos")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllQuimicos()
        {
            try
            {
                var Quimicos = await _quimicoRepository.GetAllAsync();
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
                var Quimico = await _quimicoRepository.GetByIdAsync(id);
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
                await _quimicoRepository.AddAsync(quimico);
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
                var existingQuimico = await _quimicoRepository.GetByIdAsync(id);
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


                await _quimicoRepository.UpdateAsync(existingQuimico);

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
                var existingQuimico = await _quimicoRepository.GetByIdAsync(id);
                if (existingQuimico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Quimico not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _quimicoRepository.DeleteAsync(id);

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
