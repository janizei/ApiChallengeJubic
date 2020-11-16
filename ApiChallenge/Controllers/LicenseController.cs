using System;
using System.Collections.Generic;
using System.Web.Http;
using ApiChallenge.Models;
using MySql.Data.MySqlClient;

namespace RestJubic.Controllers
{
    public class LicenseController : ApiController
    {
        // GET: api/license
        public List<Licenses> Get()
        {
            MySqlConnection conn = ApiChallenge.WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT * FROM LicenseInfo";

            var Licenses = new List<Licenses>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Licenses.Add(new Licenses(0, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                Licenses.Add(new Licenses((int)fetch_query["id"], fetch_query["name"].ToString(), fetch_query["expiresAt"].ToString(), DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), null));
            }

            return Licenses;
        }

        // GET api/license/{id}
        public List<Licenses> Get(int id)
        {
            MySqlConnection conn = ApiChallenge.WebApiConfig.conn();

            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT id, name, expiresAt, queriedAt FROM LicenseInfo WHERE id = @id";

            query.Parameters.AddWithValue("@id", id);

            var Licenses = new List<Licenses>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Licenses.Add(new Licenses(0, null, null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                Licenses.Add(new Licenses((int)fetch_query["id"], fetch_query["name"].ToString(), fetch_query["expiresAt"].ToString(), DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), null));
            }

            return Licenses;
        }

    }
}