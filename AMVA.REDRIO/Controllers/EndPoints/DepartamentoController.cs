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
    /// Controlador para manejar las operaciones CRUD relacionadas con los Departamentos.
    /// Proporciona métodos para obtener, agregar, actualizar y eliminar registros de Departamentos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
         private readonly IRepository<Departamento> _departamentoRepository;

        public DepartamentoController(IRepository<Departamento> departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        [Route("ObtenerDepartamentos")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllDepartamentos()
        {
            try
            {
                var departamentos = await _departamentoRepository.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Departamentos retrieved successfully",
                    Result = departamentos
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving departamentos",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerDepartamento/{id}")]
        public async Task<ActionResult<Response>> GetByIdDepartamento(int id)
        {
            try
            {
                var departamento = await _departamentoRepository.GetByIdAsync(id);
                if (departamento == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Departamento not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Departamento retrieved successfully",
                    Result = departamento
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving departamento",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarDepartamento")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddDepartamento([FromBody] Departamento departamento)
        {
            try
            {
                await _departamentoRepository.AddAsync(departamento);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Departamento created successfully",
                    Result = departamento
                };
                return CreatedAtAction(nameof(GetByIdDepartamento), new { id = departamento.IdDepartamento }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating departamento",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarDepartamento/{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, [FromBody] Departamento departamento)
        {
            try
            {
                var existingDepartamento = await _departamentoRepository.GetByIdAsync(id);
                if (existingDepartamento == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Departamento not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingDepartamento.Nombre = departamento.Nombre;
                existingDepartamento.Codigo = departamento.Codigo;

                await _departamentoRepository.UpdateAsync(existingDepartamento);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Departamento updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating departamento",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarDepartamento/{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            try
            {
                var existingDepartamento = await _departamentoRepository.GetByIdAsync(id);
                if (existingDepartamento == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Departamento not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _departamentoRepository.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Departamento deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting departamento",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
