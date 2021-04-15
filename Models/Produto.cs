using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParcialAncelmo.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public string tipo { get; set; }

        public int idCliente { get; set; }
        [ForeignKey("idCliente")]
        public Cliente cliente { get; set; }
    }
}
