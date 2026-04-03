using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTK;
namespace UnitTest
{
    /// <summary>
    /// Класс для тестирования функции рачета цены билета
    /// </summary>
    [TestClass]
    public class TicketPriceTests
    {
        [TestMethod]
        public void Pos_Tests()
        {
            Assert.AreEqual(Calculations.TicketPrice("100", "2", 0), 1600, 0.1);
            Assert.AreEqual(Calculations.TicketPrice("100", "2", 1), 1760, 0.1);
            Assert.AreEqual(Calculations.TicketPrice("100", "2", 2), 1920, 0.1);
            Assert.AreEqual(Calculations.TicketPrice("100", "2", 3), 2080, 0.1);
        }
        [TestMethod]
        public void Pos_Test_Dist_Dot_and_Comma()
        {
            Assert.AreEqual(Calculations.TicketPrice("1.5", "2", 0), 24, 0.1);
            Assert.AreEqual(Calculations.TicketPrice("1,5", "2", 0), 24, 0.1);
        }
        [TestMethod]
        public void No_Input()
        {
            Assert.AreEqual(Calculations.TicketPrice("", "", 0), 0, 0);
        }
        [TestMethod]
        public void Invalid_Input()
        {
            Assert.AreEqual(Calculations.TicketPrice("100,123..321", "2", 1), 0, 0);
        }
        [TestMethod]
        public void Zero_Ticket()
        {
            Assert.AreEqual(Calculations.TicketPrice("100", "0", 2), 0, 0);
        }
    }
}
