using Northwind.DAL.Context;
using Northwind.DAL.Interface;
using Northwind.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.DAL.Repositorio
{
    public class ProductsRepositorio : IProductsRepositorio
    {
        public Product GetProduct(int Id)
        {
            using (var northwindContext = new NorthwindContext()) {
                return northwindContext.Products.ToList();
            }
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
