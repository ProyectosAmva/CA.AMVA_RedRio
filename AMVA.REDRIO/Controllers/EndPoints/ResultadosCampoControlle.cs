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
/// Controlador de API para gestionar los resultados de campo.
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los resultados de campo.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ResultadoCampoController : ControllerBase
    {
        private readonly IRepository<ResultadoCampo> _resultadoCampoRepository;

public ResultadoCampoController(IRepository<ResultadoCampo> resultadoCampoRepository)
{
    _resultadoCampoRepository = resultadoCampoRepository;
}

        [Route("ObtenerResultadosCampo")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllResultadoCampos()
        {
            try
            {
                var resultadoCampos = await _resultadoCampoRepository.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "ResultadoCampos retrieved successfully",
                    Result = resultadoCampos
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving ResultadoCampos",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

         
        [HttpGet("ObtenerResultadoCampo/{id}")]
        public async Task<ActionResult<Response>> GetByIdResultadoCampo(int id)
        {
            try
            {
                var resultadoCampo = await _resultadoCampoRepository.GetByIdAsync(id);
                if (resultadoCampo == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "ResultadoCampo not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "ResultadoCampo retrieved successfully",
                    Result = resultadoCampo
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving ResultadoCampo",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarResultadoCampo")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddResultadoCampo([FromBody] ResultadoCampo resultadoCampo)
        {
            try
            {
                resultadoCampo.Fecha_creacion = DateTime.Now;
                await _resultadoCampoRepository.AddAsync(resultadoCampo);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "ResultadoCampo created successfully",
                    Result = resultadoCampo
                };
                return CreatedAtAction(nameof(GetByIdResultadoCampo), new { id = resultadoCampo.IdCampo }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating ResultadoCampo",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
                
        [HttpPut("ActualizarResultadoCampo/{id}")]
        public async Task<IActionResult> UpdateResultadoCampo(int id, [FromBody] ResultadoCampo resultadoCampo)
        {

            try
            {
                var existingResultadoCampo = await _resultadoCampoRepository.GetByIdAsync(id);
                if (existingResultadoCampo == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "ResultadoCampo not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingResultadoCampo.Hora = resultadoCampo.Hora;
                existingResultadoCampo.TempAmbiente = resultadoCampo.TempAmbiente;
                existingResultadoCampo.TempAgua = resultadoCampo.TempAgua;
                existingResultadoCampo.Ph = resultadoCampo.Ph;
                existingResultadoCampo.Od = resultadoCampo.Od;
                existingResultadoCampo.Cond = resultadoCampo.Cond;
                existingResultadoCampo.Orp = resultadoCampo.Orp;
                existingResultadoCampo.Turb = resultadoCampo.Turb;
                existingResultadoCampo.Tiempo = resultadoCampo.Tiempo;
                existingResultadoCampo.Apariencia = resultadoCampo.Apariencia;
                existingResultadoCampo.Color = resultadoCampo.Color;
                existingResultadoCampo.Olor = resultadoCampo.Olor;
                existingResultadoCampo.Altura = resultadoCampo.Altura;
                existingResultadoCampo.H1 = resultadoCampo.H1;
                existingResultadoCampo.H2 = resultadoCampo.H2;
                existingResultadoCampo.Observacion = resultadoCampo.Observacion;
                existingResultadoCampo.Fecha_actualizacion = DateTime.Now;
                existingResultadoCampo.Fecha_Muestra = resultadoCampo.Fecha_Muestra;



                await _resultadoCampoRepository.UpdateAsync(existingResultadoCampo);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "ResultadoCampo updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating ResultadoCampo",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

         
        [HttpDelete("EliminarResultadoCampo/{id}")]
        public async Task<IActionResult> DeleteResultadoCampo(int id)
        {
            try
            {
                var existingResultadoCampo = await _resultadoCampoRepository.GetByIdAsync(id);
                if (existingResultadoCampo == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "ResultadoCampo not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _resultadoCampoRepository.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "ResultadoCampo deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting ResultadoCampo",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
