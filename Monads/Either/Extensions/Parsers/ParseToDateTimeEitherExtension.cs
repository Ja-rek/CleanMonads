using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToDateTimeEitherExtension
    {
        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(this string source, TLeft left)
        {
            return DateTimeParser.Parse(source, left);
        }

        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return DateTimeParser.Parse(source, provider, left);
        }

        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(this string source, DateTimeStyles style, TLeft left)
        {
            return DateTimeParser.Parse(source, style, left);
        }

        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(
            this string source, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            return DateTimeParser.Parse(source, style, provider, left);
        }

        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source.FlatMap(x => DateTimeParser.Parse(x, left));
        }

        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeParser.Parse(x, provider, left));
        }

        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(
            this Either<TLeft, string> source, 
            DateTimeStyles style,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeParser.Parse(x, style, left));
        }

        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(
            this Either<TLeft, string> source, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeParser.Parse(x, style, provider, left));
        }

        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(
            this Either<TLeft, string> source, 
            string format, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeParser.ParseExact(x, format, style, provider, left));
        }

        public static Either<TLeft, DateTime> ParseToDateTime<TLeft>(
            this Either<TLeft, string> source, 
            string[] format, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeParser.ParseExact(x, format, style, provider, left));
        }
    }
}
