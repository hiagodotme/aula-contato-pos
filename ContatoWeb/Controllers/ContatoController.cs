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
            return new SqlConnection("Server=tcp:hiago-pos.database.windows.net,1433;Initial Catalog=bdcontato;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public string Get()
        {
            SqlConnection con = getConn();

            con.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = @"SELECT * FROM contato FOR JSON auto";

            SqlDataReader oi = cmd.ExecuteReader();

            con.Close();

            return oi.GetString(0);
        }
    }

    public class Contato
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
