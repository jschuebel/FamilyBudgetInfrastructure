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

        public CategoryXref Create(CategoryXref evt) { return null;}
        public CategoryXref GetById(int id) {return null;}
        public CategoryXref Update(CategoryXref evt) {return null;}
        //Delete Data
        public bool Delete(int id) {return false;}
    }
}

