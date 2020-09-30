using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebPlastic.App_Data
{
    public class ConnectionDataBase
    {
        public class StoreProcediur
        {


            public DataTable ObtenerData(string SP)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter(SP, con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception)
                {

                    throw;
                }
            }



            public DataTable UpdateUser(WebPlastic.Models.User model)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_UpdateProfile", con);
                    da.SelectCommand.Parameters.Add("@pidUser", SqlDbType.Int).Value = model.idUser;
                    da.SelectCommand.Parameters.Add("@pName", SqlDbType.VarChar).Value = model.Name;
                    da.SelectCommand.Parameters.Add("@pLast", SqlDbType.VarChar).Value = model.Last;
                    da.SelectCommand.Parameters.Add("@pUserName", SqlDbType.VarChar).Value = model.UserName;
                    da.SelectCommand.Parameters.Add("@pEmail", SqlDbType.VarChar).Value = model.Email;
                    da.SelectCommand.Parameters.Add("@pAddress", SqlDbType.VarChar).Value = model.Address;

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception)
                {

                    throw;
                }
            }




            public DataTable GetUser(int idUser)
            {

                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_GetUser", con);
                    da.SelectCommand.Parameters.Add("@pidUser", SqlDbType.Int).Value = idUser;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;


                }
                catch (Exception)
                {

                    throw;
                }
            }


            public DataTable getProfile()
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_GetProfile", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public DataTable ValidarIngresoUsuario(string UserName, string macAddress)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_ValidateUserLogin", con);
                    da.SelectCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@macAddress", SqlDbType.VarChar).Value = macAddress;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }

            public DataTable SaveUser(WebPlastic.Models.User model, byte[] password, Byte[] pKEY, Byte[] pIV)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_SaveUser", con);
                    da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = model.Name;
                    da.SelectCommand.Parameters.Add("@last", SqlDbType.VarChar).Value = model.Last;
                    da.SelectCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = model.Email;
                    da.SelectCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = model.UserName;
                    da.SelectCommand.Parameters.Add("@password", SqlDbType.VarBinary).Value = password;
                    da.SelectCommand.Parameters.Add("@Key", SqlDbType.VarBinary).Value = pKEY;
                    da.SelectCommand.Parameters.Add("@IV", SqlDbType.VarBinary).Value = pIV;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public DataTable verifySession(int pidUser = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_VerifySession", con);
                    da.SelectCommand.Parameters.Add("@pidUser", SqlDbType.Int).Value = pidUser;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }

            //chages

            public DataTable GetArticle()
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_GetArticle", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public DataTable GetCategory()
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_GetCategory", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public DataTable GetCart(int idUser)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_GetCart", con);
                    da.SelectCommand.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public DataTable AddCart(int idArticle,int idUser)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_AddCart", con);
                    da.SelectCommand.Parameters.Add("@idArticle", SqlDbType.Int).Value = idArticle; 
                    da.SelectCommand.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public DataTable StorageArticle(Models.Article model)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webplasticEntities"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_StorageArticle", con);
                    da.SelectCommand.Parameters.Add("@idCategory", SqlDbType.Int).Value = model.idCategory;
                    da.SelectCommand.Parameters.Add("@image", SqlDbType.VarChar).Value = model.Image;
                    da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = model.Name;
                    da.SelectCommand.Parameters.Add("@price", SqlDbType.Float).Value = model.Price;
                    da.SelectCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = model.Description;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        
    }
}