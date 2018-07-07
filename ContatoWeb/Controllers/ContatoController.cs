using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace ContatoWeb.Controllers
{
    public class ContatoController : ApiController
    {
        private SqlConnection getConn()
        {
            var key = "connectionStringAzure";
            string strcon = ConfigurationManager.ConnectionStrings[key]
                .ConnectionString;
            return new SqlConnection(strcon);
        }
        public string Get()
        {
            SqlConnection con = getConn();

            con.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = @"SELECT * FROM contato FOR JSON auto";

            SqlDataReader oi = cmd.ExecuteReader();
            oi.Read();
            string retorno = oi.GetString(0);

            con.Close();

            return retorno;
        }
    }

    public class Contato
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
