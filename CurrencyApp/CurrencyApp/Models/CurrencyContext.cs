﻿using Microsoft.EntityFrameworkCore;

namespace CurrencyApp.Models
{


    public class CurrencyContext : DbContext
    {

        public Microsoft.EntityFrameworkCore.DbSet<RegisterModel> RegisteredList { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<CurrencyModel> Currencies { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<CalculatorModel> CalculatroOperations { get; set; }

        public CurrencyContext(DbContextOptions<CurrencyContext> options)
            : base(options)
        {
        }
        
    }
}
