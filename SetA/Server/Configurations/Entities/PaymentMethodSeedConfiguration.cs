using Microsoft.EntityFrameworkCore;
using SetA.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetA.Server.Configurations.Entities
{
    public class PaymentMethodSeedConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasData(
                 new PaymentMethod
                 {
                     Id = 1,
                     Name = "VISA"
                 },

                 new PaymentMethod
                 {
                     Id = 2,
                     Name = "NETS"
                 },

                 new Expense
                 {
                     Id = 3,
                     Name = "PayWave"
                 }
                );
        }
    }
}
