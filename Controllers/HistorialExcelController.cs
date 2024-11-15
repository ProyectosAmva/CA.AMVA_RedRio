using AMVA.REDRIO.Models;
using AMVA.REDRIO.Core;
using AMVA.REDRIO.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AMVA.REDRIO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialExcelController : ControllerBase
    {
        private readonly HistorialExcelService _historialExcelService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HistorialExcelController(HistorialExcelService historialExcelService, IWebHostEnvironment webHostEnvironment)
        {
            _historialExcelService = historialExcelService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("ObtenerHistorialExceles")]
        public async Task<ActionResult<Response>> GetAllHistorialExcels()
        {
            try
            {
                var historialExcels = await _historialExcelService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "HistorialExcels retrieved successfully",
                    Result = historialExcels
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving HistorialExcels",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerHistorialExcel/{id}")]
        public async Task<ActionResult<Response>> GetByIdHistorialExcel(int id)
        {
            try
            {
                var historialExcel = await _historialExcelService.GetByIdAsync(id);
                if (historialExcel == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "HistorialExcel not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "HistorialExcel retrieved successfully",
                    Result = historialExcel
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving HistorialExcel",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerHistorialExcelPorCampaña/{idCampaña}")]
                public async Task<ActionResult<Response>> GetByCampañaAsync(int idCampaña)
                {
                    try
                    {
                        var HistorialExcel = await _historialExcelService.GetByCampañasAsync(idCampaña);
                        if (HistorialExcel == null || !HistorialExcel.Any())
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
                            Result = HistorialExcel
                        };
                        return Ok(responseGetById);
                    }
                    catch (Exception ex)
                    {
                        var responseError = new Response
                        {
                            IsSuccess = false,
                            MessageError = "Error al recuperar los reportes de laboratorio.",
                            Error = ex.Message
                        };
                        return StatusCode(StatusCodes.Status500InternalServerError, responseError);
                    }
                }

        [Route("AgregarHistorialExcel")]
    [HttpPost]
    public async Task<ActionResult<Response>> AddHistorialExcel([FromForm] IFormFile file, [FromForm] int IdUsuario, [FromForm] int IdCampaña)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    MessageError = "No file was uploaded."
                });
            }

            if (file.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" &&
                file.ContentType != "application/vnd.ms-excel")
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    MessageError = "The file is not a valid Excel document."
                });
            }

            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "excel");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string dateString = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string originalFileName = Path.GetFileNameWithoutExtension(file.FileName);
            string fileExtension = Path.GetExtension(file.FileName);
            string newFileName = $"{dateString}_{originalFileName}{fileExtension}";

            string filePath = Path.Combine(folderPath, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            string nombreConFecha = $"{originalFileName}_{dateString}";

            var historialExcel = new HistorialExcel
            {
                Fecha_cargue = DateTime.Now,
                Url = $"/uploads/excel/{newFileName}",
                nombre = nombreConFecha,  
                IdCampaña = IdCampaña,
                IdUsuario = IdUsuario
            };

            await _historialExcelService.AddAsync(historialExcel);

            var responseCreated = new Response
            {
                IsSuccess = true,
                Message = "HistorialExcel created successfully",
                Result = historialExcel
            };
            return CreatedAtAction(nameof(GetByIdHistorialExcel), new { id = historialExcel.IdHistorialExcel }, responseCreated);
        }
        catch (Exception ex)
        {
            var responseError = new Response
            {
                IsSuccess = false,
                MessageError = "Error creating HistorialExcel",
                Error = ex.Message
            };
            return StatusCode(StatusCodes.Status500InternalServerError, responseError);
        }
    }


        [HttpPut("ActualizarHistorialExcel/{id}")]
        public async Task<IActionResult> UpdateHistorialExcel(int id, [FromBody] HistorialExcel historialExcel)
        {
            try
            {
                var existingHistorialExcel = await _historialExcelService.GetByIdAsync(id);
                if (existingHistorialExcel == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "HistorialExcel not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingHistorialExcel.Fecha_cargue = historialExcel.Fecha_cargue;
                existingHistorialExcel.Url = historialExcel.Url;
                existingHistorialExcel.IdCampaña =  historialExcel.IdCampaña;
                existingHistorialExcel.Fecha_actualizacion = DateTime.Now;


                await _historialExcelService.UpdateAsync(existingHistorialExcel);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "HistorialExcel updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating HistorialExcel",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarHistorialExcel/{id}")]
        public async Task<IActionResult> DeleteHistorialExcel(int id)
        {
            try
            {
                var existingHistorialExcel = await _historialExcelService.GetByIdAsync(id);
                if (existingHistorialExcel == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "HistorialExcel not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _historialExcelService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "HistorialExcel deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting HistorialExcel",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    
    [HttpGet("DescargarHistorialExcel/{id}")]
        public async Task<IActionResult> DownloadHistorialExcel(int id)
        {
            try
            {
                var historialExcel = await _historialExcelService.GetByIdAsync(id);
                if (historialExcel == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "HistorialExcel not found"
                    };
                    return NotFound(responseNotFound);
                }

                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, historialExcel.Url.TrimStart('/'));
                if (!System.IO.File.Exists(filePath))
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "File not found"
                    };
                    return NotFound(responseNotFound);
                }

                var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", historialExcel.Url);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error downloading HistorialExcel",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    
    }
}


