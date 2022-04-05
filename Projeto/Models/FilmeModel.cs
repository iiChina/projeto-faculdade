using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class FilmeModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe uma descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe uma faixa etária")]
        public string Faixa { get; set; }

        [Required(ErrorMessage = "Informe uma sinopse")]
        public string Sinopse { get; set; }

        [Required(ErrorMessage = "Informe um genêro")]
        public string Genero { get; set; }

        public ClienteModel Cliente { get; set; }
    }
}