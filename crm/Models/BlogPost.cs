using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace crm.Models
{
    public class BlogPost
    {
        //[Key]
        public int BlogPostId { get; set; }

        //[Display(Name = "Slug")]
        public string Slug { get; set; }

        //[Display(Name = "Título")]
        //[Required(ErrorMessage = "{0} Obrigatório")]
        //[StringLength(70, MinimumLength = 3, ErrorMessage = "Minimo 3 characteres e máximo 70 characteres")]
        //[DataType(DataType.Text)]
        public string Titulo { get; set; }

        //[Display(Name = "Texto")]
        //[Required(ErrorMessage = "{0} Obrigatório")]
        //[StringLength(1500, MinimumLength = 3, ErrorMessage = "Minimo 3 characteres e máximo 1.500 characteres")]
        //[DataType(DataType.Text)]
        public string Texto { get; set; }

        //[Display(Name = "Autor")]
        //[DataType(DataType.Text)]
        public string Autor { get; set; }


        //[Display(Name = "Img")]        
        public string Img { get; set; }

        //[Display(Name = "Data")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        //[Display(Name = "Status")]
        public int Status { get; set; }        
    }
}