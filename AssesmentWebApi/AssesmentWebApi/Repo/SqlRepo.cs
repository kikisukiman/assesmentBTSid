using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Entity;
using System.Configuration;
using System.IO;

namespace AssesmentWebApi.Repo
{
    public class SqlRepo
    {
        private string conString = ConfigurationManager.ConnectionStrings["HOME_DB"].ConnectionString;

        public SqlConnection connectSql()
        {
            SqlConnection con = null;
            con = new SqlConnection(conString);
            return con;
        }

        public string readFile(string sqlPath)
        {
            string path = @"..\..\SQL\" + sqlPath.Replace("/", "\\");
            string sql = File.ReadAllText(path);
            return sql;
        }

        public SqlConnection getConnection()
        {
            SqlConnection con = null;
            con = new SqlConnection(conString);
            return con;
        }
    }
}