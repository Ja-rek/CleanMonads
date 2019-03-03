using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToUshortMaybeExtension
    {
        public static Maybe<ushort> ParseToUshort(this string source)
        {
            return UshortParser.Parse(source);
        }

        public static Maybe<ushort> ParseToUshort(this string source, IFormatProvider provider)
        {
            return UshortParser.Parse(source, provider);
        }

        public static Maybe<ushort> ParseToUshort(this string source, NumberStyles style)
        {
            return UshortParser.Parse(source, style);
        }

        public static Maybe<ushort> ParseToUshort(this string source, NumberStyles style, IFormatProvider provider)
        {
            return UshortParser.Parse(source, style, provider);
        }

        public static Maybe<ushort> ParseToUshort(this Maybe<string> source)
        {
            return source.FlatMap(UshortParser.Parse);
        }

        public static Maybe<ushort> ParseToUshort(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => UshortParser.Parse(x, provider));
        }

        public static Maybe<ushort> ParseToUshort(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => UshortParser.Parse(x, style));
        }

        public static Maybe<ushort> ParseToUshort(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => UshortParser.Parse(x, style, provider));
        }
    }
}
