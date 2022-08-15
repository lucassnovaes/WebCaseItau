using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItauWeb.Models
{
    public class TipoFundo
    {
        public int CodigoTipo { get; set; }
        [Required(ErrorMessage = "Tipo do fundo é obrigatório")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Quantidade de caracteres inválida (Minimo 4. Maximo 200")]
        [DisplayName("Tipo de Fundo")]
        public string NomeTipo { get; set; }
    }
}
