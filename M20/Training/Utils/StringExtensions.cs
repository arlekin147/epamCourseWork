using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Exceptions;

namespace Training.Utils
{
    public static class StringExtensions
    {
        public static string ChangeSubstring(this string origin, string sample, string newSubstring)
        {
            if (origin == null) throw new ArgumentNullException("Исходная строка была null");
            int startIndex = origin.IndexOf(sample);
            if (startIndex < 0) throw new SubstringNotFoundException();
            char[] originChars = origin.ToCharArray();
            List<char> newString = new List<char>();
            int i = 0;
            for(; i < startIndex; ++i)
            {
                newString.Add(originChars[i]);
            }
            foreach(var c in newSubstring)
            {
                newString.Add(c);
            }
            foreach(var c in origin.Substring(startIndex + sample.Length))
            {
                newString.Add(c);
            }
            var sb = new StringBuilder();
            foreach(var c in newString)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
