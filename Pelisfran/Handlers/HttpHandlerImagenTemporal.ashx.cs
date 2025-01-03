﻿using Pelisfran.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pelisfran.Handlers
{
    /// <summary>
    /// Descripción breve de HttpHandler
    /// </summary>
    public class HttpHandlerImagenTemporal : IHttpHandler
    {
        private FileTemporalServicio _fileTemporalServicio = new FileTemporalServicio();

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                var uploadedFile = context.Request.Files[0];
                Guid guid = Guid.NewGuid();

                _fileTemporalServicio.GuardarPortadaDeUnaPelicula(uploadedFile, guid);

                string originalFileName = Path.GetFileName(uploadedFile.FileName);
                string tempFileName = $"{guid}{Path.GetExtension(originalFileName)}";

                context.Response.ContentType = "application/json";
                context.Response.Write($"{{ \"originalFileName\": \"{originalFileName}\", \"tempFileName\": \"{tempFileName}\" }}");
            }
            else
            {
                context.Response.ContentType = "application/json";
                context.Response.Write("{\"status\": \"error\", \"message\": \"No file uploaded\"}");
            }
        }

        public bool IsReusable => false;
    }
}