using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class conexion
    {
        static SqlConnection cnx;
        static string cadena = @"Server=LAPTOP-OQA2NHJ1\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;";

        public static void Conectar()
        {
            cnx = new SqlConnection(cadena);
            cnx.Open();
        }
        public static void Desconectar()
        {
            cnx.Close();
            cnx = null;
        }
        public static int EjecutaConsulta(string consulta)
        {
            int filasAfectadas = 0;
            Conectar();
            SqlCommand cmd = new SqlCommand(consulta, cnx);
            filasAfectadas = cmd.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
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
