using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crm.Models
{
    public class ArtigoFoto
    {
        public int IdArtigoFoto { get; set; }

        public int IdArtigo { get; set; }

        public string Foto { get; set; }

        public int Status { get; set; }
    }
}