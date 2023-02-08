using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public static class Encriptar
    {
        /// Encripta una cadena
        public static string Encriptando(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] OcultarString = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(OcultarString);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptando(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] MostrarString = System.Text.Encoding.UTF8.GetBytes(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(MostrarString);
            return result;
        }
    }//fin class encriptar
}
    //Creditos:Estos metodos se basaron en el aporte del Sr.Juan Iruela de la pag:
    //https://www.inesem.es/revistadigital/informatica-y-tics/seguridad-en-c-encriptar-y-desencriptar-datos/