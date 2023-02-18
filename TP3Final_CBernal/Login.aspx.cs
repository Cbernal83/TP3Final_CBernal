using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3Final_CBernal
{
    public partial class Login : System.Web.UI.Page 
    {
        public bool alertaErrorLogin { get; set; }
        public bool alerta { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            alertaErrorLogin = false;
        }

        protected void btn_aceptarLogin_Click(object sender, EventArgs e)
        {
            users usuario;
            usuarioNegocio userNegocio = new usuarioNegocio();
            

            if (ControlTexBoxVacio())
            {
                return;
            }

            if (!isValidMail(txb_username.Text))
            {
                return;
            }

            try
            {
                usuario = new users(txb_username.Text, txb_pass.Text, false);

                if (userNegocio.Loguin(usuario))
                {
                    Session.Add("Usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    //cartel alerta indica error login
                    alertaErrorLogin = true;
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error",ex.ToString());
            }
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