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

            var chunkNumber = int.Parse(context.Request["dzchunkindex"]);
            var totalChunks = int.Parse(context.Request["dztotalchunkcount"]);
            var uuid = context.Request["dzuuid"];
            var originalFileName = context.Request["name"];
            var fileExtension = Path.GetExtension(originalFileName);

            // Nombre único para cada chunk
            string tempChunkPath = context.Server.MapPath($"~/TempUploads/{uuid}_chunk_{chunkNumber}");
            string finalFilePath = context.Server.MapPath($"~/Uploads/{uuid}{fileExtension}");

            // Guardar el chunk en un archivo temporal
            using (var fs = new FileStream(tempChunkPath, FileMode.Create, FileAccess.Write))
            {
                context.Request.InputStream.CopyTo(fs);
            }

            // Si es el último chunk, combinar todos
            if (chunkNumber == totalChunks - 1)
            {
                using (var finalStream = new FileStream(finalFilePath, FileMode.Create, FileAccess.Write))
                {
                    for (int i = 0; i < totalChunks; i++)
                    {
                        string chunkPath = context.Server.MapPath($"~/TempUploads/{uuid}_chunk_{i}");
                        using (var chunkStream = new FileStream(chunkPath, FileMode.Open, FileAccess.Read))
                        {
                            chunkStream.CopyTo(finalStream);
                        }
                        File.Delete(chunkPath); // Eliminar chunk después de combinarlo
                    }
                }
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