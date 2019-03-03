using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToDateTimeOffsetMaybeExtension
    {
        public static Maybe<DateTimeOffset> ParseToDateTimeOffset(this string source)
        {
            return DateTimeOffsetParser.Parse(source);
        }

        public static Maybe<DateTimeOffset> ParseToDateTimeOffset(this string source, IFormatProvider provider)
        {
            return DateTimeOffsetParser.Parse(source, provider);
        }

        public static Maybe<DateTimeOffset> ParseToDateTimeOffset(this string source, DateTimeStyles style)
        {
            return DateTimeOffsetParser.Parse(source, style);
        }

        public static Maybe<DateTimeOffset> ParseToDateTimeOffset(this string source, DateTimeStyles style, IFormatProvider provider)
        {
            return DateTimeOffsetParser.Parse(source, style, provider);
        }

        public static Maybe<DateTimeOffset> ParseToDateTimeOffset(this Maybe<string> source)
        {
            return source.FlatMap(DateTimeOffsetParser.Parse);
        }

        public static Maybe<DateTimeOffset> ParseToDateTimeOffset(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => DateTimeOffsetParser.Parse(x, provider));
        }

        public static Maybe<DateTimeOffset> ParseToDateTimeOffset(this Maybe<string> source, DateTimeStyles style)
        {
            return source.FlatMap(x => DateTimeOffsetParser.Parse(x, style));
        }

        public static Maybe<DateTimeOffset> ParseToDateTimeOffset(this Maybe<string> source, DateTimeStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => DateTimeOffsetParser.Parse(x, style, provider));
        }

        public static Maybe<DateTimeOffset> ParseExactToDateTimeOffset(
            this Maybe<string> source, 
            string format, 
            DateTimeStyles style, 
            IFormatProvider provider)
        {
            return source.FlatMap(x => DateTimeOffsetParser.ParseExact(x, format, style, provider));
        }

        public static Maybe<DateTimeOffset> ParseExactToDateTimeOffset(
            this Maybe<string> source, 
            string[] format, 
            DateTimeStyles style, 
            IFormatProvider provider)
        {
            return source.FlatMap(x => DateTimeOffsetParser.ParseExact(x, format, style, provider));
        }
    }
}
