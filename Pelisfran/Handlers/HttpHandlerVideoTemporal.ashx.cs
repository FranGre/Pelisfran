using Pelisfran.Servicios;
using System;
using System.IO;
using System.Web;

namespace Pelisfran.Handlers
{
    /// <summary>
    /// Descripción breve de HttpHandlerVideoTemporal
    /// </summary>
    public class HttpHandlerVideoTemporal : IHttpHandler
    {
        private FileTemporalServicio _fileTemporalServicio = new FileTemporalServicio();

        public void ProcessRequest(HttpContext context)
        {

            // Leer los parámetros del cuerpo de la solicitud
            var chunkNumber = context.Request["dzchunkindex"];
            var totalChunks = context.Request["dztotalchunkcount"];
            var fileName = context.Request["dzuuid"] + "_" + context.Request["name"];
            var filePath = Path.Combine(context.Server.MapPath("~/Uploads"));
            string tempFilePath = context.Server.MapPath("~/TempUploads/" + fileName);

            // Asegúrate de que el directorio de temporales exista
            if (!Directory.Exists(Path.GetDirectoryName(tempFilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
            }

            using (var fs = new FileStream(tempFilePath, FileMode.Append, FileAccess.Write))
            {
                context.Request.InputStream.CopyTo(fs);
            }

            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/plain";
            context.Response.Write("Chunk uploaded successfully");
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}