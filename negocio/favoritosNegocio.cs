using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{

    public class favoritosNegocio
    {
        

        AccesoDatos datos = new AccesoDatos();

        public void AgregarFavorito (favoritos addFav)
        {
            datos.setearConsultaSP("AddFavorito");
            datos.setearParametros("@IdUser", addFav.IdUser.Id);
            datos.setearParametros("@IdArticulo", addFav.IdArticulo.Id);
            datos.ejecutarAccion();
        }

        public List<articulos> listarFavoritos (int id)
        {
            List<articulos> listaFav = new List<articulos>();

            datos.setearConsultaSP("ListaFavoritosUser");
            datos.setearParametros("@IdUser", id);

            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {
                articulos aux = new articulos();
                aux.Id = (int)datos.Lector["Id"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Precio = (decimal)datos.Lector["Precio"];

                if (! (datos.Lector["ImagenUrl"] is DBNull))
                {
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                }

                listaFav.Add(aux);
            }


            return listaFav;
        }

        public void RemoveArt(int id, string iDProducto)
        {
            datos.setearConsultaSP("RemoveFav");
            datos.setearParametros("@IdUser", id);
            datos.setearParametros("@IdArticulo", iDProducto);
            datos.ejecutarAccion();

        }
    }
}
