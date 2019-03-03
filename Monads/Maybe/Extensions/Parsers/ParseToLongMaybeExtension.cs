using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToLongMaybeExtension
    {
        public static Maybe<long> ParseToLong(this string source)
        {
            return LongParser.Parse(source);
        }

        public static Maybe<long> ParseToLong(this string source, IFormatProvider provider)
        {
            return LongParser.Parse(source, provider);
        }

        public static Maybe<long> ParseToLong(this string source, NumberStyles style)
        {
            return LongParser.Parse(source, style);
        }

        public static Maybe<long> ParseToLong(this string source, NumberStyles style, IFormatProvider provider)
        {
            return LongParser.Parse(source, style, provider);
        }

        public static Maybe<long> ParseToLong(this Maybe<string> source)
        {
            return source.FlatMap(LongParser.Parse);
        }

        public static Maybe<long> ParseToLong(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => LongParser.Parse(x, provider));
        }

        public static Maybe<long> ParseToLong(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => LongParser.Parse(x, style));
        }

        public static Maybe<long> ParseToLong(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => LongParser.Parse(x, style, provider));
        }
    }
}
