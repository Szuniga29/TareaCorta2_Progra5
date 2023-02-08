using Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Negocios
{
    public class Procesos
    {
        public String strUsuario = "";
        private String strPassword = "";


        public string usuario { get => strUsuario; set => strUsuario = value; }
        public string pass { get => strPassword; set => strPassword = value; }




        Datos_SQLServer objDatos =new Datos_SQLServer();

        public DataTable Login(Usuario objUsuario)
        { 

        return objDatos.login(objUsuario);
            
        }

       public void insertar()
        {
             objDatos.InsertarUsuario(usuario,pass);
        }

    }
}
