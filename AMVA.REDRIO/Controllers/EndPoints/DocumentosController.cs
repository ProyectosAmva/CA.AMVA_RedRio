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
    /// Controlador encargado de gestionar los documentos: agregar, obtener, eliminar y descargar.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DocumentosController : ControllerBase
    {
        /// <summary>
        /// Constructor que inyecta los servicios necesarios: DocumentoService.
        /// </summary>
        /// <param name="webHostEnvironment">Entorno de alojamiento  para acceder al sistema de archivos.</param>
    private readonly IRepository<Documento> _documentoRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;

       public DocumentosController(IRepository<Documento> documentoRepository, IWebHostEnvironment webHostEnvironment)
{
    _documentoRepository = documentoRepository;
    _webHostEnvironment = webHostEnvironment;
}


        public string SanearNombreArchivo(string nombreArchivo)
        {
            // Obtener los caracteres no válidos para los nombres de archivo en el sistema operativo
            char[] invalidChars = Path.GetInvalidFileNameChars();

            // Reemplazar todos los caracteres no válidos por un guion bajo
            foreach (var invalidChar in invalidChars)
            {
                nombreArchivo = nombreArchivo.Replace(invalidChar.ToString(), "_");
            }

            // Reemplazar paréntesis por guiones bajos, ya que pueden causar problemas en URLs y en algunos contextos
            nombreArchivo = nombreArchivo.Replace("(", "_").Replace(")", "_");

            // Reemplazar también los espacios por guiones bajos si es necesario
            nombreArchivo = nombreArchivo.Replace(" ", "_");

            return nombreArchivo;
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

            // Limpiar el nombre del archivo
            originalFileName = SanearNombreArchivo(originalFileName);

            string fileExtension = Path.GetExtension(file.FileName);
            string newFileName = $"{dateString}_{originalFileName}{fileExtension}";

            string filePath = Path.Combine(folderPath, newFileName);

            // Verificar si la ruta es válida antes de escribir el archivo
            if (filePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                throw new ArgumentException("La ruta contiene caracteres no válidos.");
            }

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

            await _documentoRepository.AddAsync(Documento);

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
                var Documento = await _documentoRepository.GetByIdAsync(id);
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
                var existingDocumento = await _documentoRepository.GetByIdAsync(id);
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

                await _documentoRepository.DeleteAsync(id);

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
            var Documento = await _documentoRepository.GetByIdAsync(id);
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
