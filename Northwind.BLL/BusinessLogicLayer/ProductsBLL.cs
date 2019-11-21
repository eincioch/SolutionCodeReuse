using Northwind.BLL.InterfaceBLL;
using Northwind.DAL.Interface;
using Northwind.DAL.Repositorio;
using Northwind.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.BLL.BusinessLogicLayer
{
    public class ProductsBLL : IProductsBLL
    {
        public Product AddProduct(Product newProduct)
        {
            IProductsRepositorio productsRepositorio = new ProductsRepositorio();
            return productsRepositorio.Create(newProduct);
        }

        public int DeleteProduct(int Id)
        {
            IProductsRepositorio productsRepositorio = new ProductsRepositorio();
            return productsRepositorio.Delete(Id);
        }

        public List<Product> GetListProducts()
        {
            IProductsRepositorio productsRepositorio = new ProductsRepositorio();
            return productsRepositorio.GetProducts();
        }

        public Product GetProductById(int Id)
        {
            IProductsRepositorio productsRepositorio = new ProductsRepositorio();
            return productsRepositorio.GetProduct(Id);
        }

        public int UpdateProduct(Product newProduct)
        {
            IProductsRepositorio productsRepositorio = new ProductsRepositorio();
            return productsRepositorio.Update(newProduct);
        }
    }
}
