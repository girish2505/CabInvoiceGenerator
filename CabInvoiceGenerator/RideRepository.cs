using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<int, List<Ride>> userRides = null;
        public RideRepository()
        {
            this.userRides = new Dictionary<int, List<Ride>>();

        }
        public void AddRide(int userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_RIDES, "No rides found");
            }
        }
        public Ride[] GetRides(int userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.INVALID_USER_ID, "User id should be valid from list");
            }
        }
    }
}
