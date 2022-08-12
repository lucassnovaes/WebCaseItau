﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.Models
{
    public class FundoModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal? Patrimonio { get; set; }
        public TipoFundo CodigoTipo { get; set; }
    }
}
