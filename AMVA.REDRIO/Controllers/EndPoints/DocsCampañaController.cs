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
    /// Controlador para manejar las operaciones CRUD relacionadas con los documentos asociadas a campañas.
    /// Proporciona métodos para obtener, agregar, actualizar y eliminar registros de Departamentos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DocsCampañaController : ControllerBase
    {
        private readonly IRepositoryDocsCampaña<DocsCampaña> _docsCampañaRepository;

            public DocsCampañaController(IRepositoryDocsCampaña<DocsCampaña> docsCampañaRepository)
            {
                _docsCampañaRepository = docsCampañaRepository;
            }

        [Route("ObtenerDocsCampañas")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllDocsCampañas()
        {
            try
            {
                var DocsCampañas = await _docsCampañaRepository.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "DocsCampañas retrieved successfully",
                    Result = DocsCampañas
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving DocsCampañas",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerDocsCampañaPorCampaña/{idCampaña}")]
                public async Task<ActionResult<Response>> GetByCampañasAsync(int idCampaña)
                {
                    try
                    {
                        var DocsCampaña = await _docsCampañaRepository.GetByCampañasAsync(idCampaña);
                        if (DocsCampaña == null || !DocsCampaña.Any())
                        {
                            var responseNotFound = new Response
                            {
                                IsSuccess = false,
                                MessageError = "No se encontraron Historial excel de laboratorio para la campaña especificada."
                            };
                            return NotFound(responseNotFound);
                        }

                        var responseGetById = new Response
                        {
                            IsSuccess = true,
                            Message = "Hisotial Excel de laboratorio recuperados exitosamente.",
                            Result = DocsCampaña
                        };
                        return Ok(responseGetById);
                    }
                    catch (Exception ex)
                    {
                        var responseError = new Response
                        {
                            IsSuccess = false,
                            MessageError = "Error al recuperar los Archivos .",
                            Error = ex.Message
                        };
                        return StatusCode(StatusCodes.Status500InternalServerError, responseError);
                    }
                }


        [HttpGet("ObtenerDocsCampaña/{id}")]
        public async Task<ActionResult<Response>> GetByIdDocsCampaña(int id)
        {
            try
            {
                var DocsCampaña = await _docsCampañaRepository.GetByIdAsync(id);
                if (DocsCampaña == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "DocsCampaña not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "DocsCampaña retrieved successfully",
                    Result = DocsCampaña
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving DocsCampaña",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarDocsCampaña")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddDocsCampaña([FromBody] DocsCampaña docsCampaña)
        {
            try
            {
                docsCampaña.Fecha_creacion =  DateTime.Now;
                await _docsCampañaRepository.AddAsync(docsCampaña);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "DocsCampaña created successfully",
                    Result = docsCampaña
                };
                return CreatedAtAction(nameof(GetByIdDocsCampaña), new { id = docsCampaña.Id_DocsCampaña }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating DocsCampaña",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarDocsCampaña/{id}")]
        public async Task<IActionResult> UpdateDocsCampaña(int id, [FromBody] DocsCampaña docsCampaña)
        {
            try
            {
                var existingDocsCampaña = await _docsCampañaRepository.GetByIdAsync(id);
                if (existingDocsCampaña == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "DocsCampaña not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingDocsCampaña.IdCampaña = docsCampaña.IdCampaña;
                existingDocsCampaña.Id_Documento =docsCampaña.Id_Documento;
                existingDocsCampaña.Estado = docsCampaña.Estado;
                existingDocsCampaña.Fecha_actualizacion = DateTime.Now;

                await _docsCampañaRepository.UpdateAsync(existingDocsCampaña);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "DocsCampaña updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating DocsCampaña",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarDocsCampaña/{id}")]
        public async Task<IActionResult> DeleteDocsCampaña(int id)
        {
            try
            {
                var existingDocsCampaña = await _docsCampañaRepository.GetByIdAsync(id);
                if (existingDocsCampaña == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "DocsCampaña not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _docsCampañaRepository.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "DocsCampaña deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting DocsCampaña",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    
    }
}
