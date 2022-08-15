using CaseItauWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.Utils
{
    public static class Constants
    {
        public static string Endpoint()
        {
            return "https://localhost:44378";
        }
        public static Users GetUsers()
        {
            return new Users()
            {
                Username = "CaseItau",
                Password = "2022"
            };
        }
        public static string FundsNotFound()
        {
            return "Não foi possível buscar fundos registrados.";
        }
        public static string InvalidToken()
        {
            return "Não foi possível autenticar com servidor.";
        }
        public static string Error()
        {
            return "Houve uma inconsistencia na aplicação. Tente novamente ou entre em contato com o administrador";
        }
        public static string FundsNotUpdate()
        {
            return "Não foi possível atualizar dados solicitados.";
        }
        public static string ValueNotUpdate()
        {
            return "Não foi possível atualizar valor solicitado.";
        }
        public static string FundNotRemove()
        {
            return "Não foi possível remover fundo.";
        }
    }
}
