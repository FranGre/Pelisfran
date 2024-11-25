using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace Pelisfran.Servicios
{
    public class FileServicio
    {
        private string rutaCarpetaDondeSeAlojaPortadaDeUnaPelicula = HttpContext.Current.Server.MapPath("~/Uploads/Portadas/Peliculas/");
        private string rutaCarpetaDondeSeAlojaVideoDeUnaPelicula = HttpContext.Current.Server.MapPath("~/Uploads/Videos/Peliculas/");

        public FileServicio() { }

        public void GuardarPortadaDeUnaPelicula(FileUpload fileUpload, Guid peliculaId)
        {
            var rutaCarpetaDestino = $"{rutaCarpetaDondeSeAlojaPortadaDeUnaPelicula}/{peliculaId}";
            GuardarArchivo(rutaCarpetaDestino, fileUpload, peliculaId);
        }

        public void GuardarVideoDeUnaPelicula(FileUpload fileUpload, Guid peliculaId)
        {
            var rutaCarpetaDestino = $"{HttpContext.Current.Server.MapPath(rutaCarpetaDondeSeAlojaVideoDeUnaPelicula)}/{peliculaId}";
            GuardarArchivo(rutaCarpetaDestino, fileUpload, peliculaId);
        }

        private void GuardarArchivo(string ruta, FileUpload fileUpload, Guid peliculaId)
        {
            var rutaCarpetaDestino = $"{ruta}/{peliculaId}";

            if (!Directory.Exists($"{ruta}"))
            {
                Directory.CreateDirectory($"{ruta}");
            }

            fileUpload.SaveAs($"{ruta}/{fileUpload.FileName}");
        }
    }
}