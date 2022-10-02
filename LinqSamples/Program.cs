using LinqSamples.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LinqSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new NorthwindContext())
            {

            }
            //Console.ReadLine();
        }

        private static void ClassicSqlQuery(NorthwindContext dbContext)
        {
            //var result = dbContext.Database.ExecuteSqlRaw("Delete from products where ProductID=83");
            string query = "1";
            var result1 = dbContext.Products.FromSqlRaw($"select * from products where categoryID={query}").ToList();

            foreach (var item in result1)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void Ders4(NorthwindContext dbContext)
        {
            //var orders = dbContext.Customers
            //    .Join(dbContext.Orders, c => c.CustomerId, o => o.CustomerId, (c, o) => new { customer = c, order = o })
            //    .Join(dbContext.OrderDetails, o => o.order.OrderId, od => od.OrderId, (o, od) => new { order = o, orderDetail = od })
            //    .GroupBy(g => new { g.order.customer.ContactName, g.order.customer.CompanyName })
            //    .Select(x => new
            //    {
            //        x.Key.CompanyName,
            //        x.Key.ContactName,
            //        toplam = x.Sum(x => x.orderDetail.UnitPrice)
            //    }).ToList();
            //var orders = dbContext.Customers.
            //    Select(c => new
            //    {
            //        c.ContactName,
            //        c.CompanyName,
            //        toplam=c.Orders.Select(o => o.OrderDetails.Sum(od => od.UnitPrice))
            //    }).ToList();
            var orders = dbContext.Customers.
                Where(c => c.CustomerId == "PERIC").
                Select(c => new
                {
                    c.ContactName,
                    c.CompanyName,
                    toplam = c.Orders.Select(o => o.OrderDetails.Sum(od => od.UnitPrice))
                }).ToList();
            foreach (var order in orders)
            {
                Console.WriteLine(order.CompanyName + " " + order.ContactName);
                foreach (var item in order.toplam)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void Joins(NorthwindContext dbContext)
        {
            //var products = (from p in dbContext.Products
            //                select p).ToList(); 
            #region inner join
            //var products = (from p in dbContext.Products
            //                join s in dbContext.Suppliers on p.SupplierId equals s.SupplierId
            //                select new
            //                {
            //                    p.ProductName,
            //                    s.ContactName,
            //                    s.CompanyName
            //                }).ToList(); 
            #endregion
            #region left join
            var products = dbContext.Products.
                            Select(p => new
                            {
                                p.ProductName,
                                p.Supplier.ContactName,
                                p.Supplier.CompanyName
                            }).ToList();
            #endregion
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void CategoryTable(NorthwindContext dbContext)
        {
            //var categories = dbContext.Categories.Where(c => c.Products.Count > 0).ToList();
            var categories = dbContext.Categories.Where(c => !c.Products.Any()).ToList();

            foreach (var category in categories)
            {
                Console.WriteLine(category.CategoryName + " " + category.CategoryId);
            }
        }

        private static void ProductsTable(NorthwindContext dbContext)
        {
            //var products = dbContext.Products.Where(x => x.CategoryId == 1).ToList();
            //var products = dbContext.Products.Where(x => x.Category.CategoryName == "Beverages").ToList(); // not include category table for select query
            //var products = dbContext.Products.Include(x=>x.Category).Where(x => x.Category.CategoryName == "Beverages").ToList();
            var products = dbContext.Products
                    .Where(x => x.Category.CategoryName == "Beverages")
                    .Select(p => new
                    {
                        p.ProductName,
                        p.CategoryId,
                        p.Category.CategoryName
                    })
                    .ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName + " " + product.CategoryId);
                Console.WriteLine(product.CategoryName);
            }
        }

        private static void Ders3(NorthwindContext dbContext)
        {
            var p = new Product { ProductId = 1 };
            dbContext.Products.Attach(p); //change tracking
            p.UnitsInStock = 100;
            dbContext.SaveChanges();
        }

        private static void Ders2(NorthwindContext dbContext)
        {
            var customeres = dbContext.Customers.ToList();
            var customeres2 = dbContext.Customers.Select(x => new { x.CustomerId, x.ContactName }).ToList();
            var customeres3 = dbContext.Customers.Select(x => new { x.ContactName, x.Country }).Where(x => x.Country == "Germany").Select(x => new { x.ContactName }).FirstOrDefault();
            var customeres4 = dbContext.Customers.Where(x => x.ContactName == "Diego Roel").Select(x => new { x.Country }).ToList();
            //change tracking-güncelleme için bir kopya alır.
            var products = dbContext.Products.AsNoTracking().Where(x => x.UnitsInStock == 0).ToList();
            //eğer güncelleme yapılmayacaksa yani readonly bir kullanım olacaksa o zaman 
            //AsNoTracking() metodu kullanılarak daha verimli işlem yapılabilir.
            var employees = dbContext.Employees.Select(x => new
            {
                Fullname = x.FirstName + " " + x.LastName
            }).ToList();
            var products2 = dbContext.Products.Take(5).ToList();
            var products3 = dbContext.Products.Skip(5).Take(5).ToList();
        }

        private static void Ders1(NorthwindContext dbContext)
        {
            //var products = dbContext.Products.ToList();
            //var products = dbContext.Products.Select(x=>x.ProductName).ToList();
            //var products = dbContext.Products.Select(x=> new { x.ProductName ,x.UnitPrice}).ToList();
            //var products = dbContext.Products.Select(x=> 
            //var product = dbContext.Products.FirstOrDefault();
            var product = dbContext.Products.Select(x => new { x.ProductName, x.UnitPrice }).FirstOrDefault();
            //foreach (var product in products)
            //{
            //    //Console.WriteLine(product.ProductName);
            //    //Console.WriteLine(product);
            //    //Console.WriteLine(product.ProductName+" "+product.UnitPrice);
            //    Console.WriteLine(product.Name+" "+product.Price);
            //}
            Console.WriteLine(product.ProductName + " " + product.UnitPrice);
        }
    }
}
