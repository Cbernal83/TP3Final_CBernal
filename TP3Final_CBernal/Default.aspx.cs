using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3Final_CBernal
{
    public partial class Default : System.Web.UI.Page
    {
        public List<articulos>ListaArticulos { get; set; }
          
        protected void Page_Load(object sender, EventArgs e)
        {
          
            articulosNegocio negocio = new articulosNegocio();
            ListaArticulos = negocio.listarStoredProcedure();
           

            if (! IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulos;
                
                repRepetidor.DataBind();

            }
                       
        }

        protected void btn_detalles_Click(object sender, EventArgs e)
        {
            string valorID = ((Button)sender).CommandArgument;

            Response.Redirect("Articulo.aspx?Id=" + valorID) ;
        }

                  


        protected void btn_fav_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                string valorID = ((Button)sender).CommandArgument;


                favoritos addFav = new favoritos();
                users usuario = (users)Session["Usuario"];


                addFav.IdUser = new users();
                addFav.IdUser.Id = usuario.Id;

                addFav.IdArticulo = new articulos();
                addFav.IdArticulo.Id = int.Parse(valorID);


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