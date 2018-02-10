using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data;

namespace Logica 
{
 public class  Login :  Conexion 
    {
        private int tipodeusuario;
        private string usuario;
        private string nombre;

        public int TipoDeUsuario
        {
            get { return tipodeusuario; }
            set { tipodeusuario = value; }

        }

       public string Usuario 
       {
           get { return usuario;  }
           set { usuario= value;  }
       }

       public string Nombre
       { 
           get { return nombre ; } 
           set { nombre = value;  }
       }
        
       public DataSet ConsultarUsuario(string NombreUsuario)
       {
           string cadenaSQLConsultar = "Select* from Usuarios where Usuario COLLATE LATIN1_GENERAL_CS_AS = '" + NombreUsuario + "'";

           DataSet ConsultaResultante = ConsultarSQL (cadenaSQLConsultar);
           return ConsultaResultante;
       }

       public DataSet ConsultarTodosLosUsuarios() 
       {
           string cadenaSQLConsultar = "select * from Usuarios" ; 
           
           DataSet ConsultaResultante =  ConsultarSQL (cadenaSQLConsultar);
           return ConsultaResultante; 




                       
    }

       public void Show()
       {
           throw new NotImplementedException();
       }
    }
}

