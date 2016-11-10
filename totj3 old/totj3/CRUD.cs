using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RestSharp;
namespace totj3
{
    public static class CRUD
    {
        public static string session = "DTHgirSnhfvHIBh0neUx";

        public static string Create(string table, string columns, string values)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://94.213.168.52");

            var request = new RestRequest(Method.POST);
            request.Resource = "/API/create.php";

            request.AddParameter("table", table);
            request.AddParameter("columns", columns);
            request.AddParameter("values", values);
            request.AddParameter("auth", session);

            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static string Update(string table, string values, string where)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://94.213.168.52");

            var request = new RestRequest(Method.POST);
            request.Resource = "/API/update.php";

            request.AddParameter("table", table);
            request.AddParameter("values", values);
            request.AddParameter("where", where);
            request.AddParameter("auth", session);

            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static string Read(string what, string table, string where)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://94.213.168.52");

            var request = new RestRequest(Method.POST);
            request.Resource = "/API/read.php";

            request.AddParameter("what", what);
            request.AddParameter("table", table);
            request.AddParameter("where", where);
            request.AddParameter("auth", session);

            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static string ReadCheck(string what, string table, string where)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://94.213.168.52");

            var request = new RestRequest(Method.POST);
            request.Resource = "/API/read.php";

            request.AddParameter("what", what);
            request.AddParameter("table", table);
            request.AddParameter("where", where);
            request.AddParameter("auth", session);

            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}