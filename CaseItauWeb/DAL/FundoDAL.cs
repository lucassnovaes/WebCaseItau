using CaseItauWeb.DAL.Interface;
using CaseItauWeb.Models;
using CaseItauWeb.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.DAL
{
    public class FundoDAL : IFundoDAL
    {
        private RestClient client;

        public List<FundoModel> GetAllFundos()
        {
            try
            {
                client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/"));
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
                RestRequest request = new RestRequest();

                request.AddHeader("Content-Type", "application/json");


                var response = client.Execute<object>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<List<FundoModel>>(response.Content);
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FundoModel GetFundo(string codigo)
        {
            try
            {
                client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/" + codigo));
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
                RestRequest request = new RestRequest("", Method.Get);

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("codigo", codigo);


               var response = client.Execute<object>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<FundoModel>(response.Content);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MovePatrimony(string cod, FundoModel value)
        {
            try
            {
                client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/" + cod));
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
                RestRequest request = new RestRequest("", Method.Put);

                request.AddHeader("Content-Type", "application/json");
                request.AddBody(value.Patrimonio);


                var response = client.Execute<object>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegisterFundo(FundoModel fundo)
        {
            try
            {
                client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/"));
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
                RestRequest request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");
                request.AddBody(fundo);


                var response = client.Execute<object>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveFundo(string codigo)
        {
            try
            {
                client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/" + codigo));
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
                RestRequest request = new RestRequest("", Method.Delete);

                request.AddHeader("Content-Type", "application/json");


                var response = client.Execute<object>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateFundo(string codigo, FundoModel fundo)
        {
            try
            {
                client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/" + codigo));
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
                RestRequest request = new RestRequest("", Method.Put);

                request.AddHeader("Content-Type", "application/json");
                request.AddBody(fundo);


                var response = client.Execute<object>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
