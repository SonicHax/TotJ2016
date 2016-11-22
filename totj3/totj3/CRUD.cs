using System;
using totj3.Models;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace totj3
{
    /// <summary>
    /// https://github.com/mevdschee/php-crud-api
    /// https://github.com/mevdschee/php-crud-api#spatialgis-support
    /// This class is build based on the PHP api on the link above.
    /// </summary>
    public static class CRUD
    {
        /// <summary>
        /// This is the default session seed. This will later be implemented
        /// in the calls so that you cannot just crawl around the website and
        /// acces the API page for no reason.
        /// </summary>
        public static string session = "DTHgirSnhfvHIBh0neUx";

        /// <summary>
        /// This is the default RestClient. Used in every database related function.
        /// </summary>
        public static RestClient defaultClient;

        /// <summary>
        /// This is the default RestRequest. It is initiated here, but will be
        /// redeclared in every function.
        /// </summary>
        public static RestRequest defaultRequest;  

        /// <summary>
        /// This is function to Get data from the database.
        /// </summary>
        /// <param name="table">The table you need to acces.</param>
        /// <param name="id">The id you need data about.</param>
        /// <returns>It returns a model from the database with the collected data</returns>
        public static Model Select(string table, int id)
        {
            defaultRequest = new RestRequest(Method.GET);
            defaultRequest.Resource = table + "/" + id + "/";

            IRestResponse response = defaultClient.Execute(defaultRequest);
            if(table == "player")
            {
                return JsonConvert.DeserializeObject<Player>(response.Content);

            } else if (table == "room")
            {
                return JsonConvert.DeserializeObject<Room>(response.Content);
            }
            return new Model();
        }

        public static string simpleRequest(string query)
        {
            defaultClient = new RestClient();
            defaultClient.BaseUrl = new Uri("http://94.213.168.52/API/query.php");

            defaultRequest = new RestRequest(Method.GET);
            defaultRequest.AddParameter("query", query);
            defaultRequest.AddParameter("seed", "jsBazaWPyMt0I3UgoE7qGBNAhFhaRUiNrpek1nxj");

            IRestResponse response = defaultClient.Execute(defaultRequest);
            
            return response.Content;
        }

        /// <summary>
        /// This is function to Get data from the database in List format.
        /// </summary>
        /// <param name="table">The table you need to acces.</param>
        /// <param name="id">The id you need data about.</param>
        /// <returns></returns>
        public static Model List(string table)
        {
            defaultRequest = new RestRequest(Method.GET);
            defaultRequest.Resource = table;

            defaultRequest.AddParameter("transform", 1);

            IRestResponse response = defaultClient.Execute(defaultRequest);
            if (table == "player")
            {
                return JsonConvert.DeserializeObject<Player>(response.Content);
            }
            else if (table == "room")
            {
                return JsonConvert.DeserializeObject<Room>(response.Content);
            }
            return new Model();
            
        }

        public static int[] getPlayers(int roomID)
        {
            RestClient customClient = new RestClient();
            customClient.BaseUrl = new Uri("http://94.213.168.52/API/read.php?table=player&what=playerID&where=roomID=" + roomID);

            defaultRequest = new RestRequest(Method.GET);

            IRestResponse response = defaultClient.Execute(defaultRequest);

            string[] result = response.Content.Split(',');
            int[] intResult = new int[4];
            int i = 0;
            foreach (string res in result)
            {
                if(res != ",")
                {
                    Int32.TryParse(res, out intResult[i]);
                }
            }

            return intResult;
        }

        public static int getMaxID(string table, string what)
        {
            RestClient customClient = new RestClient();
            customClient.BaseUrl = new Uri("http://94.213.168.52/API/readMaxID.php?table=" + table + "&what=" + what);

            RestRequest customRequest = new RestRequest(Method.GET);
            
            IRestResponse response = customClient.Execute(customRequest);
            string result = response.Content;

            int intResult = Int32.Parse(result);
            return intResult;
        }

        /// <summary>
        /// This is the function to update data in the database.
        /// </summary>
        /// <param name="table">The table you need data from.</param>
        /// <param name="id">The id you need to acces.</param>
        /// <param name="o">The object that will be send to the database in Json format.</param>
        /// <returns>Returns an int with the amount of affected rows</returns>
        public static int Update(string table, int id, Model o)
        {
            defaultRequest = new RestRequest(Method.PUT);
            defaultRequest.Resource = table + "/" + id + "/";
            defaultRequest.AddJsonBody(o);

            IRestResponse response = defaultClient.Execute(defaultRequest);

            return JsonConvert.DeserializeObject<int>(response.Content);
        }

        /// <summary>
        /// This is the function to create a record in the database.
        /// </summary>
        /// <param name="table">The table you need data from.</param>
        /// <param name="id">The id you need to acces.</param>
        /// <param name="o">The object that will be send to the database in Json format.</param>
        /// <returns>This returns the id of the created record</returns>
        public static void Insert(string table, string o)
        {
            defaultClient = new RestClient();
            defaultClient.BaseUrl = new Uri("http://94.213.168.52/API/api.php/");

            defaultRequest = new RestRequest(Method.POST);
            defaultRequest.Resource = table + o;
            defaultRequest.AddJsonBody(o);
            
            IRestResponse response = defaultClient.Execute(defaultRequest);
            Console.WriteLine(response.Content);
        }

        /// <summary>
        /// This is the function to delete a record in the database.
        /// </summary>
        /// <param name="table">The table you need data from.</param>
        /// <param name="id">The id you need to acces.</param>
        /// <returns>Returns an int with the amount of affected rows</returns>
        public static int Delete(string table, int id)
        {
            defaultRequest = new RestRequest(Method.DELETE);
            defaultRequest.Resource = table + "/" + id + "/";

            IRestResponse response = defaultClient.Execute(defaultRequest);
            return JsonConvert.DeserializeObject<int>(response.Content);
        }

        /// <summary>
        /// This function set the default client. It is called upon in the 
        /// Mainactivity at the start of the app.
        /// </summary>
        public static void setDefaultClient()
        {
            defaultClient = new RestClient();
            defaultClient.BaseUrl = new Uri("http://94.213.168.52/API/api.php/");
        }
    }
}