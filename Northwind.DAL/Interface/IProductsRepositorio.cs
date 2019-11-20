using Northwind.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Interface
{
    public interface IProductsRepositorio
    {
        List<Product> GetProducts();
        Product GetProduct(int Id);
    }
}
