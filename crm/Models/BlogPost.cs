using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crm.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Slug { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }
        public string Img { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }        
    }
}