using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToDateTimeOffsetEitherExtension
    {
        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(this string source, TLeft left)
        {
            return DateTimeOffsetParser.Parse(source, left);
        }

        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return DateTimeOffsetParser.Parse(source, provider, left);
        }

        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(this string source, DateTimeStyles style, TLeft left)
        {
            return DateTimeOffsetParser.Parse(source, style, left);
        }

        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(
            this string source, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            return DateTimeOffsetParser.Parse(source, style, provider, left);
        }

        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source.FlatMap(x => DateTimeOffsetParser.Parse(x, left));
        }

        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeOffsetParser.Parse(x, provider, left));
        }

        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(
            this Either<TLeft, string> source, 
            DateTimeStyles style,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeOffsetParser.Parse(x, style, left));
        }

        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(
            this Either<TLeft, string> source, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeOffsetParser.Parse(x, style, provider, left));
        }

        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(
            this Either<TLeft, string> source, 
            string format, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeOffsetParser.ParseExact(x, format, style, provider, left));
        }

        public static Either<TLeft, DateTimeOffset> ParseToDateTimeOffset<TLeft>(
            this Either<TLeft, string> source, 
            string[] format, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            return source.FlatMap(x => DateTimeOffsetParser.ParseExact(x, format, style, provider, left));
        }
    }
}
