using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        private static readonly Regex NumberPattern = new Regex(@"(\d+(?:\.\d+)?)([\w])?", RegexOptions.Compiled);

        public static double UnformatNumber(string s)
        {
            if (s == null) return 0;
            var m = NumberPattern.Match(s);
            if (m.Success)
            {
                var index = Array.IndexOf(_numberSuffixes, m.Groups[2].Value);

                return double.Parse(m.Groups[1].Value) * (index > 0 ? Math.Pow(10, index * 3) : 1);
            }

            return 0;
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
