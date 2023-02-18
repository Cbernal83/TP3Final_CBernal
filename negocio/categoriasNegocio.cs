using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class categoriasNegocio
    {
        public List<categorias> listar()
        {
            List<categorias> lista = new List<categorias>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearCosulta("select id,Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    categorias aux = new categorias();

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
