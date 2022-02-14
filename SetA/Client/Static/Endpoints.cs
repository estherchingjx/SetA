using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetA.Client.Static
{
    public class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string ExpensesEndpoint = $"{Prefix}/expenses";
        public static readonly string PaymentMethodsEndpoint = $"{Prefix}/paymentmethods";
    }
}
