using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt2.Models
{
    public class CustomMade
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgURL { get; set; }

        public int Price { get; set; }

        public string Processor { get; set; }

        public string MotherBoard { get; set; }

        public string Storage { get; set; }

        [Display(Name = "Power Supply")]
        public string PowerSupply { get; set; }

        public string RAM { get; set; }

        [Display(Name = "Graphics card")]
        public string GraphicsCard { get; set; }

        public string Case { get; set; }
    }
}