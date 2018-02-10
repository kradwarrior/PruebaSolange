using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;


namespace Logica       
{
   public class Usuarios : Conexion
   {
       private long id_usuario;
       private string nombre;
       private string apellido;
       private string email;
       private long telefono;
       private string direccion;
       private long salario;
    
       private string contraseña;
       private string usuario;
       private int tipodeusuario;


       public long Id_Usuario
       {
           get
           {
               return id_usuario;
           }

           set
           {
               id_usuario = value;
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
       public string Apellido
       {
           get
           {
               return apellido;
           }

           set
           {
               apellido = value;
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

       public string Contraseña
       {
           get
           {
               return contraseña;
           }
           set
           {

               contraseña = value;

           }
       }



public string Usuario
{
get
{
return usuario;
}
set
{
usuario = value;
}
}
public int TipoDeUsuario
{
    get
    {
        return tipodeusuario;
    }
    set
    {
        tipodeusuario = value;
    }
}


       public bool InsertUsuarios()
       {
           string cadenaSQLInsertar = "Insert into Usuarios(Id_Usuario,Nombre,Apellido,Email,Telefono,Direccion,Salario,Contraseña,Usuario,TipoDeUsuario)VALUES (" + this.id_usuario + ",'" + this.nombre + "','" + this.apellido + "','" + this.email + "','" + this.telefono + "','" + this.direccion + "','" + this.salario + "','"  + this.contraseña + "','" + this.usuario + "','" + this.tipodeusuario + "')";

           bool respuestaSQL = EjecutarSQL(cadenaSQLInsertar);
           return respuestaSQL;
       }
       public DataSet ConsultarUsuarios(string identificacionxconsultar)
       {
           string cadenaSQLConsultar = "SELECT * FROM Usuarios WHERE usuario COLLATE LATIN1_GENERAL_CS_AS = " + identificacionxconsultar + "";
           DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
           return ConsultaResultante;
       }
       public DataSet ConsultarTodosUsuarios()
       {
           string cadenaSQLConsultar = "SELECT * FROM Usuarios  ";
           DataSet ConsultaResultante = ConsultarSQL(cadenaSQLConsultar);
           return ConsultaResultante;
       }
       public bool ActualizarUsuarios()
       {
           string cadenaSQLActualizar = "UPDATE Usuarios SET Nombre = '" + this.nombre + "', Apellido  = '" + this.apellido + "', Direccion = '" + this.direccion + "', Telefono = '" + this.telefono + "', Email = '" + this.email + "', Salario = '" + this.salario + "',Contraseña = '" + this.contraseña + "',Usuario = '" + this.usuario + "',TipoDeUsuario = '" + this.tipodeusuario + "' WHERE (Id_Usuario= " + this.id_usuario + ")";
           bool respuestaSQL = EjecutarSQL(cadenaSQLActualizar);
           return respuestaSQL;
       }
       public bool EliminarUsuarios(string identidicacionxconsultar)
       {
           string cadenaSQLEliminar = "DELETE FROM Usuarios WHERE Id_Usuario = " + identidicacionxconsultar + "";
           bool respuestaSQL = EjecutarSQL(cadenaSQLEliminar);
           return respuestaSQL;
       }
}
}



