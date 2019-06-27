using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EccomerceWebApi.Models
{
    public class Products_Table
    {
        [Key]
        public int Product_ID { get; set; }
        public string Product_Image { get; set; }
        public string Product_Name { get; set; }
        public string Product_Desc { get; set; }
        public string Product_Price { get; set; }
    }
}