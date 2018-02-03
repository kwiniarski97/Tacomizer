using System;
using System.Linq;

namespace Tacomizer.Extensions
{
    public static class StringExtensions
    {
        public static string ToUpperFirstLetter(this string value)
        {
            switch (value)
            {
                case null: throw new ArgumentNullException(nameof(value));
                case "": throw new ArgumentException($"{nameof(value)} cannot be empty", nameof(value));
                default: return value.First().ToString().ToUpper() + value.Substring(1);
            }
        }
    }
}