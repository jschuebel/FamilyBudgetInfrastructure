using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using FamilyBudget.Domain.Model;
using FamilyBudget.Application.Interface;
using FamilyBudget.Infrastructure.DataContext;

namespace FamilyBudget.Infrastructure.Repositories
{

    public class CategoryRepo: ICategoryRepo
    {
      readonly BudgetDbContext _ctx;

        public CategoryRepo(BudgetDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Category> ReadAll()
        {
            //Create a Filtered List
            var filteredList = from p in _ctx.Categories
                   .AsNoTracking()
                    select p;

            return filteredList;
        }

        public Category Create(Category evt) { return null;}
        public Category GetById(int id) {return null;}
        public Category Update(Category evt) {return null;}
        //Delete Data
        public bool Delete(int id) {return false;}
    }
}

