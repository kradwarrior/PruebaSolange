using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;

namespace Logica
{
    public class ClaseFacturaServicios : Conexion
    {
        //campos de nuestra primera tabla en bbd factura :V 
        private int numfactura;
        private DateTime fecha;
        private long preciototal;
        private long idempleado;
        private long nitempresa;
        private long idcliente;
        //private long idserviciosprestados;

        // campos de los detalles de nuestra 2 factura los int se conservan 


        //Arreglar base de datos 


        //private long idproducto;
        private int cantidad;
        private long valoriva;
        private long subtotal;
        private long idservicios;




        public int Cantidad
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

        public int NumFactura
        {
            get
            {
                return numfactura;
            }
            set
            {
                numfactura = value;
            }
        }
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }
        public long PrecioTotal
        {
            get
            {
                return preciototal;
            }
            set
            {
                preciototal = value;
            }
        }
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


        
        public long ValorIva
        {
            get
            {
                return valoriva;
            }
            set
            {
                valoriva = value;
            }
        }
        public long SubTotal
        {
            get
            {
                return subtotal;
            }
            set
            {
                subtotal = value;
            }
        }
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
        public bool InsertarFacturaServicios()
        {
            string cadenaSQLInsertar =
             "INSERT INTO FacturaServicios (NumFactura, Fecha, Preciototal, IdEmpleado, NitEmpresa, IdCliente)VALUES ("
             + this.numfactura + ",'" + this.fecha.Date.ToShortDateString() + "'," + this.preciototal + "," + this.idempleado + "," + this.nitempresa + "," + this.idcliente + ")";

            bool respuestaSQL = EjecutarSQL(cadenaSQLInsertar);
            return respuestaSQL;
        }
        public bool InsertarDetalleFServicios()
        {
            string cadenaSQLInsertar =
             "INSERT INTO DetalleFacturaS (NumFactura, IdServicios,Cantidad,ValorIva,SubTotal)VALUES ("
             + this.numfactura + "," + this.idservicios + "," + this.cantidad + "," + this.valoriva + "," + this.subtotal + ")";

            bool respuestaSQL = EjecutarSQL(cadenaSQLInsertar);
            return respuestaSQL;
        }
        public DataSet ConsultarUltimaFServicios()
        {
            string cadenaSQLConsultar = "SELECT TOP(1) NumFactura FROM FacturaServicios Order By NumFactura Desc";

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public DataSet ConsultarFServicios(int NumFactura)
        {
            string cadenaSQLConsultar = "SELECT * FROM  Vista_FacturaServicios  Where NumFactura = " + NumFactura;

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public DataSet ConsultarDetalleFServicios(int NumFactura)
        {
            string cadenaSQLConsultar = "SELECT IdServicios,Cantidad ,ValorIva ,Subtotal FROM Vista_DetalleFServicios Where NumFactura = " + NumFactura;

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }
        public DataSet ConsultarValorTotalS(int NumFactura)
        {
            string cadenaSQLConsultar = "SELECT SUM(SubTotal) AS TotalFactura FROM DetalleFacturaS where NumFactura = " + NumFactura;

            DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
            return ConsultaResultante;
        }

        
    }
}
