using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.BLL.BusinessLogicLayer;
using Northwind.BLL.InterfaceBLL;
using Northwind.Entities.Entity;

namespace Northwind.WebAPI.Controllers
{
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductsBLL _productsBLL;

        public ProductsController(ProductsBLL productsBLL)
        {
            //inyeccion 
            _productsBLL = productsBLL;
        }

        /// <summary>
        /// Lista todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Product> Get(){
            return _productsBLL.GetListProducts();
        }
    }
}