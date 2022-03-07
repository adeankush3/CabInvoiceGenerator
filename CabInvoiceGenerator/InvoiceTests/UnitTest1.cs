using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class InvoiceTests
    {
        InvoiceGenerator invoice = new InvoiceGenerator();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 8.0;
            int time = 12;
            double fare = invoice.calculateFare(distance, time);
            System.Console.WriteLine("fare is : " + fare);
            Assert.AreEqual(92, fare, 0.0);
        }
    }
}