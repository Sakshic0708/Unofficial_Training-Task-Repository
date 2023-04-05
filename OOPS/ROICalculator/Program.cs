using System;

namespace Day1_ROICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new ROICalculator();
            calc.CalculateROI();

        }
    }

    public class ROICalculator
    {
        public decimal GainFromInvestment;
        public decimal CostOfInvestment;

        public void CalculateROI()
        {
            Console.WriteLine("Enter Gain from Investment:");
            GainFromInvestment = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Cost of Investment:");
            CostOfInvestment = Convert.ToDecimal(Console.ReadLine());

            decimal result = ((GainFromInvestment - CostOfInvestment) / CostOfInvestment) * 100;
            Console.WriteLine("Return on investment (ROI) = " + result+ "%");
        }
    }
    public class AnnulizedROI
    {

    }
   
}
