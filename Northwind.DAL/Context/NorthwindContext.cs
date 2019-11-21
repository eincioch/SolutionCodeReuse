using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Context
{
    public class NorthwindContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=OTI-DEV-EINCIO\MSSQLSERVER2019;database=NorthwindDemo;User Id=sa;Password=04748826");
        }
    }
}
