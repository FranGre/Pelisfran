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
    public class HttpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                var uploadedFile = context.Request.Files[0];
                var fileName = Path.GetFileName(uploadedFile.FileName);
                var filePath = context.Server.MapPath("~/Uploads/" + fileName);

                uploadedFile.SaveAs(filePath);

                context.Response.ContentType = "application/json";
                context.Response.Write("{\"status\": \"success\", \"file\": \"" + fileName + "\"}");
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