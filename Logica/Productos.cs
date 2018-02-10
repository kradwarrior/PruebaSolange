using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;

namespace Logica
{
    public class Productos : Conexion
    {
        private long idproducto;
        private string nombre;
        private long cantidad;
        private string descripcion;
        private long precioventa;
        private long preciocompra;
        private string fechadeentrada;
        private long identificacionpro;
        

        public long IdProducto
        {
            get
            {
                return idproducto;
            }
            set
            {
                idproducto = value;
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
        public long Cantidad
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
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }
        public long PrecioVenta
        {
            get
            {
                return precioventa;
            }
            set
            {
                precioventa = value;
            }
        }
        public long PrecioCompra
        {
            get
            {
                return preciocompra;
            }
            set
            {
                preciocompra = value;
            }
        }
        public string FechaDeEntrada
        {
            get
            {
                return fechadeentrada;
            }
            set
            {
                fechadeentrada = value;
            }
        }
        public long IdentificacionPro
        {
            get
            {
                return identificacionpro;
            }
            set
            {
                identificacionpro = value;
            }
        }
       
        public bool InsertProductos()
        {
            string cadenaSQLInsertar = "INSERT INTO Productos (IdProducto, Nombre, Cantidad, Descripcion, PrecioVenta, PrecioCompra, FechaDeEntrada, IdentificacionPro)VALUES (" + this.idproducto + ",'" + this.nombre + "','" + this.cantidad + "','" + this.descripcion + "','" + this.precioventa + "','" + this.preciocompra + "','" + this.fechadeentrada + "','" + this.identificacionpro +"')";

            bool respuestaSQL = EjecutarSQL(cadenaSQLInsertar);
            return respuestaSQL;
        }
        public DataSet ConsultarProductos(string idproductoxconsultar)
        {
            string cadenaSQLConsultar = "SELECT * FROM Productos WHERE IdProducto = " + idproductoxconsultar + "";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante; 
        }
        public DataSet ConsultarTodosProductos()
        {
            string cadenaSQLConsultar = "SELECT * FROM Productos";
            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public bool ActualizarProductos()
        {
            string cadenaSQLActualizar = "UPDATE Productos SET Nombre = '" + this.nombre + "', Cantidad = '" + this.cantidad + "', Descripcion = '" + this.descripcion + "', PrecioVenta = '" + this.precioventa + "', PrecioCompra = '" + this.preciocompra + "', FechaDeEntrada = '" + this.fechadeentrada + "',IdentificacionPro = '" + this.IdentificacionPro +  "' WHERE (IdProducto= " + this.idproducto + ")";
            bool respuestaSQL = EjecutarSQL(cadenaSQLActualizar);
            return respuestaSQL;
        }
        public bool EliminarProductos(string idproductoxconsultar)
        {
            string cadenaSQLEliminar = "DELETE FROM Productos WHERE IdProducto = " + idproductoxconsultar + "";
            bool respuestaSQL = EjecutarSQL(cadenaSQLEliminar);
            return respuestaSQL;
        }
    }
}
