
using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Collections.Generic;

namespace Pelisfran.SeedersBaseDatos
{
    public class SeederRoles
    {
        private PelisFranDBContexto _db;

        public SeederRoles() { _db = new PelisFranDBContexto(); }


        public void Insertar()
        {
            List<Rol> roles = new List<Rol>() {
                new Rol { Nombre = "ADMINISTRADOR", Tipo= Enums.TipoRolesEnum.Administrador, CreadoEn = DateTime.Now},
                new Rol { Nombre = "CLIENTE", Tipo= Enums.TipoRolesEnum.Cliente, CreadoEn = DateTime.Now},
            };

            _db.Roles.AddRange(roles);
            _db.SaveChanges();
        }
    }
}