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
     /// <summary>
    /// Controlador encargado de gestionar los documentos: agregar, obtener, eliminar y descargar.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentosController : ControllerBase
    {
        /// <summary>
        /// Constructor que inyecta los servicios necesarios: DocumentoService.
        /// </summary>
        /// <param name="webHostEnvironment">Entorno de alojamiento  para acceder al sistema de archivos.</param>
        private readonly DocumentoService _DocumentosService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DocumentosController(DocumentoService DocumentosService, IWebHostEnvironment webHostEnvironment)
        {
            _DocumentosService = DocumentosService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("AgregarDocumento")]
        public async Task<ActionResult<Response>> AddDocumento([FromForm] IFormFile file)
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

                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "Documentos");

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

                var Documento = new Documento
                {
                    Fecha_cargue = DateTime.Now,
                    Url = $"/uploads/Documentos/{newFileName}",
                    Nombre = originalFileName,
                };

                await _DocumentosService.AddAsync(Documento);

                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Documento created successfully",
                    Result = Documento
                };
                return CreatedAtAction(nameof(GetByIdDocumento), new { id = Documento.Id_Documento }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating Documento",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerDocumento/{id}")]
        public async Task<ActionResult<Response>> GetByIdDocumento(int id)
        {
            try
            {
                var Documento = await _DocumentosService.GetByIdAsync(id);
                if (Documento == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Documento not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Documento retrieved successfully",
                    Result = Documento
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Documento",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

       [HttpDelete("EliminarDocumento/{id}")]
        public async Task<IActionResult> DeleteDocumento(int id)
        {
            try
            {
                var existingDocumento = await _DocumentosService.GetByIdAsync(id);
                if (existingDocumento == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Documento no encontrado"
                    };
                    return NotFound(responseNotFound);
                }

                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, existingDocumento.Url.TrimStart('/'));

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                else
                {
                    var responseNotFoundFile = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Archivo no encontrado en el sistema"
                    };
                    return NotFound(responseNotFoundFile);
                }

                await _DocumentosService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Documento y archivo eliminados correctamente"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error al eliminar el documento",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }


       [HttpGet("DescargarDocumento/{id}")]
    public async Task<IActionResult> DownloadDocumento(int id)
    {
        try
        {
            var Documento = await _DocumentosService.GetByIdAsync(id);
            if (Documento == null)
            {
                var responseNotFound = new Response
                {
                    IsSuccess = false,
                    MessageError = "Documento not found"
                };
                return NotFound(responseNotFound);
            }

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, Documento.Url.TrimStart('/'));
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

            var fileName = Path.GetFileName(Documento.Url); 
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
        catch (Exception ex)
        {
            var responseError = new Response
            {
                IsSuccess = false,
                MessageError = "Error downloading Documento",
                Error = ex.Message
            };
            return StatusCode(StatusCodes.Status500InternalServerError, responseError);
        }
    }

    }
}
