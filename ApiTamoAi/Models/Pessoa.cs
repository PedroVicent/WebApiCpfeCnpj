using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiTamoAi.Models
{
    public class Pessoa
    {
        [Required]
        [MinLength(3)]
        public string Nome { get; set; }

    }
}