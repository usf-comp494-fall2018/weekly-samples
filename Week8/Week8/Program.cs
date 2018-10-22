using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Week8.Models;

namespace Week8
{
    class Program
    {
        static void Main(string[] args)
        {
            ListCategories();
            //InsertCategory();
            //EditCategory();
            //DeleteCategory();
            //LookupCustomer();
        }

        private static void ListCategories()
        {
            using (var db = new NorthwindContext())
            {
                foreach (var category in db.Categories.Include(c => c.Products))
                {
                    Console.WriteLine($"{category.CategoryName} has {category.Products.Count} products.");
                }
            }
        }

        private static void InsertCategory()
        {
            using (var db = new NorthwindContext())
            {
                Console.WriteLine($"There are {db.Categories.Count()} Categories.");
                db.Categories.Add(new Categories
                {
                    CategoryName = "Flimflams",
                    Description = "These are really tasty treats for everyone of all ages.",
                });
                db.SaveChanges();
                Console.WriteLine($"There are {db.Categories.Count()} Categories.");
            }
        }

        private static void EditCategory()
        {
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.First(c => c.CategoryName == "Flimflams");
                if(category == null)
                {
                    Console.WriteLine("Sorry, I can't find a category with the name 'Flimflams'");
                    return;
                }
                Console.WriteLine($"The Flimflams description is: {category.Description}");
                category.Description = "These are really tasty treats.";
                db.SaveChanges();
                Console.WriteLine($"The Flimflams description is: {category.Description}");
            }
        }

        private static void DeleteCategory()
        {
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.First(c => c.CategoryName == "Flimflams");
                if (category == null)
                {
                    Console.WriteLine("Sorry, I can't find a category with the name 'Flimflams'");
                    return;
                }
                Console.WriteLine($"There are {db.Categories.Count()} Categories.");
                db.Categories.Remove(category);
                db.SaveChanges();
                Console.WriteLine($"There are {db.Categories.Count()} Categories.");
            }
        }

        private static void LookupCustomer()
        {
            using (var db = new NorthwindContext())
            {
                Console.Write("Enter a Customer ID: ");
                string customerId = Console.ReadLine().ToUpper();
                while (customerId != "EXIT")
                {
                    var customer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                    if (customer == null)
                    {
                        Console.WriteLine($"Sorry, I can't find a customer with the id {customerId}");
                    }
                    else
                    {
                        string custRegion = customer.Region == null ? string.Empty : $"{customer.Region}, ";
                        Console.WriteLine($"{customer.CompanyName}");
                        Console.WriteLine($"{customer.ContactName}");
                        Console.WriteLine($"{customer.ContactTitle}");
                        Console.WriteLine($"{customer.Address}");
                        Console.WriteLine($"{customer.City}, {custRegion}{customer.PostalCode} {customer.Country}");
                        Console.WriteLine($"{customer.Phone}\n");
                    }
                    Console.Write("\nEnter a Customer ID: ");
                    customerId = Console.ReadLine().ToUpper();
                }
            }
        }
    }
}
