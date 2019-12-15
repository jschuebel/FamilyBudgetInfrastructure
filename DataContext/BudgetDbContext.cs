﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using FamilyBudget.Domain.Model;

namespace FamilyBudget.Infrastructure.DataContext
{
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) :base(options) {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryXref> CategoryXrefs { get; set; }
        
            
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlite(@"Data Source=budget.db");

       protected override void OnModelCreating(ModelBuilder modelBuilder)
          {

             modelBuilder.Entity<CategoryXref>(entity =>
              {
    //             entity.ToTable("CategoryXrefs");
                 entity.HasNoKey();
              });
    //         modelBuilder.Entity<Purchase>(entity =>
    //          {
    //              entity.ToTable("Purchases");
    //          });
          }

    }

}