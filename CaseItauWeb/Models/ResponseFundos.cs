using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.Models
{
    public class ResponseFundos
    {
        public bool Succeess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public FundoModel Fundo { get; set; }
    }
}
