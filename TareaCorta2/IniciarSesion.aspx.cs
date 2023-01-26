using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TareaCorta2
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        Procesos objProcesos= new Procesos();
        Usuario objusuario= new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            login();
            
        }

        void login()
        {

          DataTable dt = new DataTable();
            objusuario.usuario = TxtUsusario.Text;
            objusuario.pass = Txtcontrasena.Text;

            dt= objProcesos.Login(objusuario);

            if (dt.Rows.Count > 0 )
            {

                if (AlgoritmoContraseñaSegura(Txtcontrasena.Text))
                {
                    Txtcontrasena.Enabled = true;
                Response.Redirect("Bienvenido.aspx");

                }
                else
                    {
                        Txtcontrasena.Enabled = false;

                    lblError0.Text = "Usuario o Contraseña Incorrecta";
                }



            } else
            {
                lblError0.Text = "Usuario o Contraseña Incorrecta";


            }
        }


        private bool AlgoritmoContraseñaSegura(string password)
        {
           bool mayuscula = false, minuscula = false, numero = false, carespecial = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password, i))
                {
                    mayuscula = true;
                }
                else if (Char.IsLower(password, i))
                {
                    minuscula = true;
                }
                else if (Char.IsDigit(password, i))
                {
                    numero = true;
                }
                else
                {
                    carespecial = true;
                }
            }
            if (mayuscula && minuscula && numero && carespecial && password.Length >= 8)
            {
                return true;
            }
            return false;



           

        }

        void validar()
        {
            if (AlgoritmoContraseñaSegura(Txtcontrasena.Text))
                Txtcontrasena.Enabled=true; 
            else Txtcontrasena.Enabled=false; 
        }

        protected void BtRegistrar_Click(object sender, EventArgs e)
        {
          
            if (AlgoritmoContraseñaSegura(Txtcontrasena.Text))
            {
                Txtcontrasena.Enabled = true;
                objProcesos.usuario=  TxtUsusario.Text;
                objProcesos.pass= Txtcontrasena.Text;
                objProcesos.insertar();
                lblError0.Text = "Los datos se guardaron Correctamente ";
            }
            else
            {
                Txtcontrasena.Enabled = false;

                lblError0.Text = "Error al guardar los datos";
           }
        }
    }
}