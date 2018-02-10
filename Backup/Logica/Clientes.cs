using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;



namespace Logica
{
    public class Clientes : Conexion
    {
        private long idcliente;
        private string nombre;
        private string apellidos;
        private string direccion;
        private long telefono;
        private string email;

        public long IdCliente
        {
            get
            {
                return idcliente;
            }
            set
            {
                idcliente = value;
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

             public DataSet ConsultarTodosClientes()
             {
                 string cadenaSQLConsultar = "SELECT * FROM Cliente";
                 DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
                 return ConsultaResultante;
             }
   

        public bool InsertarCliente()
        {
            string ProcedimientoInsertar =
            "EXEC AddCliente @IdCliente = " + this.idcliente + ",@Nombre = '" + this.nombre + "', @Apellidos = '" + this.apellidos + "', @Direccion = '" + this.direccion + "', @Telefono = " + this.telefono + ", @Email = '" + this.email + "'";
            bool respuestaSQL = EjecutarSQL(ProcedimientoInsertar);
            return respuestaSQL;
        }

        public DataSet ConsultarCliente(string idcliente)
        {
            string ProcedimientoDeConsulta =
            "EXEC ConsultarClientexidentificacion @IdCliente = " + idcliente + "";
            DataSet ConsultaResultante = ConsultarSQL(ProcedimientoDeConsulta);
            return ConsultaResultante;
        }


        public bool  ActualizarCliente()
        {
            string ProcedimientoActualizar = 
                "EXEC ActualizarCliente  @Nombre = '" + this.nombre + "', @Apellidos = '" + this.apellidos + "', @Direccion = '" + this.direccion + "', @Telefono = '" + this.telefono + "', @Email = '" + this.email + "', @IdCliente = " + this.idcliente + "";
            bool respuestaSQL = EjecutarSQL(ProcedimientoActualizar);
            return respuestaSQL;
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                  
       public bool ElminarCliente(string idcliente)
       {
           string ProcedimientoEliminar =
               "EXEC EliminarCliente @IdCliente ='" + this.idcliente + "";
           bool respuestaSQL = EjecutarSQL(ProcedimientoEliminar);
           return respuestaSQL;
       }



        }



        }
    



    





