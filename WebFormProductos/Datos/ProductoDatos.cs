﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Datos
{
    public class ProductoDatos
    {
        ConexionBD conexion = new ConexionBD();
        DataTable tabla = new DataTable();

        //Consulata a la BD todos los registros
        public DataTable Mostra()
        {
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "GetProductos";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();
            return tabla;
        }

        //Consuta a la BD para insertar un Producto
        public void insertarProducto(Producto producto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "InsertProductos";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Descripción", producto.Descripcion);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            cmd.Parameters.AddWithValue("@Stock", producto.Stock);
            cmd.ExecuteNonQuery();
            conexion.cerrarConexion();
        }

        //Consulta a la BD para editar
        public void Edit(Producto producto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "UpdateProductos";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", producto.IDProducto);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Descripción", producto.Descripcion);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            cmd.Parameters.AddWithValue("@Stock", producto.Stock);
            cmd.ExecuteNonQuery();
            conexion.cerrarConexion();
        }

        //Consulta a la BD para eliminar Producto
        public void Eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "DeleteProductos";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conexion.cerrarConexion();
        }

        //Consulta a la BD para buscar Producto
        public void BuscarProducto(DataGridView data, string nombre)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "BuscarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = nombre;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            data.DataSource = tabla;
        }
    }
}
