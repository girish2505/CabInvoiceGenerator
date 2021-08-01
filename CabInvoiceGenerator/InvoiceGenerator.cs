using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType type;
        private double MINIMUM_COST_PER_KM;
        private int COST_PER_TIME;
        private double MINIMUM_FARE;
        public InvoiceGenerator(RideType type)
        {
            this.type = type;
            if (type.Equals(RideType.NORMAL_RIDE))
            {
                this.MINIMUM_COST_PER_KM = 10;
                this.COST_PER_TIME = 1;
                this.MINIMUM_FARE = 5;
            }
        }
        public double CalculateFare(double distance, int time)

        {
            double totalFare = 0.0;
            try
            {
                if (!(distance <= 0 && time <= 0))
                {
                    totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
                }

                else if (distance <= 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_DISTANCE, "Invalid");
                }
                else if (time <= 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_DISTANCE, "Invalid");
                }

            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.message);
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
    }
}
