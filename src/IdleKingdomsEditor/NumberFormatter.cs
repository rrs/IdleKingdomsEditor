using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdleKingdomsEditor
{
    static class NumberFormatter
    {
        public static string FormatNumber(double n)
        {
            int index = 0;

            if (!double.IsPositiveInfinity(n))
            {
                while (n > 1000)
                {
                    n /= 1000;
                    index++;
                }
            }

            return $"{n:##0.##}{_numberSuffixes[index]}";
        }

        private static readonly string[] _numberSuffixes =
        {
            "",
            "K",
            "M",
            "B",
            "T",
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z",
        };
    }
}
