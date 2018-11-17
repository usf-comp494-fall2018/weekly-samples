using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NorthwindLibrary;

namespace NorthwindService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        // Cache the customers in a thread-safe dictionary to improve performance
        private static ConcurrentDictionary<string, Customers> customersCache;
        private NorthwindContext db;

        public CustomerRepository(NorthwindContext db)
        {
            this.db = db;
            // pre-load customers from database as a normal
            // Dictionary with CustomerID as the key,
            // then convert to a thread-safe ConcurrentDictionary
            if(customersCache == null)
            {
                customersCache = new ConcurrentDictionary<string, Customers>(
                    db.Customers.ToDictionary(c => c.CustomerId));
            }
        }

        public async Task<Customers> CreateAsync(Customers c)
        {
            // normalize CustomerId into uppercase
            c.CustomerId = c.CustomerId.ToUpper();

            // add to database using EF Core
            EntityEntry<Customers> added = await db.Customers.AddAsync(c);

            int affected = await db.SaveChangesAsync();

            if(affected == 1)
            {
                // if the customer is new, add it to cache, else
                // call UpdateCache method
                return customersCache.AddOrUpdate(c.CustomerId, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Customers>> RetrieveAllAsync()
        {
            // for performance, get from cache
            return await Task.Run<IEnumerable<Customers>>(() => customersCache.Values);
        }

        public async Task<Customers> RetrieveAsync(string id)
        {
            return await Task.Run(() => {
                // for performance, get from cache
                id = id.ToUpper();
                customersCache.TryGetValue(id, out Customers c);
                return c;
            });
        }

        private Customers UpdateCache(string id, Customers c)
        {
            if(customersCache.TryGetValue(id, out Customers old))
            {
                if(customersCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
            return null;
        }

        public async Task<Customers> UpdateAsync(string id, Customers c)
        {
            return await Task.Run(() =>
            {
                // normalize customer ID
                id = id.ToUpper();
                c.CustomerId = c.CustomerId.ToUpper();

                // update in database
                db.Customers.Update(c);
                int affected = db.SaveChanges();

                if(affected == 1)
                {
                    // update in cache
                    return Task.Run(() => UpdateCache(id, c));
                }
                return null;
            });
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await Task.Run(() =>
            {
                id = id.ToUpper();

                // remove from database
                Customers c = db.Customers.Find(id);
                db.Customers.Remove(c);
                int affected = db.SaveChanges();
                if(affected == 1)
                {
                    // remove from cache
                    return Task.Run(() => customersCache.TryRemove(id, out c));
                }
                else
                {
                    return null;
                }
            });
        }
    }
}
