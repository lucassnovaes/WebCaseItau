using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.Models
{
    public class ResponseToken
    {
        public bool Succeess { get; set; }
        public int StatusCode { get; set; }
        public string Token { get; set; }
        public DateTime Expiress { get; set; }
        public string Message { get; set; }
    }
}
