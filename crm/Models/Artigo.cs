using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crm.Models
{
    public class Artigo
    {
        public int IdArtigo { get; set; }       

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public DateTime DataPublicacao { get; set; }

        public int Status { get; set; }

    }
}