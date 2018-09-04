using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiTamoAi.Models
{
    public class PessoaJuridica : Pessoa
    {
        public int Id;

        [Required]
        [MaxLength(18)]
        [MinLength(14)]
        public string Cnpj { get; set; }

        public PessoaJuridica() { }

        public PessoaJuridica(int id, string nome, string cnpj)
        {
            Id = id;
            Nome = nome;
            Cnpj = cnpj;
        }
    }
}