using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3Final_CBernal
{
    public partial class Articulo : System.Web.UI.Page
    {
        public List<articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] !=null)
            {
                articulosNegocio negocio = new articulosNegocio();

                int id = int.Parse(Request.QueryString["Id"].ToString());

                //List<articulos> GrillaProductos = (List < articulos >) Session["GrillaProductos"];

                ListaArticulos = negocio.listarStoredProcedure();

                articulos seleccionado = ListaArticulos.Find(x => x.Id == id);

                lbl_TITULO.Text = seleccionado.Nombre.ToString();
                lbl_precio.Text = seleccionado.Precio.ToString("N");
                Img_imagen.ImageUrl = seleccionado.ImagenUrl.ToString();
                lbl_descripcion.Text = seleccionado.Descripcion.ToString();
                
            }

        }

        protected void btn_addFavoritos_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                string id = (Request.QueryString["Id"].ToString());


                favoritos addFav = new favoritos();
                users usuario = (users)Session["Usuario"];


                addFav.IdUser = new users();
                addFav.IdUser.Id = usuario.Id;

                addFav.IdArticulo = new articulos();
                addFav.IdArticulo.Id = int.Parse(id);


                favoritosNegocio favorito = new favoritosNegocio();

                favorito.AgregarFavorito(addFav);

            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }
    }
}