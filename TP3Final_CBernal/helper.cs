using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace negocio
{
    public class helper
    {
        //public bool ControlTexBoxVacio()
        //{
        //    foreach (Control item in Page.Form.FindControl("ContentPlaceHolder1").Controls)
        //    {
        //        if (item is TextBox)

        //        {
        //            if (((TextBox)item).Text == string.Empty)
        //            {
                      
        //                return true;

        //            }
        //        }
        //    }
        //    return false;
        //}

        public bool isValidMail(string emails)
        {
            string exMail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(exMail);
            if (re.IsMatch(emails))
            {

                return true;
            }

            else
            {
                return false;

            }
        }

        public bool isValidLetras(string nombre)
        {
            string exLetras = @"^[a-zA-Z]+$";
            Regex re = new Regex(exLetras);
            if (re.IsMatch(nombre))
            {

                return true;
            }

            else
            {
                return false;

            }
        }

        public bool isValidNumeros(string numero)
        {
            string ex = @"^[0-9]+$";
            Regex re = new Regex(ex);
            if (re.IsMatch(numero))
            {

                return true;
            }

            else
            {
                return false;

            }
        }

        public bool isValidPass(string pass)
        {
            /*Mínimo 4 caracteres a 8, al menos una letra mayúscula, una minúscula y un número*/
            string ex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{4,8}$";
            Regex re = new Regex(ex);
            if (re.IsMatch(pass))
            {

                return true;
            }

            else
            {
                return false;

            }
        }
    }
}
