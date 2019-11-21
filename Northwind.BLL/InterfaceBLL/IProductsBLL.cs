using Northwind.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.BLL.InterfaceBLL
{
    public interface IProductsBLL
    {
        List<Product> GetListProducts();
        Product GetProductById(int Id);
        Product AddProduct(Product newProduct);
        int UpdateProduct(Product newProduct);
        int DeleteProduct(int Id);
    }
}
