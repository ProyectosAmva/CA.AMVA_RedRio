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
    /// Controlador para manejar las operaciones CRUD relacionadas con las Campañas.
    /// Proporciona métodos para obtener, agregar, actualizar y eliminar registros de Campañas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CampañaController : ControllerBase
    {
        private readonly IRepository<Campaña> _campañaRepository;

            public CampañaController(IRepository<Campaña> campañaRepository)
            {
                _campañaRepository = campañaRepository;
            }
        [HttpGet("ObtenerCampañas")]
        public async Task<ActionResult<Response>> GetAllCampañas()
        {
            try
            {
                var campañas = await _campañaRepository.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Campañas retrieved successfully",
                    Result = campañas
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving campañas",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerCampaña/{id}")]
        public async Task<ActionResult<Response>> GetByIdCampaña(int id)
        {
            try
            {
                var campaña = await _campañaRepository.GetByIdAsync(id);
                if (campaña == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Campaña not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Campaña retrieved successfully",
                    Result = campaña
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving campaña",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    
       [Route("AgregarCampaña")]
[HttpPost]
public async Task<ActionResult<Response>> AddCampaña([FromBody] Campaña campaña)
{
    if (campaña == null)
    {
        return BadRequest(new Response
        {
            IsSuccess = false,
            MessageError = "La campaña no puede ser nula."
        });
    }

    if (string.IsNullOrWhiteSpace(campaña.Descripcion) || 
        campaña.Fecha_inicial == default(DateTime) || 
        campaña.Fecha_final == default(DateTime) || 
        campaña.IdFase <= 0)
    {
        return BadRequest(new Response
        {
            IsSuccess = false,
            MessageError = "Los campos obligatorios no pueden estar vacíos."
        });
    }

    try
    {
        campaña.Fecha_creacion = DateTime.Now;

        campaña.NombreCampaña = $" del {campaña.Fecha_inicial:yyyy-MM-dd} al {campaña.Fecha_final:yyyy-MM-dd}";

        await _campañaRepository.AddAsync(campaña);
        var responseCreated = new Response
        {
            IsSuccess = true,
            Message = "Campaña created successfully",
            Result = campaña
        };
        return CreatedAtAction(nameof(GetByIdCampaña), new { id = campaña.IdCampaña }, responseCreated);
    }
    catch (Exception ex)
    {
        var responseError = new Response
        {
            IsSuccess = false,
            MessageError = "Error creating campaña",
            Error = ex.Message
        };
        return StatusCode(StatusCodes.Status500InternalServerError, responseError);
    }
}

        [HttpPut("ActualizarCampaña/{idCamapaña}")]
        public async Task<IActionResult> UpdateCampaña(int idCamapaña, [FromBody] Campaña campaña)
        {
            if (idCamapaña != campaña.IdCampaña)
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
                var existingCampaña = await _campañaRepository.GetByIdAsync(idCamapaña);
                if (existingCampaña == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Campaña not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingCampaña.NombreCampaña = $"del {campaña.Fecha_inicial:yyyy-MM-dd} al  {campaña.Fecha_final:yyyy-MM-dd}";
                existingCampaña.Descripcion = campaña.Descripcion;
                existingCampaña.Fecha_inicial = campaña.Fecha_inicial;
                existingCampaña.Fecha_final = campaña.Fecha_final;
                existingCampaña.IdFase = campaña.IdFase;
                existingCampaña.IdUsuario =  campaña.IdUsuario;
                existingCampaña.Fecha_actualizacion = DateTime.Now;

                await _campañaRepository.UpdateAsync(existingCampaña);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Campaña updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating campaña",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarCampaña/{id}")]
        public async Task<IActionResult> DeleteCampaña(int id)
        {
            try
            {
                var existingCampaña = await _campañaRepository.GetByIdAsync(id);
                if (existingCampaña == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Campaña not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _campañaRepository.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Campaña deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting campaña",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
