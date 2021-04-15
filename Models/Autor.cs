using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParcialAncelmo.Models
{
    public class Autor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string linkedin { get; set; }

        
    }
}
