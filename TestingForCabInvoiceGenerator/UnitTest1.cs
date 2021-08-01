using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;

namespace TestingForCabInvoiceGenerator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("CalculatingFare")]

        public void Return_TotalFare_ForNormalRide()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
            double distance = 5.0;
            int time = 10;
            double fare = invoice.CalculateFare(distance, time);
            double expected = 60.0;
            Assert.AreEqual(expected, fare);

        }
        [TestMethod]
        [TestCategory("CalculatingFare")]
        public void Return_TotalFare_ForRide_InvalidDistance()
        {
            string expected = "Invalid";
            try
            {
                InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
                double distance = -5;
                int time = 10;
                double fare = invoice.CalculateFare(distance, time);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.message);
            }
        }
        [TestMethod]
        [TestCategory("CalculatingFare")]
        public void Return_TotalFare_ForRide_InvalidTime()
        {
            string expected = "Invalid";
            try
            {
                InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
                double distance = 10;
                int time = 0;
                double fare = invoice.CalculateFare(distance, time);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.message);
            }
        }
    }
}
