using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssesmentWebApi.Model;
using System.Data.SqlClient;

namespace AssesmentWebApi.Repo
{
    public class ShoppingRepo:SqlRepo
    {
        #region Singleton
        private static ShoppingRepo instance = null;
        public static ShoppingRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShoppingRepo();
                }
                return instance;
            }
        }
        #endregion

        public int signupResult(Shopping shopping)
        {
            SqlCommand cmd = null;
            SqlConnection con = getConnection();
            SqlTransaction tra = con.BeginTransaction();
            con.Open();
            string sql = readFile("shopping.sql");
            try
            {
                cmd = new SqlCommand(sql, con, tra);
                cmd.Parameters.AddWithValue("@id", shopping.id);
                cmd.Parameters.AddWithValue("@Name", shopping.name);
                cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                tra.Commit();
            }
            catch (SqlException e)
            {
                tra.Rollback();
                return 1;
            }
            finally
            {
                con.Close();
            }
            return 0;
        }
    }
}