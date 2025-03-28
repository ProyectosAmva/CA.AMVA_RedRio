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
    /// Controlador para manejar las operaciones CRUD relacionadas con los Biológicos.
    /// Proporciona métodos para obtener, agregar, actualizar y eliminar registros de Biológicos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BiologicoController : ControllerBase
    {
        private readonly IRepository<Biologico> _biologicoRepository;

    public BiologicoController(IRepository<Biologico> biologicoRepository)
    {
        _biologicoRepository = biologicoRepository;
    }

        [HttpGet("ObtenerBiologicos")]
        public async Task<ActionResult<Response>> GetAllBiologicos()
        {
            try
            {
                var Biologicos = await _biologicoRepository.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Biologicos retrieved successfully",
                    Result = Biologicos
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Biologicos",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerBiologico/{id}")]
        public async Task<ActionResult<Response>> GetByIdBiologico(int id)
        {
            try
            {
                var Biologico = await _biologicoRepository.GetByIdAsync(id);
                if (Biologico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Biologico not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Biologico retrieved successfully",
                    Result = Biologico
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Biologico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarBiologico")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddBiologico([FromBody] Biologico biologico)
        {
            try
            {
                biologico.Fecha_creacion = DateTime.Now;
                await _biologicoRepository.AddAsync(biologico);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Biologico created successfully",
                    Result = biologico
                };
                return CreatedAtAction(nameof(GetByIdBiologico), new { id = biologico.IdBiologico }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating Biologico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarBiologico/{id}")]
        public async Task<IActionResult> UpdateBiologico(int id, [FromBody] Biologico biologico)
        {
            try
            {
                var existingBiologico = await _biologicoRepository.GetByIdAsync(id);
                if (existingBiologico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Biologico not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingBiologico.Escherichia_coli_npm = biologico.Escherichia_coli_npm;
                existingBiologico.Escherichia_coli_ufc = biologico.Escherichia_coli_ufc;
                existingBiologico.Indice_biologico = biologico.Indice_biologico;
                existingBiologico.Coliformes_totales_ufc = biologico.Coliformes_totales_ufc;
                existingBiologico.Coliformes_totales_npm = biologico.Coliformes_totales_npm;
                existingBiologico.Riquezas_algas = biologico.Riquezas_algas;
                existingBiologico.ClasificacionIBiologico = biologico.ClasificacionIBiologico;
                existingBiologico.Observaciones = biologico.Observaciones;
                existingBiologico.Fecha_actualizacion = DateTime.Now;
                existingBiologico.Fecha_Muestra = biologico.Fecha_Muestra;


                await _biologicoRepository.UpdateAsync(existingBiologico);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Biologico updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating Biologico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarBiologico/{id}")]
        public async Task<IActionResult> DeleteBiologico(int id)
        {
            try
            {
                var existingBiologico = await _biologicoRepository.GetByIdAsync(id);
                if (existingBiologico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Biologico not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _biologicoRepository.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Biologico deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting Biologico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
