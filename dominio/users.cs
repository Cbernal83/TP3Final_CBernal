using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        normal = 0,
        admin = 1
    }
    public class users
    {
        public int Id { get; set; }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                if (value!="")
                {
                    email = value;
                }
                else
                {
                    throw new Exception("email vacio en el dominio");
                }
            }
        }

        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UrlImagenPerfil { get; set; }
        public bool Admin { get; set; }

        public TipoUsuario TU { get; set; }


        //CONTRUCTORES
        public users()
        {

        }

        
        public users (string mail,string pass,bool admin)
        {
            Email = mail;
            Pass = pass;

            TU = admin ? TipoUsuario.admin : TipoUsuario.normal;
        }
    }

    
}
