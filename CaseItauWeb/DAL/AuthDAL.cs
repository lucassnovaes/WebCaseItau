using CaseItauWeb.DAL.Interface;
using CaseItauWeb.Models;
using CaseItauWeb.Utils;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.DAL
{
    public class AuthDAL : IAuthDAL
    {
        private RestClient client;
        public Token GetToken(Users user)
        {
            try
            {
                client = new RestClient(string.Format(Constants.Endpoint() + "/login"));
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
                RestRequest request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");
                request.AddBody(user);

                var response = client.Execute<object>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var tokenDeserialize = JsonConvert.DeserializeObject<Token>(response.Content);
                    return JsonConvert.DeserializeObject<Token>(response.Content);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
