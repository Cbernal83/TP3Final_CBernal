using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TP3Final_CBernal
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        public bool alerta { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            alerta = false;

            if (!(Seguridad.sesionActiva(Session["Usuario"])))
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {

                users usuario = (users)Session["Usuario"];

                if (!IsPostBack)
                {
                    txb_nombre.Visible = false;
                    txb_apellido.Visible = false;
                    txb_mail.Visible = false;

                    lbl_mail.Text = usuario.Email;
                    lbl_nombre1.Text= usuario.Nombre;
                    lbl_apellido.Text = usuario.Apellido;

                
                }
                if (!(string.IsNullOrEmpty(usuario.UrlImagenPerfil)))
                {
                    Img_Perfil.ImageUrl = "~/Images/Perfil/" + usuario.UrlImagenPerfil;

                }
                else
                {
                     //AVATAR POR DEFECTO
                     Img_Perfil.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_640.png";

                }
            }

            //linkbutton para FileUpload
            LBN_FU.Attributes.Add("onclick", "document.getElementById('"+FU_subirImg.ClientID+"').click();return false;");
            LBN_FU.Visible = false;
            

        }
             

        protected void txb_mail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_editar_Click(object sender, EventArgs e)
        {
            users usuario = (users)Session["Usuario"];

            if (!(string.IsNullOrEmpty(usuario.UrlImagenPerfil)))
            {
                Img_Perfil.ImageUrl = "~/Images/Perfil/" + usuario.UrlImagenPerfil;

            }
            //MAIL
            lbl_mail.Visible = false;
            txb_mail.Visible = true;
            txb_mail.Text = string.Empty;
            txb_mail.Text = lbl_mail.Text;

            //NOMBRE
            lbl_nombre1.Visible = false;
            txb_nombre.Visible = true;

            txb_nombre.Text = lbl_nombre1.Text;

            //APELLIDO
            lbl_apellido.Visible = false;
            txb_apellido.Visible = true;

            txb_apellido.Text = lbl_apellido.Text;

            //Borra alertas 

            lbl_mailexiste.Visible = false;
            lbl_PassNoCoincide.Visible = false;

            //texbo Pass
            txb_Pass.ReadOnly = false;
            txb_PassUpdate.ReadOnly = false;

            //FileUp subir img
            // FU_subirImg.Visible = true;

            LBN_FU.Visible = true;
            txb_FU.Visible = true;

            lbl_FULeyenda.Visible = true;
            lbl_FULeyenda.Text = "Click subir imagen avatar.";

            btn_cancelar.Visible = true;
        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            txb_FU.Visible = false;
            lbl_FULeyenda.Visible = false;


            //CAMBIO MAIL
            lbl_mail.Visible = true;
            txb_mail.Visible = false;

            //CAMBIO NOMBRE
            lbl_nombre1.Visible = true;
            txb_nombre.Visible = false;
                       
            lbl_nombre1.Text = txb_nombre.Text;
       
            //CAMBIO APELLIDO
            lbl_apellido.Visible = true;
            txb_apellido.Visible = false;

            lbl_apellido.Text = txb_apellido.Text;


            usuarioNegocio update = new usuarioNegocio();
            users usuario = (users)Session["Usuario"];
            int Id = usuario.Id;

            try
            {
                if (ControlTexBoxVacio())
                {
                    return;
                }

                if (!isValidMail(txb_mail.Text))
                {
                    return;
                }
                

                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                // Actualizacion Mail

                if (!(update.VerificarCoincidenciaStrings(txb_mail.Text,lbl_mail.Text)))
                {

                    if (!(update.VerificacionMail(txb_mail.Text)))
                    {
                            
                        update.ActualizarDatoMail(txb_mail.Text, Id);
                        lbl_mail.Text = txb_mail.Text;
                        lbl_mailexiste.Visible = false;
                        usuario.Email = txb_mail.Text;
                    }
                    else
                    {
                        lbl_mailexiste.Visible = true;
                    }
                }

              

            }
            catch (Exception ex)
            {

                Session.Add("Error",ex.ToString());
            }

            try
            {
                // Actualizacion Pass
                if (!string.IsNullOrEmpty(txb_Pass.Text))
                {

                    if (update.VerificarPass(txb_Pass.Text,Id))
                    {
                        if (!string.IsNullOrEmpty(txb_PassUpdate.Text))
                        {
                            update.ActualizarDatoPass(txb_PassUpdate.Text, Id);
                            usuario.Pass = txb_PassUpdate.Text;
                            txb_Pass.ReadOnly = true;
                            txb_PassUpdate.ReadOnly = true;
                        }
                        else
                        {
                            //lbl_PassNoCoincide.Text = "Ingresar un nuevo Pass.";
                            //lbl_PassNoCoincide.Visible = true;
                            alerta = true;
                            lbl_Alerta.Text = "Ingresar una clave nueva";
                        }
                    }
                    else
                    {
                        //lbl_PassNoCoincide.Visible = true;
                        alerta = true;
                        lbl_Alerta.Text = "No coincide la clave actual";
                    }
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }

            try
            {
                // Actualizacion Nombre
                if (!string.IsNullOrEmpty(txb_nombre.Text))
                {

                    update.ActualizarDatoNombre(txb_nombre.Text, Id);
                    usuario.Nombre = txb_nombre.Text;
                    lbl_nombre1.Text = txb_nombre.Text;
                    lbl_nombre1.Visible = true;
                    txb_nombre.Visible = false;
                }
                else
                {
                    Alert_Nombre.Visible = true;
                }

                // Actualizacion Apellido
                if (!string.IsNullOrEmpty(txb_apellido.Text))
                {

                    update.ActualizarDatoApellido(txb_apellido.Text, Id);
                    usuario.Apellido = txb_apellido.Text;
                    lbl_apellido.Text = txb_apellido.Text;
                    lbl_apellido.Visible = true;
                    txb_apellido.Visible = false;
                }
                else
                {
                    Alert_Apellido.Visible = true;
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }

            // Imagen de Perfil
            try
            {

                //verifica que el control FileUpload este cargado
                if (FU_subirImg.HasFile == true)
                {
                    //ruta para guardar img
                    string ruta = Server.MapPath("./Images/Perfil/"); 
                    string NombreImg = "perfil-" + usuario.Id + ".jpg";
                    FU_subirImg.PostedFile.SaveAs(ruta + NombreImg);

                    usuario.UrlImagenPerfil = NombreImg;
                    update.UpdateImg(usuario);
                    
                    //Leer IMG
                    Image img = (Image)Master.FindControl("img_avatar");
                    img.ImageUrl = "~/Images/Perfil/" + usuario.UrlImagenPerfil;

                    Img_Perfil.ImageUrl = "~/Images/Perfil/" + usuario.UrlImagenPerfil;

                   
                }

             btn_cancelar.Visible = false;

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }


        }
               

        protected void btn_eliminarCuenta_Click(object sender, EventArgs e)
        {
            usuarioNegocio eliminar = new usuarioNegocio();
            users usuario = (users)Session["Usuario"];
            int Id = usuario.Id;

            eliminar.EliminarCuenta(Id);
            Session.Clear();
            Response.Redirect("Default.aspx", false);
   
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }

        public bool ControlTexBoxVacio()
        {
            foreach (Control item in Page.Form.FindControl("ContentPlaceHolder1").Controls)
            {
                if (item is TextBox)

                {
                    if (((TextBox)item).Text == string.Empty)
                    {
                        alerta = true;
                        lbl_Alerta.Text = "Completar todos los campos";
                        return true;

                    }
                }
            }
            return false;
        }
        private bool isValidMail(string emails)
        {
            string exMail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(exMail);
            if (re.IsMatch(emails))
            {

                return true;
            }

            else
            {
                alerta = true;
                lbl_Alerta.Text = "Formato de Email no es correcto";
                return false;

            }
        }
    }
}