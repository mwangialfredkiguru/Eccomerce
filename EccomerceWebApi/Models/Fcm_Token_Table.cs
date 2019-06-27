using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EccomerceWebApi.Models
{
    public class Fcm_Token_Table
    {
        [Key]
        public int Fcm_Token_ID { get; set; }
        public string Fcm_Token { get; set; }
    }
}