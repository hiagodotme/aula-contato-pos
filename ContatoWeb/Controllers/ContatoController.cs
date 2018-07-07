using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContatoWeb.Controllers
{
    public class ContatoController : ApiController
    {
        private SqlConnection getConn()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringAzure"].ConnectionString);
        }
        public string Get()
        {
            SqlConnection con = getConn();

            con.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = @"SELECT * FROM contato FOR JSON auto";

            SqlDataReader oi = cmd.ExecuteReader();

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
