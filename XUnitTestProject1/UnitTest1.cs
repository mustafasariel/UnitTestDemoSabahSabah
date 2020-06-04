using Castle.Core.Logging;
using Moq;
using System;
using UnitTestDemoSabahSabah;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        Mock<IInflationRate> _mockRate;
        Mock<UnitTestDemoSabahSabah.ILogger> _mockLog;
        AmountService _service;
        public UnitTest1()
        {
            _mockLog = new Mock<UnitTestDemoSabahSabah.ILogger>(MockBehavior.Loose);
            _mockRate = new Mock<IInflationRate>(MockBehavior.Loose);
            _service = new AmountService(_mockRate.Object,_mockLog.Object);
        }
        [Fact]
        public void AmountCAlculateByYear_WhenValidAmount_ValidReturn()
        {
            int year = 2020;
            double amount = 1000;
            double expectedAmount = 1500;
            _mockRate.Setup(x => x.GetInflationByYear(year)).Returns(0.5);

            var actualAmount = _service.AmountCAlculateByYear(year, amount);

            Assert.Equal(expectedAmount, actualAmount);

            _mockLog.Verify(x => x.Log(It.IsAny<string>()), Times.Once());
        }
    }
}
