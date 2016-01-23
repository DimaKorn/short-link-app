using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinkApp.Domain.Utility
{
   public static class MathExtension
    {

        private static string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static Dictionary<char, uint> reversed =
                digits.Select((c, i) => Tuple.Create(c, i)).ToDictionary(t => t.Item1, t => (uint)t.Item2);
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
