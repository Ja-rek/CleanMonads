using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToDateTimeMaybeExtension
    {
        public static Maybe<DateTime> ParseToDateTime(this string source)
        {
            return DateTimeParser.Parse(source);
        }

        public static Maybe<DateTime> ParseToDateTime(this string source, IFormatProvider provider)
        {
            return DateTimeParser.Parse(source, provider);
        }

        public static Maybe<DateTime> ParseToDateTime(this string source, DateTimeStyles style)
        {
            return DateTimeParser.Parse(source, style);
        }

        public static Maybe<DateTime> ParseToDateTime(this string source, DateTimeStyles style, IFormatProvider provider)
        {
            return DateTimeParser.Parse(source, style, provider);
        }

        public static Maybe<DateTime> ParseToDateTime(this Maybe<string> source)
        {
            return source.FlatMap(DateTimeParser.Parse);
        }

        public static Maybe<DateTime> ParseToDateTime(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => DateTimeParser.Parse(x, provider));
        }

        public static Maybe<DateTime> ParseToDateTime(this Maybe<string> source, DateTimeStyles style)
        {
            return source.FlatMap(x => DateTimeParser.Parse(x, style));
        }

        public static Maybe<DateTime> ParseToDateTime(this Maybe<string> source, DateTimeStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => DateTimeParser.Parse(x, style, provider));
        }

        public static Maybe<DateTime> ParseExactToDateTime(
            this Maybe<string> source, 
            string format, 
            DateTimeStyles style, 
            IFormatProvider provider)
        {
            return source.FlatMap(x => DateTimeParser.ParseExact(x, format, style, provider));
        }

        public static Maybe<DateTime> ParseExactToDateTime(
            this Maybe<string> source, 
            string[] format, 
            DateTimeStyles style, 
            IFormatProvider provider)
        {
            return source.FlatMap(x => DateTimeParser.ParseExact(x, format, style, provider));
        }
    }
}
