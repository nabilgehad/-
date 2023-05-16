using System;
using System.Linq;
namespace probabilityandstatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of items:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the values of the items:");
            double[] v = new double[n];
            for (int a = 0; a < n; a++)
            {
                v[a] = double.Parse(Console.ReadLine());
            }
            Array.Sort(v);
            double median = CalculateMedian(v);
            Console.WriteLine($"The median is: {median}");
            double mode = CalculateMode(v);
            Console.WriteLine($"The mode is: {mode}");
            double range = CalculateRange(v);
            Console.WriteLine($"The range is: {range}");
            double firstQuartile = CalculateQuartile(v, 0.25);
            Console.WriteLine($"The first quartile is: {firstQuartile}");
            double thirdQuartile = CalculateQuartile(v, 0.75);
            Console.WriteLine($"The third quartile is: {thirdQuartile}");
            double p90 = CalculatePercentile(v, 90);
            Console.WriteLine($"The P90 is: {p90}");
            double interQuartile = thirdQuartile - firstQuartile;
            Console.WriteLine($"The interquartile range is: {interQuartile}");
            double[] outlierBoundaries = CalculateOutlierBoundaries(v);
            Console.WriteLine($"The boundaries of the outlier region are: {outlierBoundaries[0]} and {outlierBoundaries[1]}");
            Console.WriteLine("Enter a value to determine if it's an outlier:");
            double value = double.Parse(Console.ReadLine());
            bool isOutlier = IsOutlier(value, outlierBoundaries[0], outlierBoundaries[1]);
            Console.WriteLine($"The value {value} is {(isOutlier ? "" : "not ")}an outlier.");
        }
        static double CalculateMedian(double[] v2)
        {
            int n = v2.Length;
            if (n % 2 == 0)
            {
                return (v2[n / 2] + v2[n / 2 - 1]) / 2;
            }
            else
            {
                return v2[n / 2];
            }
        }
        static double CalculateMode(double[] v3)
        {
            int n = v3.Length;
            double mode = v3[0];
            int maxCount = 1;
            int currentCount = 1;
            for (int b = 1; b < n; b++)
            {
                if (v3[b] == v3[b - 1])
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        mode = v3[b - 1];
                    }
                    currentCount = 1;
                }
            }
            if (currentCount > maxCount)
            {
                mode = v3[n - 1];
            }
            return mode;
        }
        static double CalculateRange(double[] v4)
        {
            return v4[v4.Length - 1] - v4[0];
        }
        static double CalculateQuartile(double[] v5, double q)
        {
            int n = v5.Length;
            int k = (int)Math.Round(q * (n - 1));
            if (k == n - 1)
            {
                return v5[n - 1];
            }
            else if (k == 0)
            {
                return v5[0];
            }
            else
            {
                double d = q * (n - 1) - k;
                return (1 - d) * v5[k] + d * v5[k + 1];
            }
        }
        static double CalculatePercentile(double[] v6, double p)
        {
            int n = v6.Length;
            int k = (int)Math.Round(p / 100 * (n - 1));
            if (k == n - 1)
            {
                return v6[n - 1];
            }
            else if (k == 0)
            {
                return v6[0];
            }
            else
            {
                double d = p / 100 * (n - 1) - k;
                return (1 - d) * v6[k] + d * v6[k + 1];
            }
        }
        static double[] CalculateOutlierBoundaries(double[] v7)
        {
            double interQuartile = CalculateQuartile(v7, 0.75) - CalculateQuartile(v7, 0.25);
            double lowerBoundary = CalculateQuartile(v7, 0.25) - 1.5 * interQuartile;
            double upperBoundary = CalculateQuartile(v7, 0.75) + 1.5 * interQuartile;
            return new double[] { lowerBoundary, upperBoundary };
        }
        static bool IsOutlier(double value, double lowerBoundary, double upperBoundary)
        {
            return value < lowerBoundary || value > upperBoundary;
        }
    }
}
