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
    public partial class GrillaProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(Seguridad.esAdmin(Session["Usuario"])))
            {

                Session.Add("error", "Se requiere permisos del Administrador");
                Response.Redirect("ErrorLogin.aspx", false);
            }
                
            articulosNegocio negocio = new articulosNegocio();
            Session.Add("GrillaProductos", negocio.listarStoredProcedure());

            if (!IsPostBack)
            {

                dgv_Articulos.DataSource = Session["GrillaProductos"];
                dgv_Articulos.DataBind();

            }
          

        }

        protected void dgv_Articulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgv_Articulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Form_ABM.aspx?Id=" + id);
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Form_ABM.aspx");
        }

        protected void txb_buscar_TextChanged(object sender, EventArgs e)
        {
           
            List<articulos> ListaArt = (List < articulos >) Session["GrillaProductos"];

            List<articulos> ListaFiltrada = ListaArt.FindAll(x => x.Nombre.ToUpper().Contains(txb_buscar.Text.ToUpper()));

            dgv_Articulos.DataSource = ListaFiltrada;
            dgv_Articulos.DataBind();

        }
             
        protected void btn_busava_Click(object sender, EventArgs e)
        {
            if (txb_buscar.ReadOnly == false )
            {
                txb_buscar.ReadOnly = true;
                btn_busava.Text = "Normal";

              
                    categoriasNegocio categoria = new categoriasNegocio();
                    ddl_categoria.DataSource = categoria.listar();
                    ddl_categoria.DataValueField = "Id";
                    ddl_categoria.DataTextField = "Descripcion";
                    ddl_categoria.DataBind();

                    marcasNegocio marca = new marcasNegocio();
                    ddl_marca.DataSource = marca.listar();
                    ddl_marca.DataValueField = "Id";
                    ddl_marca.DataTextField = "Descripcion";
                    ddl_marca.DataBind();

            }
            else
            {
                txb_buscar.ReadOnly = false;
                btn_busava.Text = "Avanzada";
            }
        }

        protected void btn_avanzado_Click(object sender, EventArgs e)
        {
            articulos buscar = new articulos();
            articulosNegocio BA = new articulosNegocio();
            try
            {
                buscar.Categoria = new categorias();
                buscar.Categoria.Id = int.Parse(ddl_categoria.SelectedValue);

                buscar.Marca = new marcas();
                buscar.Marca.Id = int.Parse(ddl_marca.SelectedValue);
                buscar.Nombre = txb_busavazNombre.Text;
                                

                dgv_Articulos.DataSource = BA.ListarBusquedaAvanzada(buscar);
               
                dgv_Articulos.DataBind();

                

            }
            catch (Exception EX)
            {

                Session.Add("Error",EX.ToString());
            }
        }


        protected void dgv_Articulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Paginar si el DataSource viene con o sin Orden, sino desaparece la tabla 
            if (ddl_orden.SelectedIndex != 0)
            {

                dgv_Articulos.DataSource = Session["GrillaFiltradaPrecio"];
                dgv_Articulos.PageIndex = e.NewPageIndex;
                dgv_Articulos.DataBind();
            }
            else
            {
                dgv_Articulos.DataSource = Session["GrillaProductos"];
                dgv_Articulos.PageIndex = e.NewPageIndex;
                dgv_Articulos.DataBind();

            }

                
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
            articulos buscar = new articulos();
            articulosNegocio BA = new articulosNegocio();

            
                //Cargar DDL cuando se activa Filtro Avanzado
                if(txb_buscar.ReadOnly)
                {
                    buscar.Categoria = new categorias();
                    buscar.Categoria.Id = int.Parse(ddl_categoria.SelectedValue);

                    buscar.Marca = new marcas();
                    buscar.Marca.Id = int.Parse(ddl_marca.SelectedValue);
                    buscar.Nombre = txb_busavazNombre.Text;

                }

                //Ordena por Precio sin Filtro Avanzado Activo

                if (ddl_orden.SelectedIndex != 0 && txb_buscar.ReadOnly == false)
                {
                    buscar.Orden = int.Parse( ddl_orden.SelectedValue);

                    Session.Add("GrillaFiltradaPrecio",BA.listarStoredProcedureOrden(buscar));
                
                    dgv_Articulos.DataSource = Session["GrillaFiltradaPrecio"];
               
                    dgv_Articulos.DataBind();
                }

                //Ordena por Precio con Filtro Avanzado activo

                if (ddl_orden.SelectedIndex != 0 &&  txb_buscar.ReadOnly)
                {
                    buscar.Categoria = new categorias();
                    buscar.Categoria.Id = int.Parse(ddl_categoria.SelectedValue);

                    buscar.Marca = new marcas();
                    buscar.Marca.Id = int.Parse(ddl_marca.SelectedValue);
                    buscar.Nombre = txb_busavazNombre.Text;
                    buscar.Orden = int.Parse(ddl_orden.SelectedValue);

                    Session.Add("GrillaFiltradaPrecio", BA.listarStoredProcedureOrden(buscar));

                    dgv_Articulos.DataSource = Session["GrillaFiltradaPrecio"];

                    dgv_Articulos.DataBind();
                }

        }
    }
}