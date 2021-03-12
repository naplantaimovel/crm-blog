using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crm.Models
{
    public class BlogArtigo
    {
        public int BlogArtigoId { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }

        public int BlogCategoriaId { get; set; }
        public BlogCategoria BlogCategoria { get; set; }
    }
}