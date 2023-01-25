using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public  String strUsuario = "";
        private  String strPassword = "";

     
        public  string usuario { get => strUsuario; set => strUsuario = value; }
        public  string pass { get => strPassword; set => strPassword = value; }

    }
}
