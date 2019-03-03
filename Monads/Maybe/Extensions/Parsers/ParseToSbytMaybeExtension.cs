using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToSbyteMaybeExtension
    {
        public static Maybe<sbyte> ParseToSbyte(this string source)
        {
            return SbyteParser.Parse(source);
        }

        public static Maybe<sbyte> ParseToSbyte(this string source, IFormatProvider provider)
        {
            return SbyteParser.Parse(source, provider);
        }

        public static Maybe<sbyte> ParseToSbyte(this string source, NumberStyles style)
        {
            return SbyteParser.Parse(source, style);
        }

        public static Maybe<sbyte> ParseToSbyte(this string source, NumberStyles style, IFormatProvider provider)
        {
            return SbyteParser.Parse(source, style, provider);
        }

        public static Maybe<sbyte> ParseToSbyte(this Maybe<string> source)
        {
            return source.FlatMap(SbyteParser.Parse);
        }

        public static Maybe<sbyte> ParseToSbyte(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => SbyteParser.Parse(x, provider));
        }

        public static Maybe<sbyte> ParseToSbyte(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => SbyteParser.Parse(x, style));
        }

        public static Maybe<sbyte> ParseToSbyte(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => SbyteParser.Parse(x, style, provider));
        }
    }
}
