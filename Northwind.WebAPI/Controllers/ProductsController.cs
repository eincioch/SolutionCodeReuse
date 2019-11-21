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
    /// <summary>
    /// Controller Products
    /// </summary>
    [Produces("application/json")] //se agrego
    [EnableCors("CorsPolicy")] //Habilita la politica CORS
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductsBLL _productsBLL;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productsBLL"></param>
        public ProductsController(IProductsBLL productsBLL)
        {
            //Inyeccion de dependencia
            _productsBLL = productsBLL;
        }

        /// <summary>
        /// Lista todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Product> Get() {
            return _productsBLL.GetListProducts();
        }

        /// <summary>
        /// Obtiene Product por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Product Get(int Id)
        {
            return _productsBLL.GetProductById(Id);
        }

        /// <summary>
        /// Crea un nuevo Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Product product) {
            return Ok(_productsBLL.AddProduct(product));
        }

        /// <summary>
        /// Actualiza un product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Product product) {
            _productsBLL.UpdateProduct(product);
            return NoContent();
        }

        /// <summary>
        /// Elimina un Product
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id) {
            _productsBLL.DeleteProduct(Id);
            return NoContent();
        }
    }
}