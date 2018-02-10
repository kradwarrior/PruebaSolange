using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos; 


namespace Logica
{
    public class ClaseEmpresa : Conexion 
    {


         private long nitempresa;
        private string nombre;
        private string direccion;
        private long telefono;
        private string email;
        private string paginaweb;

        public long NitEmpresa
        {
            get
            {
                return nitempresa;
            }
            set
            {
                nitempresa = value;

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
        public string PaginaWeb
        {
            get
            {
                return paginaweb;
            }
            set
            {
                paginaweb = value;
            }
        }
        public bool InsertEmpresas()
        {
            string cadenaSQLInsertar = "  INSERT INTO Empresa (NitEmpresa, Nombre,  Direccion, Telefono, Email, PaginaWeb)VALUES (" + this.nitempresa + ",'" + this.nombre + "','" + this.direccion + "','" + this.telefono + "','" + this.email + this.paginaweb +  "')";

            bool respuestaSQL = EjecutarSQL(cadenaSQLInsertar);
            return respuestaSQL;
        }
        public DataSet ConsultarEmpresas(string IdNitEmpresaxconsultar)
        {
            string cadenaSQLConsultar = "SELECT * FROM Empresa WHERE NitEmpresa = " + IdNitEmpresaxconsultar + "";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public DataSet ConsultarTodosEmpresas()
        {
            string cadenaSQLConsultar = "SELECT * FROM  Empresa";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public bool ActualizarEmpresas()
        {
            string cadenaSQLActualizar = "UPDATE Empresa SET Nombre = '" + this.nombre + "',  direccion = '" + this.direccion + "', telefono = '" + this.telefono + "', email = '" + this.email + "', PaginaWeb = '" + this.paginaweb + "' WHERE (NitEmpresa= " + this.nitempresa + ")";
            bool respuestaSQL = EjecutarSQL(cadenaSQLActualizar);
            return respuestaSQL;
        }
        public bool EliminarClientes(string IdNitEmpresaxconsultar)
        {
            string cadenaSQLEliminar = "DELETE FROM Empresa WHERE NitEmpresa = " + IdNitEmpresaxconsultar + "";
            bool respuestaSQL = EjecutarSQL(cadenaSQLEliminar);
            return respuestaSQL;
        }






        public static string Equals()
        {
            throw new NotImplementedException();
        }
    }
}
