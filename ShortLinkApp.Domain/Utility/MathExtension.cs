using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShortLinkApp.Domain.Utility
{
   public static class MathExtension
    {

        private static string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static Regex _checkRegex = new Regex("^[0-9A-Za-z]+",RegexOptions.Compiled);
        private static Dictionary<char, int> reversed =
                digits.Select((c, i) => Tuple.Create(c, i)).ToDictionary(t => t.Item1, t => t.Item2);
        private static long basis = 62;
        public static string ToBase62(this long source)
        {
            List<char> text = new List<char>();
            var number = source;
            while(number>0)
            {
                text.Add(digits[(int)(number % basis)]);
                number/= basis;
            }
            text.Reverse();
            return new string(text.ToArray());

        }

        public static long FromBase62(this string source)
        {
            if (!_checkRegex.IsMatch(source))
                return -1;
            long result = 0;
            long power = 1;
            foreach(var c in source.Reverse())
            {
                result += power * reversed[c];
                power *= basis;
            }

            return result;

            
        }
    }
}
