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
            lblError0.Text = "Bienvenido ";
               

            } else
            {
                lblError0.Text = "Adios ";


            }
        }


    }
}