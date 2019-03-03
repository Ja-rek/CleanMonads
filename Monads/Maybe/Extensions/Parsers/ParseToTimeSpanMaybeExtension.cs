using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToTimeSpanMaybeExtension
    {
        public static Maybe<TimeSpan> ParseToTimeSpan(this string source)
        {
            return TimeSpanParser.Parse(source);
        }

        public static Maybe<TimeSpan> ParseToTimeSpan(this string source, IFormatProvider provider)
        {
            return TimeSpanParser.Parse(source, provider);
        }

        public static Maybe<TimeSpan> ParseToTimeSpan(this Maybe<string> source)
        {
            return source.FlatMap(TimeSpanParser.Parse);
        }

        public static Maybe<TimeSpan> ParseToTimeSpan(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => TimeSpanParser.Parse(x, provider));
        }

        public static Maybe<TimeSpan> ParseExactToTimeSpan(this string source, string format, TimeSpanStyles style, IFormatProvider provider)
        {
            return TimeSpanParser.ParseExact(source, format, style, provider);
        }

        public static Maybe<TimeSpan> ParseExactToTimeSpan(this string source, string[] format, TimeSpanStyles style, IFormatProvider provider)
        {
            return TimeSpanParser.ParseExact(source, format, style, provider);
        }

        public static Maybe<TimeSpan> ParseExactToTimeSpan(this string source, string format,  IFormatProvider provider)
        {
            return TimeSpanParser.ParseExact(source, format, provider);
        }

        public static Maybe<TimeSpan> ParseExactToTimeSpan(this string source, string[] format, IFormatProvider provider)
        {
            return TimeSpanParser.ParseExact(source, format, provider);
        }

        public static Maybe<TimeSpan> ParseExactToTimeSpan(this Maybe<string> source, string format, TimeSpanStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => TimeSpanParser.ParseExact(x, format, style, provider));
        }

        public static Maybe<TimeSpan> ParseExactToTimeSpan(this Maybe<string> source, string[] format, TimeSpanStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => TimeSpanParser.ParseExact(x, format, style, provider));
        }

        public static Maybe<TimeSpan> ParseExactToTimeSpan(this Maybe<string> source, string format,  IFormatProvider provider)
        {
            return source.FlatMap(x => TimeSpanParser.ParseExact(x, format, provider));
        }

        public static Maybe<TimeSpan> ParseExactToTimeSpan(this Maybe<string> source, string[] format, IFormatProvider provider)
        {
            return source.FlatMap(x => TimeSpanParser.ParseExact(x, format, provider));
        }
    }
}
