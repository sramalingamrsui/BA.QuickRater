using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RSUI.BA.Rating.Data.Helpers
{
    public class FormatAndParseUtils
    {
        public static decimal Round5Up(decimal aDecimal, int aDecimals)
        {
            /* System.Decimal.Round() does the following: (copied from the .NET doc)
			
            When d is exactly halfway between two rounded values, the result is
             the rounded value that has an even digit in the far right decimal 
             position. For example, when rounded to two decimals, the value 2.345
             becomes 2.34 and the value 2.355 becomes 2.36. This process is known
             as rounding toward even, or rounding to nearest.

            SO.......
			
             if rounding to X decimals, and if there are (X+1) decimals,
             and if the (X+1)th decimal is 5, then round up
			
            */

            double power = Math.Pow(10, aDecimals);
            decimal poweredDec = decimal.Multiply(aDecimal, Convert.ToDecimal(power));

            decimal poweredDecFloor = decimal.Floor(poweredDec);

            if ((decimal.Subtract(poweredDec, 0.5m)) == poweredDecFloor)
            {
                // make the '5' a '6' so that it will Math.Round() will round 'up'
                if (aDecimal > 0)
                    aDecimal = decimal.Add(aDecimal, Convert.ToDecimal((1 / (power * 10))));
                else
                    aDecimal = decimal.Subtract(aDecimal, Convert.ToDecimal((1 / (power * 10))));
            }

            return decimal.Round(aDecimal, aDecimals);
        }
        public static string RemoveSpecialCharacters(string str)
        {
            if (str == null || !StringIsNumeric(str))
            {
                return str;
            }

            return Regex.Replace(str, "[^0-9.]+", "", RegexOptions.Compiled);
        }

        public static bool StringIsNumeric(string str)
        {
            double number;
            var cultureInfo = new CultureInfo("en-US");
            return double.TryParse(str, NumberStyles.Any, cultureInfo, out number);
        }

        public static double ConvertToDouble(string str)
        {
            var cultureInfo = new CultureInfo("en-US");
            return double.Parse(str, NumberStyles.Any, cultureInfo);
        }

        public static string FormatStringToMoneyWithMinDecimalPlaces(string charge)
        {
            decimal parsedCharge;
            if (decimal.TryParse(charge, out parsedCharge))
            {
                decimal d = parsedCharge % 1;
                string format = "0.##";
                if (d > 0)
                {
                    format = "0.00";
                }

                return "$" + parsedCharge.ToString(format);
            }

            return "Unknown Charge";
        }
        public static bool IsNumeric(string str)
        {
            int number;
            var cultureInfo = new CultureInfo("en-US");
            return int.TryParse(str, NumberStyles.Any, cultureInfo, out number);
        }
    }
}
