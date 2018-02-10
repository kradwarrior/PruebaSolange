using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class Conexion
    {
        private string mensaje;
        private SqlConnection conn;

        public string Mensaje
        {
            get
            {
                return mensaje;
            }
            set
            {
                mensaje = value;
            }
        }
        public Conexion ()
        {
            String cadenaconexion = @"Data Source =EQUIPO\SQLEXPRESS;Initial Catalog = BDDEmpresaEnkanta;Integrated Security=True";
                conn = new SqlConnection (cadenaconexion);
        }
        public DataSet ConsultarSQL(String SentenciaSQL)
        {
            try
            {
                conn.Open();
                SqlDataAdapter objRes = new SqlDataAdapter (SentenciaSQL, conn);
                DataSet datos = new DataSet ();
                objRes.Fill(datos, "DatosConsultados");
                mensaje = "La Consulta De Datos Fue Exitosa";
                return datos;
            }
            catch (Exception MiExc)
            {
                DataSet sindatos = new DataSet ();
                mensaje = "ERROR: " + MiExc.Message;
                return sindatos;
            }

                finally 
            {
                conn.Close();
            }
        }
        public bool EjecutarSQL(String SentenciaSQL)
        {
            try
            {
                conn.Open();
                SqlCommand miComando = new SqlCommand();
                miComando.Connection = conn;
                miComando.CommandText = SentenciaSQL;
                miComando.ExecuteNonQuery();

                mensaje = "Proceso Ejecutado Con Exito";
                return true;
            }
            catch (Exception e)
            {
                mensaje = "Se Presento El Siguiente Error " + e.Message;
                return false;
            }
            finally 
            {
                conn.Close();
            }
        }
    }
}
