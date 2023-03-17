using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgURL { get; set; }

        public string ShortDescription { get; set; }

        [Display(Name="Description")]
        public string LongDescription { get; set; }

        public int Price { get; set; }
        [DisplayName("Is it in stock")]
        public Boolean InStock { get; set; }

        public ProductCategory Category { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}