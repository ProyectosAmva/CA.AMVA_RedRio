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
/// Controlador de API para gestionar los registros de municipios. 
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los registros de municipios,
/// así como obtener información detallada de un municipio específico o todos los municipios.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipioController : ControllerBase
    {
        private readonly MunicipioService _municipioService;

        public MunicipioController(MunicipioService municipioService)
        {
            _municipioService = municipioService;
        }

        [Route("ObtenerMunicipios")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllMunicipios()
        {
            try
            {
                var municipios = await _municipioService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Municipios retrieved successfully",
                    Result = municipios
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving municipios",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerMunicipio/{id}")]
        public async Task<ActionResult<Response>> GetByIdMunicipio(int id)
        {
            try
            {
                var municipio = await _municipioService.GetByIdAsync(id);
                if (municipio == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Municipio not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Municipio retrieved successfully",
                    Result = municipio
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving municipio",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarMunicipio")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddMunicipio([FromBody] Municipio municipio)
        {
            try
            {
                await _municipioService.AddAsync(municipio);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Municipio created successfully",
                    Result = municipio
                };
                return CreatedAtAction(nameof(GetByIdMunicipio), new { id = municipio.IdMunicipio }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating municipio",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarMunicipio/{id}")]
       public async Task<IActionResult> UpdateMunicipio(int id, [FromBody] Municipio municipio)
        {
            if (id != municipio.IdMunicipio)
            {
                var responseBadRequest = new Response
                {
                    IsSuccess = false,
                    MessageError = "ID mismatch."
                };
                return BadRequest(responseBadRequest);
            }

            try
            {
                var existingMunicipio = await _municipioService.GetByIdAsync(id);
                if (existingMunicipio == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Municipio not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingMunicipio.Nombre = municipio.Nombre;
                existingMunicipio.Codigo = municipio.Codigo;
                existingMunicipio.Id_Departamento = municipio.Id_Departamento;

                await _municipioService.UpdateAsync(existingMunicipio);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Municipio updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating municipio",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarMunicipio/{id}")]
        public async Task<IActionResult> DeleteMunicipio(int id)
        {
            try
            {
                var existingMunicipio = await _municipioService.GetByIdAsync(id);
                if (existingMunicipio == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Municipio not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _municipioService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Municipio deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting municipio",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
