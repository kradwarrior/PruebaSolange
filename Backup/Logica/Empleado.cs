using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos; 

namespace Logica
{
    public class Empleado : Conexion 

    {
        private long idempleado;
        private string nombre;
        private string apellidos;
        private string direccion;
        private long telefono;
        private string email;
        private string cargo;
        private long salario;


        public long IdEmpleado
    { 
            get 
                {
                return idempleado;
            }

            set 
            {
                idempleado = value;
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
             public string Apellidos
             {
                 get
                 {
                     return apellidos;
                 }

                 set
                 {
                     apellidos = value;
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
         
        public string Cargo
        {
            get 
            {
                return cargo;
                 }
            set 
            {
                cargo = value;
                 }
        }
        public long Salario
        {
            get
            {
                return salario;
            }
            set
            {
                salario = value;
            }
        }
        
        public bool InsertEmpleado() 
        { 
            string cadenaSQLInsertar = "INSERT INTO Empleado (IdEmpleado, Nombre, Apellidos, Direccion, Telefono, Email, Salario)VALUES (" +  this.idempleado + ",'" +  this.nombre + "','" + this.apellidos + "','" + this.direccion + "','" + this.telefono +  "','" + this.email + "','"  + this.salario + "')";
            
            bool respuestaSQL = EjecutarSQL(cadenaSQLInsertar);
            return respuestaSQL;
        }
        public DataSet ConsultarEmpleado(string identificacionxconsultar)
        {
            string cadenaSQLConsultar = "SELECT * FROM Empleado WHERE IdEmpleado = " + identificacionxconsultar + "";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public DataSet ConsultarTodosEmpleado()
        {
            string cadenaSQLConsultar = "SELECT * FROM Empleado";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public bool ActualizarEmpleado()
        {
            string cadenaSQLActualizar = "UPDATE Empleado SET Nombre = '" + this.nombre +  "', Apellidos  = '" + this.apellidos + "', Direccion = '" + this.direccion + "', Telefono = '" + this.telefono + "', Email = '" + this.email + "', Cargo = '" + this.cargo +  "', Salario = '" +  this.salario + "' WHERE (IdEmpleado= " + this.idempleado + ")";
            bool respuestaSQL = EjecutarSQL(cadenaSQLActualizar);
            return respuestaSQL;
        }
        public bool EliminarEmpleado(string identidicacionxconsultar)
        {
            string cadenaSQLEliminar = "DELETE FROM Empleado WHERE IdEmpleado = " + identidicacionxconsultar + "";
            bool respuestaSQL = EjecutarSQL(cadenaSQLEliminar);
            return respuestaSQL;
        }
 
    }
}
