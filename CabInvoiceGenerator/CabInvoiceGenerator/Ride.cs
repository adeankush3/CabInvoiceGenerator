using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    internal class Ride
    {
        public double distance;
        public int time;
        private double v1;
        private int v2;

        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }

    }
}
