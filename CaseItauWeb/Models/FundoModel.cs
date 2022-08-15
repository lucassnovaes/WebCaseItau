using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.Models
{
    public class FundoModel
    {
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Quantidade de caracteres inválida (Minimo 4. Maximo 200")]
        [DisplayName("Nome do Fundo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Tamanho do CNPJ deve ser igual a 14")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }
        public decimal? Patrimonio { get; set; }
        public TipoFundo CodigoTipo { get; set; }
    }
}
