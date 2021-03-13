using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crm.Models
{
    public class Blog
    {
        public int BlogId { get; set; }        
        public string Texto { get; set; }  
        public int Status { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}