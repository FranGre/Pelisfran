using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pelisfran.Helpers
{
    public class HelperFecha
    {

        public static int ObtenerDiasTranscurridos(DateTime fecha)
        {
            return (DateTime.Now - fecha).Days;
        }

        public static string ObtenerTiempoTranscurrido(DateTime fecha)
        {
            int diasTranscurridos = ObtenerDiasTranscurridos(fecha);

            if (diasTranscurridos >= 365)
            {
                int anyos = diasTranscurridos / 365;
                return $"hace {anyos} year/s";
            }

            if (diasTranscurridos >= 31)
            {
                int meses = diasTranscurridos / 12;
                return $"hace {meses} month/s";
            }

            if (diasTranscurridos >= 7)
            {
                int semanas = diasTranscurridos / 7;
                return $"hace {semanas} semana/s";
            }

            if (diasTranscurridos >= 2)
            {
                return $"hace {diasTranscurridos} dia/s";
            }

            if (diasTranscurridos == 1)
            {
                return "ayer";
            }

            return "hoy";

        }
    }
}