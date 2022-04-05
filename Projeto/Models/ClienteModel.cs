using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe um nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe sua data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe seu CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe seu email")]
        public string Email { get; set; }

        public virtual ICollection<FilmeModel> Filmes { get; set; }
    }
}