using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;

namespace Logica
{
    public class Proveedor : Conexion 
    {
        private long idenficacionPro;
        private string nombre;
        private string direccion;
        private long telefono;
        private string email;
        private string tipodeproveedor;

        public long IdentificacionPro
        {
            get
            {
                return idenficacionPro;
            }
            set
            {
                idenficacionPro = value;
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
        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }
        public long Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string TipoDeProveedor
        {
            get
            {
                return tipodeproveedor;
            }
            set
            {
                tipodeproveedor = value;
            }
        }
        public bool InsertProveedor()
        {
            string cadenaSQLInsertar = "INSERT INTO Proveedor (identificacionpro, Nombre, Direccion, Telefono, Email, TipoDeProveedor)VALUES (" + this.idenficacionPro + ",'" + this.nombre + "','" + this.direccion + "','" + this.telefono + "','" + this.email + "','" + this.tipodeproveedor + "')";


            bool respuestaSQL = EjecutarSQL(cadenaSQLInsertar);
            return respuestaSQL;
        }
        public DataSet ConsultarProveedor(string identificacionxconsultar)
        {
            string cadenaSQLConsultar = "SELECT * FROM Proveedor WHERE identificacionPro = " + identificacionxconsultar + "";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante; 
        }
        public DataSet ConsultarTodosProveedores()
        {
            string cadenaSQLConsultar = "SELECT * FROM Proveedor";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public bool ActualizarProveedor()
        {
            string cadenaSQLActualizar = "UPDATE Proveedor SET Nombre = '" + this.nombre + "', Direccion = '" + this.direccion + "', Email = '" + this.email + "', TipoDeProveedor = '" + this.tipodeproveedor + "' WHERE (identificacionPro= " + this.idenficacionPro + ")";
            bool respuestaSQL = EjecutarSQL(cadenaSQLActualizar);
            return respuestaSQL;
        }
        public bool EliminarProveedor(string identidicacionxconsultar)
        {
            string cadenaSQLEliminar = "DELETE FROM Proveedor WHERE IdentificacionPro = " + identidicacionxconsultar + "";
            bool respuestaSQL = EjecutarSQL(cadenaSQLEliminar);
            return respuestaSQL;
        }
    }
}
