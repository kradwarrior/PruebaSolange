using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data;



namespace Logica
{
   public  class LoginPropietaria :  Conexion 
    { 
       private int tipousuario;
        private string usuario;
        private string nombres;

        public int Tipousuario

            {
            get { return tipousuario;  }
            set { tipousuario = value;  }

            }

       public string Usuario 
       {
           get { return usuario;  }
           set { usuario= value;  }
       }

       public string Nombres 
       { 
           get { return nombres ; } 
           set { nombres = value;  }
       }
        
       public DataSet ConsultarUsuario(string NombreUsuario)
       {
           string cadenaSQLConsultar = "Select* from Usuarios where Usuario = '" + NombreUsuario + "'";

           DataSet ConsultaResultante = ConsultarSQL (cadenaSQLConsultar);
           return ConsultaResultante;
       }

       public DataSet ConsultarTodosLosUsuarios() 
       {
           string cadenaSQLConsultar = "select * from Usuarios" ; 
           
           DataSet ConsultaResultante =  ConsultarSQL (cadenaSQLConsultar);
           return ConsultaResultante; 
    }

       
       
       }
}

