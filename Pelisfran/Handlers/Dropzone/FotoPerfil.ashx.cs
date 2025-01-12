using Pelisfran.Contexto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pelisfran.Handlers.Dropzone
{
    /// <summary>
    /// Descripción breve de FotoPerfil
    /// </summary>
    public class FotoPerfil : IHttpHandler
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        public void ProcessRequest(HttpContext context)
        {
            Guid usuarioId = Guid.Parse(context.Request.QueryString["id"]);

            HttpPostedFile image = context.Request.Files[0];

            string ruta = $"/Uploads/FotosPerfil/{usuarioId}";

            if (!Directory.Exists(context.Server.MapPath(ruta)))
            {
                Directory.CreateDirectory(context.Server.MapPath(ruta));
            }
            string rutaConFileName = $"{ruta}/{image.FileName}";
            image.SaveAs(context.Server.MapPath($"{ruta}/{image.FileName}"));


            // ten cuenta que ahora mismo, si el user tenia foto de perfil, no elimina la antigua.
            // molaria guardar la nueva y eliminar la antigua,(en caso de que todo sea OK)
            // ademas tmb quiero actualizar el upFotoPerfil, cuando la fotoperfil se suba
            Modelos.FotoPerfil fotoPerfil = _db.FotosPerfiles.Find(usuarioId);
            fotoPerfil.Extension = Path.GetExtension(image.FileName);
            fotoPerfil.NombreOriginal = image.FileName;
            fotoPerfil.Ruta = rutaConFileName;

            _db.SaveChanges();

            context.Response.ContentType = "text/plain";
            context.Response.StatusCode = 200;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}