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
    public partial class Favoritos : System.Web.UI.Page
    {
             
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"]!=null)
                {
                    users usuario = (users)Session["Usuario"];
                    
                    favoritosNegocio userId = new favoritosNegocio();

                    if (!IsPostBack)
                    {

                        repRepetidor.DataSource = userId.listarFavoritos(usuario.Id); 

                        repRepetidor.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
                
            }

            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
           
        }

        protected void btn_detalles_Click(object sender, EventArgs e)
        {
            string valorID = ((Button)sender).CommandArgument;

            Response.Redirect("Articulo.aspx?Id=" + valorID);
        }

        protected void btn_Remove_Click(object sender, EventArgs e)
        {
            string IDProducto = ((Button)sender).CommandArgument;

            users usuario = (users)Session["Usuario"];

            favoritosNegocio remove = new favoritosNegocio();

            remove.RemoveArt(usuario.Id, IDProducto);

            Response.Redirect("Favoritos.aspx", false);
        }
    }
}