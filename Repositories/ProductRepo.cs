using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using FamilyBudget.Domain.Model;
using FamilyBudget.Application.Interface;
using FamilyBudget.Infrastructure.DataContext;

namespace FamilyBudget.Infrastructure.Repositories
{

    public class ProductRepo: IProductRepo
    {
      readonly BudgetDbContext _ctx;

        public ProductRepo(BudgetDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Product> ReadAll()
        {
            //Create a Filtered List
            var filteredList = from p in _ctx.Products
                   .AsNoTracking()
                    select new Product {
                        ProductID = p.ProductID,
                        Title = p.Title, 
                        Cost=p.Cost!=null? p.Cost/100.0:null,
                        Count=p.Count
                    };

            return filteredList;
        }

        public Product Create(Product obj) 
        {
            /*/
            if (Person.Type != null)
            {
                _ctx.Attach(Person.Type).State = EntityState.Unchanged;
            }*/
            //handle null for PK auto inc  if (obj!=null) obj.ProductID=null;
            var objCreated = _ctx.Products.Add(obj).Entity;
            _ctx.SaveChanges();
            return objCreated;
        }

        public Product Update(Product obj) 
        {
            _ctx.Attach(obj).State = EntityState.Modified;
       /*     _ctx.Entry(PersonUpdate).Collection(c => c.Orders).IsModified = true;
            _ctx.Entry(PersonUpdate).Reference(c => c.Type).IsModified = true;
            var orders = _ctx.Orders.Where(o => o.Person.Id == PersonUpdate.Id
                                   && !PersonUpdate.Orders.Exists(co => co.Id == o.Id));
            foreach (var order in orders)
            {
                order.Person = null;
                _ctx.Entry(order).Reference(o => o.Person)
                    .IsModified = true;
            }
            */
            _ctx.SaveChanges();
            return obj;
        }
        //Delete Data
        public bool Delete(int id) 
               {
            /*var ordersToRemove = _ctx.Orders.Where(o => o.Person.Id == id);
            _ctx.RemoveRange(ordersToRemove);*/
            var per = _ctx.Products.FirstOrDefault(x=>x.ProductID==id);
            if (per==null) return false;
            var objRemoved = _ctx.Remove(per).Entity;
            _ctx.SaveChanges();
            return true;
        }

    }
}

