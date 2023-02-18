using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            users usuario = user != null ? (users) user : null;

            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;

        }

        //public static bool esAdmin(object user)
        //{
        //    users usuario = user != null ? (users)user : null;
        //    return usuario != null ? usuario.TU == dominio.TipoUsuario.admin : false;

           
        //}

        public static bool esAdmin(object user)
        {
            users usuario = user != null ? (users)user : null;
            return usuario != null ? usuario.Admin : false;


        }
    }
}
