using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductsUnderTen1();
            ProductsUnderTen2();
        }

        private static void ProductsUnderTen1()
        {
            using (var db = new NorthwindContext())
            {
                // SELECT * FROM Products WHERE UnitPrice < 10M;
                var query = db.Products
                    .Where(product => product.UnitPrice < 10M)
                    .OrderByDescending(product => product.UnitPrice);

                Console.WriteLine("Products that cost less than $10:");
                foreach (var item in query)
                {
                    Console.WriteLine($"{item.ProductId}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }
                Console.WriteLine();
            }
        }

        private static void ProductsUnderTen2()
        {
            using (var db = new NorthwindContext())
            {
                // SELECT ProductId, ProductName, UnitPrice FROM Products WHERE UnitPrice < 10M;
                var query = db.Products
                    .Where(product => product.UnitPrice < 10M)
                    .OrderByDescending(product => product.UnitPrice)
                    .Select( product => new
                    {
                        product.ProductId,
                        product.ProductName,
                        product.UnitPrice
                    });

                Console.WriteLine("Products that cost less than $10:");
                foreach (var item in query)
                {
                    Console.WriteLine($"{item.ProductId}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }
                Console.WriteLine();
            }
        }
    }
}
