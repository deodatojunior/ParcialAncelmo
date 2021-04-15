using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParcialAncelmo.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }

        

    }
}
