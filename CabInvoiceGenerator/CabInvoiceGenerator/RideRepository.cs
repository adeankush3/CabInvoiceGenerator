using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (rideList == false)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }
        public Ride[] GetRides(string userId)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                var userRidesArray = this.userRides[userId].ToArray();
                Console.WriteLine(" User rides [distance,time] : ");
                foreach (var ur in userRidesArray)
                {
                    Console.Write("[" + ur.time + " , " + ur.distance + "] ");
                }
                return userRidesArray;
            }
            catch (Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user ID");
            }
        }
    }
}