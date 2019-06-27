using EccomerceWebApi.DAL;
using EccomerceWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EccomerceWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private MaliMaliDbEntities db = new MaliMaliDbEntities();
        [HttpGet]
        public IEnumerable<Products_Table> GetProducts()
        {
            return db.Products_Table.ToList();
        }
    }
}
