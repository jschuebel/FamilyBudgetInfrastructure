using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using FamilyBudget.Domain.Model;
using FamilyBudget.Application.Interface;
using FamilyBudget.Infrastructure.DataContext;

namespace FamilyBudget.Infrastructure.Repositories
{

    public class CategoryXrefRepo: ICategoryXrefRepo
    {
      readonly BudgetDbContext _ctx;

        public CategoryXrefRepo(BudgetDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<CategoryXref> ReadAll()
        {
            //Create a Filtered List
            var filteredList = from p in _ctx.CategoryXrefs
                   .AsNoTracking()
                    select p;

            return filteredList;
        }

        public CategoryXref Add(CategoryXref obj) 
        {
            /*/
            if (Person.Type != null)
            {
                _ctx.Attach(Person.Type).State = EntityState.Unchanged;
            }*/
            var objCreated = _ctx.CategoryXrefs.Add(obj).Entity;
            return objCreated;
        }
        public void Save() 
        {
            _ctx.SaveChanges();
        }

        //Delete Data  -- Remove all xrefs for this ProductID
        public bool Delete(int id) 
        {
            /*var ordersToRemove = _ctx.Orders.Where(o => o.Person.Id == id);
            _ctx.RemoveRange(ordersToRemove);*/
            var cats = _ctx.CategoryXrefs.Where(x=>x.ProductID==id);
            if (cats==null) return false;
            _ctx.RemoveRange(cats);

            _ctx.SaveChanges();
            return true;
        }

    }
}

