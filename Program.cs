using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(formatDuration(87364681));
            Console.ReadKey();

        }

        public static string formatDuration(long seconds)
        {
            var result = string.Empty;

            var units = new Dictionary<string, int>
            {
                { "year and",31536000 },
                { "month and", 2628000},
                { "day and", 86400},
                { "hour and",3600 },
                { "minute and", 60},
                { "second",1},
            };

            foreach (var unit in units)
            {
                var resultCalculation = seconds / unit.Value;

                if (resultCalculation > 0)
                    result += $" {resultCalculation} {unit.Key} ";

                seconds %= unit.Value;

                if (seconds == 0)
                    break;
            }

            return string.IsNullOrEmpty(result) ? "now" : result;

        }

        public static string formatDuration2(long seconds)
        {

            var result = string.Empty;

            var span = TimeSpan.FromSeconds(seconds);

            var totalYears = span.Days / 364.25;
            var fullYears = Math.Floor(totalYears);

            var totalMonths = (span.Days - (365.24 * fullYears)) / 30;
            var fullMonths = Math.Floor(totalMonths);

            var totalDays = (span.Days / 360);

            if (seconds < 87364681)
            {
                result = $"{span.Hours} hour(s) {span.Minutes} minute(s) and {span.Seconds} seconds ";
            }
            else
            {
                result = $"{fullYears} ano(s) {fullMonths} meses(s)  {totalDays} dias(s)  {span.Hours} hour(s) {span.Minutes} minute(s) and {span.Seconds} seconds ";
            }

            return result;

        }

    }
}
