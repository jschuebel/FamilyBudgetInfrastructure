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
                    select p;

            return filteredList;
        }

        public Product Create(Product evt) { return null;}
        public Product GetById(int id) {return null;}
        public Product Update(Product evt) {return null;}
        //Delete Data
        public bool Delete(int id) {return false;}
    }
}

