using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssesmentWebApi.Model;
using System.Data.SqlClient;

namespace AssesmentWebApi.Repo
{
    public class UserRepo:SqlRepo
    {
        #region Singleton
        private static UserRepo instance = null;
        public static UserRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRepo();
                }
                return instance;
            }
        }
        #endregion

        public int signupResult(User user)
        {
            SqlCommand cmd = null;
            SqlConnection con = getConnection();
            SqlTransaction tra = con.BeginTransaction();
            con.Open();
            string sql = readFile("signup.sql");
            try
            {
                cmd = new SqlCommand(sql, con, tra);
                cmd.Parameters.AddWithValue("@usermame", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@phone", user.phone);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@city", user.city);
                cmd.Parameters.AddWithValue("@country", user.country);
                cmd.Parameters.AddWithValue("@name", user.name);
                cmd.Parameters.AddWithValue("@postcode", user.postcode);

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
        public int signinResult(User user)
        {
            IList<User> users = new List<User>();
            User u = new User();
            SqlDataReader dataReader = null;
            SqlCommand cmd = null;
            SqlConnection con = getConnection();
            con.Open();
            string sql = readFile("signup.sql");
            try
            {
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@usermame", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);

                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    u = new User();
                    u.email = dataReader.GetString(0);
                    u.password = dataReader.GetString(1);
                    users.Add(u);
                }
                if (users.Count == 0)
                    return 2;
            }
            catch (SqlException e)
            {   
                return 1;
            }
            finally
            {
                con.Close();
            }
            return 0;
        }
        public IList<User> getAll()
        {
            IList<User> users = new List<User>();
            User u = new User();
            SqlDataReader dataReader = null;
            SqlCommand cmd = null;
            SqlConnection con = getConnection();
            con.Open();
            string sql = readFile("getAll.sql");
            try
            {
                cmd = new SqlCommand(sql, con);

                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    u = new User();
                    u.id = dataReader.GetString(0);
                    u.username = dataReader.GetString(1);
                    u.password = dataReader.GetString(2);
                    u.email = dataReader.GetString(3);
                    u.phone = dataReader.GetString(4);
                    u.address = dataReader.GetString(5);
                    u.city = dataReader.GetString(6);
                    u.country = dataReader.GetString(7);
                    u.name = dataReader.GetString(8);
                    u.postcode = dataReader.GetString(9);
                    users.Add(u);
                }
            }
            catch (SqlException e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return users;
        }
    }
}