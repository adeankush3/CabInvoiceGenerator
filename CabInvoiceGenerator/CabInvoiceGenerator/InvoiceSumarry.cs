using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;
        private string userId;

        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
            Console.WriteLine("[TotalFare/NumOfRides -> ] Avg fair : " + this.averageFare);
        }

        public InvoiceSummary(int numberOfRides, double totalFare, double averageFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
            Console.WriteLine("[NumOfRides,fare,avgFare ->] Avg fair : " + this.averageFare);
        }

        public InvoiceSummary(int numberOfRides, double totalFare, string userId)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.userId = userId;
            this.averageFare = this.totalFare / this.numberOfRides;
            Console.WriteLine("[using userId] : {0}  |  Avg fair : {1}", this.userId, this.averageFare);
        }
        //The GetHashCode method provides hash code for algorithms that need quick checks of object equality.
        //Two objects that are equal return hash codes that are equal.
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputObject = (InvoiceSummary)obj;
            return this.numberOfRides == inputObject.numberOfRides &&
                this.totalFare == inputObject.totalFare &&
                this.averageFare == inputObject.averageFare;
        }

        //If hash codes of 2 objects are same, it uses Equals Method to check if they are same of not
        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }
}