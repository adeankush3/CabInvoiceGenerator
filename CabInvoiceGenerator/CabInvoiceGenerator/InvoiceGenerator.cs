using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private const double MIN_FARE = 5;
        private const double MIN_COST_PERKM = 10;
        private const int COST_PER_TIME = 1;

        public double calculateFare(double distance, int time)
        {
            double totalFare = distance * MIN_COST_PERKM + time * COST_PER_TIME;
            if (totalFare < MIN_FARE)
            {
                return MIN_FARE;
            }
            return totalFare;
        }
    }
}
