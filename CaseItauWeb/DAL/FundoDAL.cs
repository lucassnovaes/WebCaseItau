using CaseItauWeb.DAL.Interface;
using CaseItauWeb.Models;
using CaseItauWeb.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace CaseItauWeb.DAL
{
    public class FundoDAL : IFundoDAL
    {
        private RestClient client;
        AuthDAL auth = new AuthDAL();

        public List<FundoModel> GetAllFundos()
        {
            try
            {
                var token = auth.GetToken(Constants.GetUsers());
                if (token != null)
                {
                    client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/"));
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;

                    RestRequest request = new RestRequest();
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Authorization", string.Format("Bearer " + token.ResponseToken.Token));

                    var response = client.Execute<object>(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return JsonConvert.DeserializeObject<List<FundoModel>>(response.Content);
                    else
                        throw new ArgumentException(Constants.FundsNotFound());
                }
                else
                    throw new ArgumentException(Constants.InvalidToken());
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FundoModel GetFundo(string codigo)
        {
            try
            {
                var token = auth.GetToken(Constants.GetUsers());
                if (token != null)
                {
                    client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/" + codigo));
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;

                    RestRequest request = new RestRequest("", Method.Get);
                    request.AddHeader("Authorization", string.Format("Bearer " + token.ResponseToken.Token));
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("codigo", codigo);

                    var response = client.Execute<object>(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = JsonConvert.DeserializeObject<ResponseFundos>(response.Content);
                        if (result.Succeess)
                            return result.Fundo;
                        else
                            throw new ArgumentException(result.Message);
                    }

                    else
                        throw new ArgumentException(Constants.FundsNotFound());
                }
                else
                    throw new ArgumentException(Constants.InvalidToken());
            }
            catch (ArgumentException ex)
            {
                throw ex;
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
                var token = auth.GetToken(Constants.GetUsers());
                if (token != null)
                {
                    client = new RestClient(string.Format(Constants.Endpoint() + "/api/MovePatrimony/" + cod));
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;

                    RestRequest request = new RestRequest("", Method.Put);
                    request.AddHeader("Authorization", string.Format("Bearer " + token.ResponseToken.Token));
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Authorization", string.Format("Bearer " + token.ResponseToken.Token));
                    request.AddBody(value.Patrimonio);

                    var response = client.Execute<object>(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                        return true;
                    else
                        return false;
                }
                else
                    throw new ArgumentException(Constants.InvalidToken());
            }
            catch (ArgumentException ex)
            {
                throw ex;
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
                var token = auth.GetToken(Constants.GetUsers());
                if (token != null)
                {
                    client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/"));
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;

                    RestRequest request = new RestRequest("", Method.Post);
                    request.AddHeader("Authorization", string.Format("Bearer " + token.ResponseToken.Token));
                    request.AddHeader("Content-Type", "application/json");
                    request.AddBody(fundo);

                    var response = client.Execute<object>(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                        return true;
                    else
                        return false;
                }
                else
                    throw new ArgumentException(Constants.InvalidToken());
            }
            catch (ArgumentException ex)
            {
                throw ex;
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
                var token = auth.GetToken(Constants.GetUsers());
                if (token != null)
                {
                    client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/" + codigo));
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;

                    RestRequest request = new RestRequest("", Method.Delete);
                    request.AddHeader("Authorization", string.Format("Bearer " + token.ResponseToken.Token));
                    request.AddHeader("Content-Type", "application/json");

                    var response = client.Execute<object>(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                        return true;
                    else
                        return false;
                }
                else
                    throw new ArgumentException(Constants.InvalidToken());
            }
            catch (ArgumentException ex)
            {
                throw ex;
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
                var token = auth.GetToken(Constants.GetUsers());
                if (token != null)
                {
                    client = new RestClient(string.Format(Constants.Endpoint() + "/api/fundo/" + codigo));
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;

                    RestRequest request = new RestRequest("", Method.Put);
                    request.AddHeader("Authorization", string.Format("Bearer " + token.ResponseToken.Token));
                    request.AddHeader("Content-Type", "application/json");
                    request.AddBody(fundo);

                    var response = client.Execute<object>(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                        return true;
                    else
                        return false;
                }
                else
                    throw new ArgumentException(Constants.InvalidToken());
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
