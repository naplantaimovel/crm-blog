using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crm.Models
{
    public class BlogCategoria
    {
        public int BlogCategoriaId { get; set; }
        public string Categoria { get; set; }

        public List<BlogArtigo> BlogArtigos { get; set; }
    }
}