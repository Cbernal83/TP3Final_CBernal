using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class marcasNegocio
    {
        public List<marcas> listar()
        {
            List<marcas> lista = new List<marcas>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearCosulta("select id,Descripcion from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    marcas aux = new marcas();

                    aux.Id = (int)datos.Lector["id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);

                }

                 return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }     
        }
    }
}
