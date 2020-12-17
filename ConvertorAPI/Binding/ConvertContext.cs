using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;

namespace Binding
{
    public class ConvertContext : DbContext
    {
        public DbSet<Currency> currencies { get; set; }
        public DbSet<HistoryConvert> histories { get; set; }

        public ConvertContext(DbContextOptions<ConvertContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = 1,
                    CurrencyName = "USD"
                },
                new Currency
                {
                    Id = 2,
                    CurrencyName = "EUR"
                },
                new Currency
                {
                    Id = 3,
                    CurrencyName = "GBP"
                },
                new Currency
                {
                    Id = 4,
                    CurrencyName = "CHF"
                }

            );
            modelBuilder.Entity<HistoryConvert>().HasData(
               new HistoryConvert
               {
                   Id = 1,
                   FromAmount = 600,
                   ToAmount = 700,
                   FromCurrencyId = 1,
                   ToCurrencyId = 2,
                   DateConvert = new DateTime()



               });
           
        }
    }
}
