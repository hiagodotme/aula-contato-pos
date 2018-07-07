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
        public List<Contato> Get()
        {
            SqlConnection con = getConn();

            con.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM contato";

            SqlDataReader oi = cmd.ExecuteReader();
            List<Contato> retorno = new List<Contato>();
            while(oi.Read())
            {
                retorno.Add(new Contato {
                    ContatoId = (int)oi["ContatoId"],
                    Nome = (String)oi["Nome"],
                    Email = (String)oi["Email"]
                });
            }

            con.Close();

            return retorno;
        }

        [HttpPost]
        public bool inserir (Contato c)
        {
            SqlConnection con = getConn();

            con.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO contato (@Nome, @Email)";
            cmd.Parameters.AddWithValue("Nome", c.Nome);
            cmd.Parameters.AddWithValue("Email", c.Email);
            cmd.ExecuteScalar();

            return true;
        }  
    }

    public class Contato
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
