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
            var request = context.Request;
            var response = context.Response;

            // Leer los parámetros del cuerpo de la solicitud
            string fileName = request.Form["name"];
            string chunkIndex = request.Form["dzchunkindex"];
            string totalChunks = request.Form["dztotalchunks"];
            string tempFilePath = context.Server.MapPath("~/TempUploads/" + fileName);

            // Asegúrate de que el directorio de temporales exista
            if (!Directory.Exists(Path.GetDirectoryName(tempFilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
            }

            if (request.Files.Count > 0)
            {
                var file = request.Files[0];
                var chunk = file.InputStream;

                // Si es el primer chunk, lo creamos
                if (chunkIndex == "0")
                {
                    using (FileStream fs = new FileStream(tempFilePath, FileMode.Create))
                    {
                        chunk.CopyTo(fs);
                    }
                }
                else
                {
                    // Si ya hay chunks, se añaden al archivo temporal
                    using (FileStream fs = new FileStream(tempFilePath, FileMode.Append))
                    {
                        chunk.CopyTo(fs);
                    }
                }
            }

            // Enviar una respuesta para que DropZone sepa que el chunk fue recibido
            response.StatusCode = 200;
            response.ContentType = "text/plain";
            response.Write("Chunk uploaded successfully");

            // Si es el último chunk, puedes unirlo o hacer lo que necesites (como moverlo al lugar definitivo)
            if (chunkIndex == (Convert.ToInt32(totalChunks) - 1).ToString())
            {
                // Aquí puedes mover el archivo final, verificar que todos los chunks llegaron, etc.
                // Ejemplo: File.Move(tempFilePath, finalPath);
            }

            response.End();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}