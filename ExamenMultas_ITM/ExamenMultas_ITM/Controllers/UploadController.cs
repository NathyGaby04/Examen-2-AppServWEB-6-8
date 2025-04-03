using ExamenMultas_ITM.Clases;
using ExamenMultas_ITM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Servicios_6_8.Controllers
{
    [RoutePrefix("UploadFiles")]
    public class UploadFilesController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> GrabarArchivo(HttpRequestMessage Request, string Datos, string Proceso)
        {
            ClUpload UploadFiles = new ClUpload();
            UploadFiles.request = Request;
            UploadFiles.Datos = Datos;
            UploadFiles.Proceso = Proceso;
            return await UploadFiles.GrabarArchivo(false);
        }
        [HttpGet]
        public HttpResponseMessage Get(string NombreImagen)
        {
            ClUpload upload = new ClUpload();
            return upload.ConsultarArchivo(NombreImagen);
        }
        [HttpPut]
        public async Task<HttpResponseMessage> ActualizarArchivo(HttpRequestMessage Request, string Datos, string Proceso)
        {
            ClUpload UploadFiles = new ClUpload();
            UploadFiles.request = Request;
            UploadFiles.Datos = Datos;
            UploadFiles.Proceso = Proceso;
            return await UploadFiles.GrabarArchivo(true);
        }
        [HttpDelete]
        public string EliminarArchivo(int idFoto)
        {
            ClFotoInfraccion FotoInfraccion= new ClFotoInfraccion();
            FotoInfraccion fotoinfraccion = new FotoInfraccion();
            ClUpload Upload = new ClUpload();
            fotoinfraccion.NombreFoto = FotoInfraccion.Consultar(idFoto).NombreFoto;
            if (Upload.Eliminar(fotoinfraccion.NombreFoto).IsSuccessStatusCode)
            {
                return FotoInfraccion.Eliminar(idFoto);
            }
            return "Hubo un error eliminando el archivo ";

        }
    }
}