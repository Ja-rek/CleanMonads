using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToDoubleMaybeExtension
    {
        public static Maybe<double> ParseToDouble(this string source)
        {
            return DoubleParser.Parse(source);
        }

        public static Maybe<double> ParseToDouble(this string source, IFormatProvider provider)
        {
            return DoubleParser.Parse(source, provider);
        }

        public static Maybe<double> ParseToDouble(this string source, NumberStyles style)
        {
            return DoubleParser.Parse(source, style);
        }

        public static Maybe<double> ParseToDouble(this string source, NumberStyles style, IFormatProvider provider)
        {
            return DoubleParser.Parse(source, style, provider);
        }

        public static Maybe<double> ParseToDouble(this Maybe<string> source)
        {
            return source.FlatMap(DoubleParser.Parse);
        }

        public static Maybe<double> ParseToDouble(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => DoubleParser.Parse(x, provider));
        }

        public static Maybe<double> ParseToDouble(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => DoubleParser.Parse(x, style));
        }

        public static Maybe<double> ParseToDouble(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => DoubleParser.Parse(x, style, provider));
        }
    }
}
