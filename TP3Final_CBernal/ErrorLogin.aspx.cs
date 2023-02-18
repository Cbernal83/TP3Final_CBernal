using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3Final_CBernal
{
    public partial class ErrorLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"]!=null)
            {
                lbl_ErrorAcceso.Text = Session["error"].ToString();
            }
        }
    }
}