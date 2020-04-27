using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Datos;
using Negocio;

namespace WebFormProductos
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public int IDProducto;
        ProductoManager cN_Producto = new ProductoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
            
        }

        //FUNCIONES 
        public void cargarGrid()
        {
            dgvProductos.DataSource = ProductoManager.MostrarProductos();
            dgvProductos.DataBind();
        }

        private void LimpiarCampos()
        {
            btnGuardar.Text = "Agregar";
            IDProducto = 0;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        public Producto obtenerProducto()
        {
            Producto producto = new Producto();
            IDProducto = Convert.ToInt32(Page.Session["IDProducto"]);
            try
            {
                producto.IDProducto = IDProducto;
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Precio = Convert.ToDouble(txtPrecio.Text);
                producto.Stock = Convert.ToInt32(txtStock.Text);
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return producto;
        }

        private void ActualizarControles()
        {
            btnGuardar.Text = "Guardar";
            IDProducto = Convert.ToInt32(dgvProductos.SelectedRow.Cells[1].Text);
            txtNombre.Text = dgvProductos.SelectedRow.Cells[2].Text;
            txtDescripcion.Text = dgvProductos.SelectedRow.Cells[3].Text;
            txtPrecio.Text = dgvProductos.SelectedRow.Cells[4].Text;
            txtStock.Text = dgvProductos.SelectedRow.Cells[5].Text;
            Page.Session["IDProducto"] = IDProducto;
        }

        private int ObtenerID()
        {
            Producto miProducto = new Producto();
            miProducto.IDProducto = Convert.ToInt32(Page.Session["IDProducto"]);
            return miProducto.IDProducto;
        }

        //BOTONES
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = obtenerProducto();
            cN_Producto.agregarProducto(producto);
            LimpiarCampos();
            cargarGrid();
            IDProducto = 0;
            txtNombre.Focus();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = ObtenerID();
            ProductoManager.EliminarProducto(idEliminar);
            cargarGrid();
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        //GRID VIEW ELEMENTS
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarControles();
        }

      




    }
}