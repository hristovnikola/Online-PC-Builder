using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proekt2.Models
{
    public class PurchasedProduct
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }

        public string ImgURL { get; set; }

        public int Price { get; set; }
    }
}