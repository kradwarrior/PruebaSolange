using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;

namespace Logica
{
    public class ClaseConsultas : Conexion
    {
    
        public DataSet ConsultarListadoCliente()
        {
            string cadenaSQLConsultar = "SELECT IdCliente, Nombre + ' ' + Apellidos As NombreCompleto FROM Cliente";

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public DataSet ConsultarListadoServicios()
        {
            string cadenaSQLConsultar = "SELECT IdServicios , Nombre From Servicios";

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }


        public DataSet ConsultarServicios(long IdServicios)
        {
            string cadenaSQLConsultar = "Select * FROM Servicios where IdServicios = " + IdServicios;

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;

        }
        public DataSet ConsultarTodosServicios()
        {
            string cadenaSQLConsultar = "SELECT * FROM Servicios";

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }


        public DataSet ConsultarListadoproductos()
        {
            string cadenaSQLConsultar = "SELECT IdProducto, Nombre FROM productos";

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }

        public DataSet ConsultarProducto(long IdProducto)
        {
            string cadenaSQLConsultar = "SELECT * FROM Productos where IdProducto = " + IdProducto;

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }

        public DataSet ConsultarTodosProductos()
        {
            string cadenaSQLConsultar = "SELECT * FROM Productos";

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }

        public DataSet ConsultarListadoEmpleado()
        {
            string cadenaSQLConsultar = "SELECT IdEmpleado, Nombre + ' ' + Apellidos As NombreCompleto FROM Empleado";

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }

        public DataSet ConsultarTodosEmpleado()
        {
            string cadenaSQLConsultar = "SELECT * FROM Empleado";

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;



        }
        public DataSet ConsultarEmpresa()
        {

            string cadenaSQLConsultar = "Select  NitEmpresa,Nombre , Direccion From Empresa";

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;

        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}

