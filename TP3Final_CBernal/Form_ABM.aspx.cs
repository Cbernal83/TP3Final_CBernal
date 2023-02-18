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
    public partial class Vender : System.Web.UI.Page
    {
        public string urlImagen { get; set; }

        public bool confirmarEliminacion { get; set; }
        public List<articulos> ListaArticulos { get; set; }

        public bool alerta { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            categoriasNegocio categorias = new categoriasNegocio();
            marcasNegocio marcas = new marcasNegocio();

            alerta = false;

            confirmarEliminacion = false;

            try
            {
                if (!IsPostBack )
                {

                    ddl_categoria.DataSource = categorias.listar();
                    ddl_categoria.DataValueField = "id";
                    ddl_categoria.DataTextField = "Descripcion";
                    ddl_categoria.DataBind();

                    ddl_marca.DataSource = marcas.listar();
                    ddl_marca.DataValueField = "id";
                    ddl_marca.DataTextField = "Descripcion";
                    ddl_marca.DataBind();
                }

                //!IsPostBack para q no sobreescriba si se realiza modificaciones
                if (!IsPostBack && Request.QueryString["Id"]!=null)
                {

                    articulosNegocio art = new articulosNegocio();
                    
                    var id = int.Parse(Request.QueryString["Id"].ToString());
                                                           
                    ListaArticulos = art.listarStoredProcedure();
                    articulos seleccionado = ListaArticulos.Find(x => x.Id == id);
                                      

                    //txb_id.Text = seleccionado.Id.ToString();
                    txb_cod.Text = seleccionado.Codigo.ToString();
                    txb_nombre.Text = seleccionado.Nombre;
                    txb_precio.Text = seleccionado.Precio.ToString("N");
                    Img_ImagenABM.ImageUrl = seleccionado.ImagenUrl;
                    txb_urlimg.Text = seleccionado.ImagenUrl;
                    txb_descripcion.Text = seleccionado.Descripcion;
                   
                    ddl_marca.SelectedValue = seleccionado.Marca.Id.ToString();
                    
                    ddl_categoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    

                }

            }
            catch (Exception ex)
            {

                Session.Add("error",ex);
                throw;
            }
        }

        protected void txb_urlimg_TextChanged(object sender, EventArgs e)
        {
           Img_ImagenABM.ImageUrl = txb_urlimg.Text;
           
        }

        protected void btn_aceptarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlTexBoxVacio())
                {
                    return;
                }

                helper aux = new helper();

                if (!aux.isValidNumeros(txb_precio.Text))
                {
                    alerta = true;
                    lbl_Alerta.Text = "Campo Precio solo numeros";
                    return ;
                    
                }


                articulos Articulo = new articulos();
                articulosNegocio ABM = new articulosNegocio();

                Articulo.Marca = new marcas();
                Articulo.Marca.Id = int.Parse(ddl_marca.SelectedValue);

                Articulo.Categoria = new categorias();
                Articulo.Categoria.Id = int.Parse(ddl_categoria.SelectedValue);

                Articulo.Codigo = txb_cod.Text;
                Articulo.Nombre = txb_nombre.Text;
                Articulo.Precio = decimal.Parse(txb_precio.Text);
                Articulo.ImagenUrl = txb_urlimg.Text;
                Articulo.Descripcion = txb_descripcion.Text;


                if (Request.QueryString["Id"] != null)
                {
                    Articulo.Id = int.Parse (Request.QueryString["Id"]);
                    ABM.ModificacionArticuloSP(Articulo);
                }
                else
                {
                    ABM.AltaArticuloSP(Articulo);
                }

                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
   

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GrillaProductos.aspx", false);
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                articulosNegocio ABM = new articulosNegocio();
                articulos articulo = new articulos();

                articulo.Id = int.Parse((Request.QueryString["Id"]));

                ABM.EliminarArticuloSP(articulo);

                Response.Redirect("GrillaProductos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
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
    }
}