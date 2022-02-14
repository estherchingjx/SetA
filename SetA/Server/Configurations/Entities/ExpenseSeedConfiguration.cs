using Microsoft.EntityFrameworkCore;
using SetA.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetA.Server.Configurations.Entities
{
    public class ExpenseSeedConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Expense> builder)
        {
            builder.HasData(
                 new Expense
                 {
                     Id = 1,
                     Name = "Esther",
                     Amount = 26.78m
                 },

                 new Expense
                 {
                     Id = 2,
                     Name = "Sally",
                     Amount = 78.90m
                 }
                );
        }
    }
}
