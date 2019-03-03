using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToIntMaybeExtension
    {
        public static Maybe<int> ParseToInt(this string source)
        {
            return IntParser.Parse(source);
        }

        public static Maybe<int> ParseToInt(this string source, IFormatProvider provider)
        {
            return IntParser.Parse(source, provider);
        }

        public static Maybe<int> ParseToInt(this string source, NumberStyles style)
        {
            return IntParser.Parse(source, style);
        }

        public static Maybe<int> ParseToInt(this string source, NumberStyles style, IFormatProvider provider)
        {
            return IntParser.Parse(source, style, provider);
        }

        public static Maybe<int> ParseToInt(this Maybe<string> source)
        {
            return source.FlatMap(IntParser.Parse);
        }

        public static Maybe<int> ParseToInt(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => IntParser.Parse(x, provider));
        }

        public static Maybe<int> ParseToInt(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => IntParser.Parse(x, style));
        }

        public static Maybe<int> ParseToInt(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => IntParser.Parse(x, style, provider));
        }
    }
}
