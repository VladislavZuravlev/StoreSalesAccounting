﻿using Microsoft.EntityFrameworkCore;


namespace StoreSalesAccounting.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<StoreRevenue> StoreRevenues { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }
        
    }
}