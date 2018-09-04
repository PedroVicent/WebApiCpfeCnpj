using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiTamoAi.Models
{
    public class PessoaFisica : Pessoa
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(14)]
        [MinLength(11)]
        public string Cpf { get; set; }

        public PessoaFisica() { }

        public PessoaFisica(int id,string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
    }
}