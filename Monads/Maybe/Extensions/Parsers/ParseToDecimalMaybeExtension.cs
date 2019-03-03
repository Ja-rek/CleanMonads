using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToDecimalMaybeExtension
    {
        public static Maybe<decimal> ParseToDecimal(this string source)
        {
            return DecimalParser.Parse(source);
        }

        public static Maybe<decimal> ParseToDecimal(this string source, IFormatProvider provider)
        {
            return DecimalParser.Parse(source, provider);
        }

        public static Maybe<decimal> ParseToDecimal(this string source, NumberStyles style)
        {
            return DecimalParser.Parse(source, style);
        }

        public static Maybe<decimal> ParseToDecimal(this string source, NumberStyles style, IFormatProvider provider)
        {
            return DecimalParser.Parse(source, style, provider);
        }

        public static Maybe<decimal> ParseToDecimal(this Maybe<string> source)
        {
            return source.FlatMap(DecimalParser.Parse);
        }

        public static Maybe<decimal> ParseToDecimal(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => DecimalParser.Parse(x, provider));
        }

        public static Maybe<decimal> ParseToDecimal(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => DecimalParser.Parse(x, style));
        }

        public static Maybe<decimal> ParseToDecimal(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => DecimalParser.Parse(x, style, provider));
        }
    }
}
