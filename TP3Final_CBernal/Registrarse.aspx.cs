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
    public partial class Registrarse : System.Web.UI.Page
    {
        public bool alerta { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            alerta = false;
               
        }

        protected void btn_aceptarReg_Click(object sender, EventArgs e)
        {
            usuarioNegocio alta = new usuarioNegocio();
            users nuevo = new users();


            if (ControlTexBoxVacio())
            {
                return;
            }

            if (!isValidMail(txb_mail.Text))
            {
                return;
            }

            helper aux = new helper();

            if (!aux.isValidLetras(txb_nombre.Text))
            {
                lbl_Alerta.Text = string.Empty;
                alerta = true;
                lbl_Alerta.Text = "Nombre y Apellido solo admite letras";
                return;
            }

            if (!aux.isValidLetras(txb_apellido.Text))
            {
                lbl_Alerta.Text = string.Empty;
                alerta = true;
                lbl_Alerta.Text = "Nombre y Apellido solo admite letras";
                return;
            }

            if (!aux.isValidPass(txb_pass.Text))
            {
                lbl_Alerta.Text = string.Empty;
                alerta = true;
                lbl_Alerta.Text = "Clave debe contener 4-8 caracteres, minuscula, mayuscula, numero";
                return;
            }
           

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                
                nuevo.Nombre = txb_nombre.Text;

                nuevo.Apellido = txb_apellido.Text;

            
                //Verifico que el Mail no exista en la DB
                if (!(alta.VerificacionMail(txb_mail.Text)))
                {
                    nuevo.Email = txb_mail.Text;


                    // Verifico con el Metodo que Coincide el Pass con la Confirmacion de Pass
                    if (ConfirmacionMail(txb_pass.Text, txb_passConf.Text))
                    {

                        
                        nuevo.Pass = txb_pass.Text;

                        //En esta Linea, enviamos el Alta del nuevo y capturamos el ID
                        //con Scalar
                        nuevo.Id = alta.AltaUsuarioRegistro(nuevo);

                        //Autologin una vez generado el nuevo registro de Usuario.
                        //Lo agrego a la Session y ya nos queda logueado
                        Session.Add("Usuario", nuevo);

                        Response.Redirect("Default.aspx", false);                                             

                    }
                    else
                    {
                        alerta = true;
                        lbl_Alerta.Text = "No Coincide el pass";
                        //lbl_nomatch.Text = "*No Coincide el pass";
                    
                    }
                }
                else
                {
                    alerta = true;
                    lbl_Alerta.Text = "El Mail ya fue registrado,usar otro";
                    //lbl_mailregistrado.Text = "*El Mail ya fue registrado,usar otro";
                
                }

            }
            catch (Exception ex)
            {

                Session.Add("error",ex.ToString());
            }

            
        }

        // Metodo para comparar que sean iguales 2 cadenas de string.
        // Uso para validar el Pass
        private static bool ConfirmacionMail(string p1,string p2)
        {
            if (Regex.IsMatch(p1,p2) )
            {
                return true;
            }

            return false;
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