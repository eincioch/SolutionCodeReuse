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
            //new caracteristica C# 8
            using var Context = new NorthwindContext(); 
            return Context.Products.Where(p=>p.Id==Id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            using var Context = new NorthwindContext();
            return Context.Products.ToList();
        }

        public Product Create(Product newProduct) {

            using var Context = new NorthwindContext();
            Context.Add(newProduct);
            Context.SaveChanges();
            return newProduct;
        }

        public int Update(Product newProduct)
        {
            using var Context = new NorthwindContext();
            Context.Update(newProduct);
            return Context.SaveChanges();
        }

        public int Delete(int Id)
        {
            using var Context = new NorthwindContext();
            Context.Remove(new Product { Id=Id});
            return Context.SaveChanges();
        }
    }
}
