using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Dominio;

namespace Negocio
{
    public class ProductoManager
    {
        public static DataTable MostrarProductos()
        {
            ProductoDatos miProducto = new ProductoDatos();
            DataTable tabla = new DataTable();
            tabla = miProducto.Mostra();
            return tabla;
        }

        public void agregarProducto(Producto producto)
        {
            if (!ValidarFormulario(producto))
            {
                MessageBox.Show("Debe completar todos los datos del formulario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (producto.IDProducto == 0)
            {
                ProductoDatos miProducto = new ProductoDatos();
                miProducto.insertarProducto(producto);
                MessageBox.Show("Se agrego el producto " + producto.Nombre + " con exito", "Aviso");
            }
            else
            {
                EditarProducto(producto);
            }
        }

        public static void EditarProducto(Producto producto)
        {
            ProductoDatos miProducto = new ProductoDatos();
            miProducto.Edit(producto);
            MessageBox.Show("Se edito el producto " + producto.Nombre + " con exito", "Aviso");
        }

        public static void EliminarProducto(int id)
        {
            if (id == 0)
            {
                MessageBox.Show("No hay elemento seleccionado para eleminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Estas seguro de eliminar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProductoDatos cD_Producto = new ProductoDatos();
                cD_Producto.Eliminar(id);
            }
        }

        public static void BuscarProducto(DataGridView data, string nombre)
        {
            ProductoDatos cD_Producto = new ProductoDatos();
            cD_Producto.BuscarProducto(data, nombre);
        }

        //Metodo para validar el formulario
        public bool ValidarFormulario(Producto producto)
        {
            bool valido = true;
            if (producto.Nombre == "" || producto.Descripcion == "" || producto.Precio == 0 || producto.Stock == 0)
            {
                valido = false;
            }
            else
            {
                valido = true;
            }
            return valido;
        }
    }
}
