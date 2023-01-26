using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Datos_SQLServer
    {

        //VARIABLES GLOBALES
        SqlConnection sqlConector = new SqlConnection();

        public Datos_SQLServer()
        {
            try
            {
                StringBuilder StringConexionArmado = new StringBuilder();

                StringConexionArmado.Append("Data Source=");
                StringConexionArmado.Append(ConfigurationManager.AppSettings["DataSource_SqlSer"]);
                StringConexionArmado.Append(";Initial Catalog=");
                StringConexionArmado.Append(ConfigurationManager.AppSettings["InitialCatalog_SqlSer"]);
                StringConexionArmado.Append(";User=");
                StringConexionArmado.Append(ConfigurationManager.AppSettings["User_SqlSer"]);
                StringConexionArmado.Append(";Password=");
                StringConexionArmado.Append(ConfigurationManager.AppSettings["Password_SqlSer"]);

                this.sqlConector = new SqlConnection(StringConexionArmado.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//fn constructor

        public DataTable login(Usuario objUsuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Login", sqlConector);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Connection.Open();
               
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 20).Value = objUsuario.usuario;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = objUsuario.pass;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            finally { this.sqlConector.Close(); }
        }//fn prueba conec
    





    }//fin class
}//fn space
