using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EccomerceWebApi.Models
{
    public class Customer_Reg_Table
    {
        [Key]
        public int Customer_ID { get; set; }
        public string Customer_First_Name { get; set; }
        public string Customer_Second_Name { get; set; }
        public string Customer_Phone_Number { get; set; }
        public string Customer_Nearest_Primary { get; set; }
    }
}