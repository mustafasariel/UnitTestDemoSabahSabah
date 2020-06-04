using System;

namespace UnitTestDemoSabahSabah
{
    public class AmountService
    {
        private readonly IInflationRate _inflationRate;
        readonly ILogger _logger;

        public AmountService(IInflationRate infalationRate,ILogger logger)
        {
            this._inflationRate = infalationRate;
            _logger = logger;
        }
        public double AmountCAlculateByYear(int year, double amount)
        {
            _logger.Log("");
            _logger.Log("");
            return amount + amount * _inflationRate.GetInflationByYear(year);
        }
    }
    public interface IInflationRate
    {
        double GetInflationByYear(int year);
    }
    public class InflationRate : IInflationRate
    {
        public double GetInflationByYear(int year)
        {
            double rate;
            switch (year)
            {
                case 2018:
                    rate = 0.1;
                    break;
                case 2019:
                    rate = 0.2;
                    break;
                case 2020:
                    rate = 0.3;
                    break;
                default:
                    rate = 1;
                    break;
            }
            return rate;
        }
    }

    public interface ILogger
    {
        public void Log(string msg);
    }
    public class Logger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
