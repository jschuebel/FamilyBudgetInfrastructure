using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using FamilyBudget.Domain.Model;
using FamilyBudget.Application.Interface;
using FamilyBudget.Infrastructure.DataContext;

namespace FamilyBudget.Infrastructure.Repositories
{

    public class PurchaseRepo: IPurchaseRepo
    {
      readonly BudgetDbContext _ctx;

        public PurchaseRepo(BudgetDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Purchase> ReadAll()
        {
            //Create a Filtered List
            var filteredList = from p in _ctx.Purchases
                   .AsNoTracking()
                    select new Purchase {
                        PurchaseID = p.PurchaseID,
                        ProductID = p.ProductID,
                        CostOverride=p.CostOverride!=null? p.CostOverride/100.0:null,
                        PurchaseDate=p.PurchaseDate,
                        Count=p.Count
                    };

            return filteredList;
        }

        public Purchase Create(Purchase obj) 
        {
            /*/
            if (Person.Type != null)
            {
                _ctx.Attach(Person.Type).State = EntityState.Unchanged;
            }*/
            var objCreated = _ctx.Purchases.Add(obj).Entity;
            _ctx.SaveChanges();
            return objCreated;
        }

        public Purchase Update(Purchase obj) 
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
            var per = _ctx.Purchases.FirstOrDefault(x=>x.PurchaseID==id);
            if (per==null) return false;
            var objRemoved = _ctx.Remove(per).Entity;
            _ctx.SaveChanges();
            return true;
        }

    }
}

