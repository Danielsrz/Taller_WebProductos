using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConexionBD
    {
        string conexion = "Data Source=DESKTOP-QN49N6K\\DANIELDB;Initial Catalog=Taller;Integrated Security=true;";
        public SqlConnection sqlConexion = new SqlConnection();

        public ConexionBD()
        {
            sqlConexion.ConnectionString = conexion;
            sqlConexion.Open();
        }

        public void cerrarConexion()
        {
            sqlConexion.Close();
        }
    }
}
