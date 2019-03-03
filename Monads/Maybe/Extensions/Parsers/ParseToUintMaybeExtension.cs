using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToUintMaybeExtension
    {
        public static Maybe<uint> ParseToUint(this string source)
        {
            return UintParser.Parse(source);
        }

        public static Maybe<uint> ParseToUint(this string source, IFormatProvider provider)
        {
            return UintParser.Parse(source, provider);
        }

        public static Maybe<uint> ParseToUint(this string source, NumberStyles style)
        {
            return UintParser.Parse(source, style);
        }

        public static Maybe<uint> ParseToUint(this string source, NumberStyles style, IFormatProvider provider)
        {
            return UintParser.Parse(source, style, provider);
        }

        public static Maybe<uint> ParseToUint(this Maybe<string> source)
        {
            return source.FlatMap(UintParser.Parse);
        }

        public static Maybe<uint> ParseToUint(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => UintParser.Parse(x, provider));
        }

        public static Maybe<uint> ParseToUint(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => UintParser.Parse(x, style));
        }

        public static Maybe<uint> ParseToUint(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => UintParser.Parse(x, style, provider));
        }
    }
}
