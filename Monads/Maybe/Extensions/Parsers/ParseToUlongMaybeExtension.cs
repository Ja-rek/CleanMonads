using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToUlongMaybeExtension
    {
        public static Maybe<ulong> ParseToUlong(this string source)
        {
            return UlongParser.Parse(source);
        }

        public static Maybe<ulong> ParseToUlong(this string source, IFormatProvider provider)
        {
            return UlongParser.Parse(source, provider);
        }

        public static Maybe<ulong> ParseToUlong(this string source, NumberStyles style)
        {
            return UlongParser.Parse(source, style);
        }

        public static Maybe<ulong> ParseToUlong(this string source, NumberStyles style, IFormatProvider provider)
        {
            return UlongParser.Parse(source, style, provider);
        }

        public static Maybe<ulong> ParseToUlong(this Maybe<string> source)
        {
            return source.FlatMap(UlongParser.Parse);
        }

        public static Maybe<ulong> ParseToUlong(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => UlongParser.Parse(x, provider));
        }

        public static Maybe<ulong> ParseToUlong(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => UlongParser.Parse(x, style));
        }

        public static Maybe<ulong> ParseToUlong(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => UlongParser.Parse(x, style, provider));
        }
    }
}
