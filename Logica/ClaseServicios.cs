using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;


namespace Logica
{
    public class ClaseServicios : Conexion
    {
        private long idservicios;
        private string nombre;
        private string tipodeservicio;
        private string cantidad;
        private long precioservicio;


        public long IdServicios
        {

            get
            {
                return idservicios;
            }
            set
            {
                idservicios = value;
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        public string TipoDeServicio
        {
            get
            {
                return tipodeservicio;
            }
            set
            {
                tipodeservicio = value;
            }
        }

        public string Cantidad
        {
            get
            {
                return cantidad;

            }
            set
            {
                cantidad = value;
            }
        }


        public long PrecioServicio
        {
            get
            {
                return precioservicio;
            }
            set
            {
                precioservicio = value;
            }
        }
        public bool InsertServicio()
        {
            string cadenaSQLInsertar = "  INSERT INTO Servicios (IdServicios, Nombre, TipoDeServicio, Cantidad, PrecioServicio)VALUES (" + this.idservicios + ",'" + this.nombre + "','" + this.tipodeservicio + "','" + this.cantidad + "','" + this.precioservicio + "')";

            bool respuestaSQL = EjecutarSQL(cadenaSQLInsertar);
            return respuestaSQL;
        }
        public DataSet ConsultarServicios(string IdServiciosxconsultar)
        {
            string cadenaSQLConsultar = "SELECT * FROM Servicios WHERE IdServicios = " + IdServiciosxconsultar + "";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public DataSet ConsultarTodosServicios()
        {
            string cadenaSQLConsultar = "SELECT * FROM Servicios";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public bool ActualizarServicios()
        {
            string cadenaSQLActualizar = "UPDATE Servicios SET Nombre = '" + this.nombre + "', TipoDeServicio = '" + this.tipodeservicio + "', Cantidad  = '" + this.cantidad + "',PrecioServicio = '" + this.precioservicio + "' WHERE (IdServicios= " + this.idservicios + ")";
            bool respuestaSQL = EjecutarSQL(cadenaSQLActualizar);
            return respuestaSQL;
        }
        public bool EliminarServicios(string IdServiciosxconsultar)
        {
            string cadenaSQLEliminar = "DELETE FROM Servicios WHERE IdServicios = " + IdServiciosxconsultar + "";
            bool respuestaSQL = EjecutarSQL(cadenaSQLEliminar);
            return respuestaSQL;
        }



    }
}




