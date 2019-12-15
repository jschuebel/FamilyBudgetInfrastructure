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
                    select p;

            return filteredList;
        }

        public Purchase Create(Purchase evt) { return null;}
        public Purchase GetById(int id) {return null;}
        public Purchase Update(Purchase evt) {return null;}
        //Delete Data
        public bool Delete(int id) {return false;}
    }
}

