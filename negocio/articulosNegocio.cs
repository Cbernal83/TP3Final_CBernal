using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class articulosNegocio
    {
        //Metodo para leer la DB de Articulos, y guardarlo en una lista
        public List <articulos> listar ()
        {
            List<articulos> listaArt = new List<articulos>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS01; database=CATALOGO_WEB_DB; Integrated Security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id,Nombre,A.Descripcion,ImagenUrl,M.Descripcion Marca,C.Descripcion Categoria,Precio " +
                    "from ARTICULOS A, MARCAS M, CATEGORIAS C " +
                    "where A.IdMarca = M.Id and A.IdCategoria = C.Id";

                //Conexion donde ejecutamos la consulta CommandText
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                //Es un Read Metodo Booleano que me dice si existe una tabla para leer. Si es true ingresa while
                while (lector.Read()) 
                {
                    articulos aux = new articulos();

                    aux.Id = (int)lector["Id"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];

                    if (!(lector["ImagenUrl"] is DBNull))
                    {
                     aux.ImagenUrl = (string)lector["ImagenUrl"];
                    }

                    aux.Marca = new marcas();
                    aux.Marca.Descripcion = (string)lector["Marca"];
                    
                    aux.Categoria = new categorias();
                    aux.Categoria.Descripcion = (string)lector["Categoria"];


                    listaArt.Add(aux);
                }


                return listaArt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List <articulos> listarStoredProcedure()
        {
            List<articulos> listaArt = new List<articulos>();
            AccesoDatos conexion = new AccesoDatos();
            marcas mar = new marcas();

            try
            {
                conexion.setearConsultaSP("StoredListar");
                
                conexion.ejecutarLectura();
               

                while (conexion.Lector.Read())
                {
                    articulos aux = new articulos();

                    aux.Id = (int)conexion.Lector["Id"];
                    aux.Codigo = (string)conexion.Lector["Codigo"];
                    aux.Nombre = (string)conexion.Lector["Nombre"];
                    aux.Descripcion = (string)conexion.Lector["Descripcion"];
                    aux.Precio = (decimal)conexion.Lector["Precio"];

                    if (!(conexion.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    }

                    aux.Marca = new marcas();
                    aux.Marca.Id = (int)conexion.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)conexion.Lector["Marca"];

                    aux.Categoria = new categorias();
                    aux.Categoria.Id = (int)conexion.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)conexion.Lector["Categoria"];

                    
                    listaArt.Add(aux);
                }

                return listaArt;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }



        public List<articulos> listarStoredProcedureOrden(articulos orden)
        {
            List<articulos> listaArt = new List<articulos>();
            AccesoDatos conexion = new AccesoDatos();

            try
            {
                conexion.setearConsultaSP("StoredOrdenaPrecio");
                conexion.setearParametros("@Orden", orden.Orden);

                conexion.ejecutarLectura();

                while (conexion.Lector.Read())
                {
                    articulos aux = new articulos();

                    aux.Id = (int)conexion.Lector["Id"];
                    aux.Codigo = (string)conexion.Lector["Codigo"];
                    aux.Nombre = (string)conexion.Lector["Nombre"];
                    aux.Descripcion = (string)conexion.Lector["Descripcion"];
                    aux.Precio = (decimal)conexion.Lector["Precio"];

                    if (!(conexion.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    }

                    aux.Marca = new marcas();
                    aux.Marca.Id = (int)conexion.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)conexion.Lector["Marca"];

                    aux.Categoria = new categorias();
                    aux.Categoria.Id = (int)conexion.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)conexion.Lector["Categoria"];


                    listaArt.Add(aux);
                }

                return listaArt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificacionArticuloSP(articulos update)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultaSP("StoredModificarArticulo");

                datos.setearParametros("@Id", update.Id);
                datos.setearParametros("@Codigo", update.Codigo);
                datos.setearParametros("@Nombre", update.Nombre);
                datos.setearParametros("@Precio", update.Precio);
                datos.setearParametros("@ImageUrl", update.ImagenUrl);
                datos.setearParametros("@Descripcion", update.Descripcion);
                datos.setearParametros("@IdMarca", update.Marca.Id);
                datos.setearParametros("@IdCategoria", update.Categoria.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AltaArticuloSP (articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultaSP("StoredAltaArticulo");

                datos.setearParametros("@Codigo", nuevo.Codigo);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Precio", nuevo.Precio);
                datos.setearParametros("@ImageUrl", nuevo.ImagenUrl);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@IdMarca", nuevo.Marca.Id);
                datos.setearParametros("@IdCategoria", nuevo.Categoria.Id);

                datos.ejecutarAccion();
                    
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void EliminarArticuloSP ( articulos eliminar)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();

                datos.setearConsultaSP("StoredEliminar");
                datos.setearParametros("@Id", eliminar.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }


        public List<articulos> ListarBusquedaAvanzada (articulos buscar)
        {
            List<articulos> listaFiltroAvanzado = new List<articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
               datos.setearConsultaSP("StoredBusquedaAvanzada");
               datos.setearParametros("@Nombre", buscar.Nombre);
               datos.setearParametros("@IdMarca", buscar.Marca.Id);
               datos.setearParametros("@IdCategoria", buscar.Categoria.Id);
               datos.setearParametros("@Orden", buscar.Orden);

               datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulos aux = new articulos();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }

                    aux.Marca = new marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];


                    listaFiltroAvanzado.Add(aux);
                }

            return listaFiltroAvanzado;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
