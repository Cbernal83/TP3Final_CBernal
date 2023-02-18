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
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //AVATAR POR DEFECTO
            img_avatar.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_640.png";


            if (!(Page is Login || Page is Default || Page is Resultados || Page is ErrorLogin || Page is Articulo || Page is Registrarse || Page is Favoritos))
            {
                if (!(Seguridad.sesionActiva(Session["Usuario"])))
                {
                    Response.Redirect("Login.aspx", false);
                }

            }

            if (Seguridad.sesionActiva(Session["Usuario"]))
            {
                //Recupero los datos del Usuario en Sesion para Mostar en NavBar
                users usuario = (users)Session["Usuario"];

                lbl_usuario.Text = usuario.Nombre +" "+usuario.Apellido;

                if (!(string.IsNullOrEmpty(usuario.UrlImagenPerfil)))
                {
                 img_avatar.ImageUrl = "~/Images/Perfil/" + usuario.UrlImagenPerfil;
                }
            }

        }

        protected void btn_cerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }

        protected void txb_buscadorMaster_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}