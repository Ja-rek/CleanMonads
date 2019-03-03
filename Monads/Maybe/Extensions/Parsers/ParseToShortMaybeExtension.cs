using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToShortMaybeExtension
    {
        public static Maybe<short> ParseToShort(this string source)
        {
            return ShortParser.Parse(source);
        }

        public static Maybe<short> ParseToShort(this string source, IFormatProvider provider)
        {
            return ShortParser.Parse(source, provider);
        }

        public static Maybe<short> ParseToShort(this string source, NumberStyles style)
        {
            return ShortParser.Parse(source, style);
        }

        public static Maybe<short> ParseToShort(this string source, NumberStyles style, IFormatProvider provider)
        {
            return ShortParser.Parse(source, style, provider);
        }

        public static Maybe<short> ParseToShort(this Maybe<string> source)
        {
            return source.FlatMap(ShortParser.Parse);
        }

        public static Maybe<short> ParseToShort(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => ShortParser.Parse(x, provider));
        }

        public static Maybe<short> ParseToShort(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => ShortParser.Parse(x, style));
        }

        public static Maybe<short> ParseToShort(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => ShortParser.Parse(x, style, provider));
        }
    }
}
