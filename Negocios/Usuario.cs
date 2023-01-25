using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        private static String strUsuario = "";
        private static String strPassword = "";
     
        public static string usuario { get => strUsuario; set => strUsuario = value; }
        public static string password { get => strPassword; set => strPassword = value; }
    }
}
