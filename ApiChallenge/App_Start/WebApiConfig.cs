using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace ApiChallenge
{
    public static class WebApiConfig
    {
        public static MySqlConnection conn()
        {
            string conn_string = "server=db4free.net;port=3306;username=janizei;pwd=GRö27aieSyL;database=licensesdatabase";

            MySqlConnection conn = new MySqlConnection(conn_string);

            return conn;
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
