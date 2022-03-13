using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private readonly double MINIMUM_COST_PER_KM;
        private readonly double COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        RideType rideType;
        private RideRepository rideRepository;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
            }
        }
        public double CalculateFare(double distance, double time)
        {
            double totalFare = 0.0;
            try
            {
                totalFare = (distance * MINIMUM_COST_PER_KM) + (time * COST_PER_TIME);
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid time");

                }
            }
            double maxFare = Math.Max(totalFare, MINIMUM_FARE);
            //Console.WriteLine("\n Selected max from Total: {0} and Minimum: {1} as {2}", totalFare, MINIMUM_FARE, maxFare);
            Console.Write(" + " + maxFare);
            return maxFare;
        }

        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                rideRepository.AddRide(userId, rides);
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
        }

        public InvoiceSummary GetInvoiceSummary(String userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
                //returns array & provided to calculatefare
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
        }

        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0.0;
            Console.Write("\nCalculating total fare : ");
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare = totalFare + this.CalculateFare(ride.distance, ride.time);
                }
                Console.WriteLine("\n Total fare : " + totalFare);
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
                }
            }
            Console.WriteLine(" Num of rides : " + rides.Length);
            return new InvoiceSummary(rides.Length, totalFare);
        }

    }
}