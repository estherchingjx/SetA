using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetA.Shared.Domain
{
    public class Expense : BaseDomainModel
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Payment { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
