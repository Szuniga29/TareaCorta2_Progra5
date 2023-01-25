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

        public Boolean probarConexion_SP(string usuarioValidar,string passValidar)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ValidaUsuario", sqlConector) 
                {
                CommandType=System.Data.CommandType.StoredProcedure
                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@usuario",SqlDbType.VarChar,50).Value=usuarioValidar;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = passValidar;
                cmd.Parameters.Add("@patron", SqlDbType.VarChar, 50).Value = "encripta1";
                 SqlDataReader dr=cmd.ExecuteReader();

                if (dr.Read()) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                
            }
            finally { this.sqlConector.Close(); }   
        }//fn prueba conec
        public Boolean probarConexionSQLServer()
        {
            try
            {
                //solo abrimos y cerramos la conexion para saber que el usuario viene bien 
                sqlConector.Open();

                return true;
            }
            catch (Exception Error)
            {
                throw new Exception(Error.Message);
            }
            finally
            {
                sqlConector.Close();
            }

        }//fin querySQL_Server
        public Boolean probarConexionSQLServer_Win_Autentifi()
        {
            try
            {
                this.sqlConector = new SqlConnection("Data Source=" + ConfigurationManager.AppSettings["DataSource"] + ";Initial Catalog=master;Integrated Security=True");

                //solo abrimos y cerramos la conexion para saber que el usuario viene bien 
                sqlConector.Open();

                return true;
            }
            catch (Exception Error)
            {
                throw new Exception(Error.Message);
            }
            finally
            {
                sqlConector.Close();
            }

        }//fin querySQL_Server
        public DataTable QuerySQL_Server(String QueryDelUsuario)
        {
            try
            {
                SqlCommand cmd = sqlConector.CreateCommand();
                cmd.CommandText = QueryDelUsuario;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dtdatos = new DataTable();

                sqlConector.Open();

                adapter.Fill(dtdatos);

                return dtdatos;
            }
            catch (Exception Error)
            {
                throw new Exception(Error.Message);
            }
            finally
            {
                sqlConector.Close();
            }

        }//fin querySQL_Server
        public DataTable QuerySQL_Server_Win_Autentifi(String QueryDelUsuario)
        {
            try
            {
                this.sqlConector = new SqlConnection("Data Source=" + ConfigurationManager.AppSettings["DataSource"] + ";Initial Catalog=master;Integrated Security=True");

                SqlCommand cmd = sqlConector.CreateCommand();
                cmd.CommandText = QueryDelUsuario;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dtdatos = new DataTable();

                sqlConector.Open();

                adapter.Fill(dtdatos);

                return dtdatos;
            }
            catch (Exception Error)
            {
                throw new Exception(Error.Message);
            }
            finally
            {
                sqlConector.Close();
            }

        }//fin querySQL_Server


        //public Boolean InsertarUsuario(string usuario, string password)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_insertar", sqlConector)
        //        {
        //            CommandType = System.Data.CommandType.StoredProcedure
        //        };
        //        cmd.Connection.Open();
        //        cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 20).Value = usuario;
        //        cmd.Parameters.Add("@clave", SqlDbType.VarChar, 20).Value = password;
        //        //cmd.Parameters.Add("@patron", SqlDbType.VarChar, 50).Value = "encripta1";
        //       cmd.ExecuteNonQuery();

               
        //            return true;
              
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);

        //    }
        //    finally { this.sqlConector.Close(); }
        //}//fn prueba conec



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
