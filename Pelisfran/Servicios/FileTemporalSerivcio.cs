using System;
using System.IO;
using System.Web;

namespace Pelisfran.Servicios
{
    public class FileTemporalServicio
    {
        private string rutaCarpetaDondeSeAlojaPortadaDeUnaPelicula = HttpContext.Current.Server.MapPath("~/Uploads/Temp/Portadas/Peliculas/");
        private string rutaCarpetaDondeSeAlojaVideoDeUnaPelicula = HttpContext.Current.Server.MapPath("~/Uploads/Temp/Videos/Peliculas/");
        private string rutaCarpetaDondeSeAlojaPortadaDeUnaSerie = HttpContext.Current.Server.MapPath("~/Uploads/Temp/Portadas/Series/");

        public FileTemporalServicio() { }

        public void GuardarPortadaDeUnaPelicula(HttpPostedFile file, Guid guid)
        {
            var rutaCarpetaDestino = $"{rutaCarpetaDondeSeAlojaPortadaDeUnaPelicula}";
            GuardarArchivo(rutaCarpetaDestino, file, guid);
        }

        public void GuardarVideoDeUnaPelicula(HttpPostedFile file, Guid guid)
        {
            var rutaCarpetaDestino = $"{rutaCarpetaDondeSeAlojaVideoDeUnaPelicula}";
            GuardarArchivo(rutaCarpetaDestino, file, guid);
        }

        public void GuardarPortadaDeUnaSerie(HttpPostedFile file, Guid guid)
        {
            var rutaCarpetaDestino = $"{rutaCarpetaDondeSeAlojaPortadaDeUnaSerie}";
            GuardarArchivo(rutaCarpetaDestino, file, guid);
        }

        private void GuardarArchivo(string ruta, HttpPostedFile file, Guid guid)
        {
            var rutaCarpetaDestino = $"{ruta}";

            if (!Directory.Exists($"{ruta}"))
            {
                Directory.CreateDirectory($"{ruta}");
            }

            file.SaveAs($"{ruta}/{guid}{Path.GetExtension(file.FileName)}");
        }
    }
}