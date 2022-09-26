using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TIC
{
    class Conexion
    {
        static SqlConnection cnx;
        static string cadena = "Server=localhost;Database=Militar;Trusted_Connection=True;";
        private static void Conectar()
        {
            cnx = new SqlConnection(cadena);
            cnx.Open();
        }
        private static void Desconectar()
        {
            cnx.Close();
            cnx = null;
        }
        public static int EjecutarConsulta(String consulta)
        {
            int filasAfectadas = 0;
            Conectar();
            SqlCommand cmd = new SqlCommand(consulta, cnx);
            filasAfectadas = cmd.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }
        public static DataTable AgregarElementoCombo(String consulta)
        {
            DataTable dt = new DataTable();
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            DataRow workrow = dt.NewRow();
            workrow[0] = 0;
            workrow[1] = "Todos";
            dt.Rows.InsertAt(workrow, 0);
            Desconectar();
            return dt;
        }
        public static DataTable EjecutaSeleccion(string consulta)
        {
            DataTable dt = new DataTable();
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt;
        }
        public static Object EjecutaEscalar(string consulta)
        {
            DataTable dt = new DataTable();
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt.Rows[0].ItemArray[0];
        }
    }
}
