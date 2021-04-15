using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParcialAncelmo.Models
{
    public class Conteudo
    {
        public int id { get; set; }
        public DateTime dataDeCadastro { get; set; }
        public string texto { get; set; }
        public string link { get; set; }

        public int idTipoConteudo { get; set; }

        [ForeignKey("idTipoConteudo")]
        public TipoConteudo tipoConteudo { get; set; }

        public int idAutor { get; set; }
        [ForeignKey("idAutor")]
        public Autor autor { get; set; }

    }
}
