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
        Datos_SQLServer objDatos =new Datos_SQLServer();

        public DataTable Login(Usuario objUsuario)
        { 
        return objDatos.login(objUsuario);
        }

    }
}
