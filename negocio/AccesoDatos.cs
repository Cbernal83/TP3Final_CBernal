using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class AccesoDatos
    {
        //Porpiedades

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        //Creacion de Constructor
        //Cuando nace el Objeto ya va a tener la conexion al DB
        //y el objeto comando.
        public AccesoDatos ()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS01;" +
                " database=CATALOGO_WEB_DB; Integrated Security=true");
            comando = new SqlCommand();
        }

        //CONSULTA EMBEBIDA
        public void setearCosulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //CONSULTA STORED PROCEDURE
        public void setearConsultaSP(string consulta)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = consulta;
        }


        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public void setearParametros(string parametro,object valor)
        {
            comando.Parameters.AddWithValue(parametro,valor);
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
