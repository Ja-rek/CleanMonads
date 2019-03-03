using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToTimeSpanEitherExtension
    {
        public static Either<TLeft, TimeSpan> ParseToTimeSpan<TLeft>(this string source, TLeft left)
        {
            return TimeSpanParser.Parse(source,  left);
        }

        public static Either<TLeft, TimeSpan> ParseToTimeSpan<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return TimeSpanParser.Parse(source, provider, left);
        }

        public static Either<TLeft, TimeSpan> ParseToTimeSpan<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source.FlatMap(x => TimeSpanParser.Parse(x, left));
        }

        public static Either<TLeft, TimeSpan> ParseToTimeSpan<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => TimeSpanParser.Parse(x, provider, left));
        }
        public static Either<TLeft, TimeSpan> ParseExactToTimeSpan<TLeft>(
            this Either<TLeft, string> source, 
            string format, 
            TimeSpanStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => TimeSpanParser.ParseExact(x, format, style, provider, left));
        }

        public static Either<TLeft, TimeSpan> ParseExactToTimeSpan<TLeft>(
            this Either<TLeft, string> source, 
            string[] format, 
            TimeSpanStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => TimeSpanParser.ParseExact(x, format, style, provider, left));
        }

        public static Either<TLeft, TimeSpan> ParseExactToTimeSpan<TLeft>(
            this Either<TLeft, string> source, 
            string format, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => TimeSpanParser.ParseExact(x, format, provider, left));
        }

        public static Either<TLeft, TimeSpan> ParseExactToTimeSpan<TLeft>(
            this Either<TLeft, string> source, 
            string[] format, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => TimeSpanParser.ParseExact(x, format, provider, left));
        }

        public static Either<TLeft, TimeSpan> ParseExactToTimeSpan<TLeft>(
            this string source, 
            string format, 
            TimeSpanStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return TimeSpanParser.ParseExact(source, format, style, provider, left);
        }

        public static Either<TLeft, TimeSpan> ParseExactToTimeSpan<TLeft>(
            this string source, 
            string[] format, 
            TimeSpanStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return TimeSpanParser.ParseExact(source, format, style, provider, left);
        }

        public static Either<TLeft, TimeSpan> ParseExactToTimeSpan<TLeft>(
            this string source, 
            string format,  
            IFormatProvider provider, 
            TLeft left)
        {
            return TimeSpanParser.ParseExact(source, format, provider, left);
        }

        public static Either<TLeft, TimeSpan> ParseExactToTimeSpan<TLeft>(
            this string source, 
            string[] format, 
            IFormatProvider provider, 
            TLeft left)
        {
            return TimeSpanParser.ParseExact(source, format, provider, left);
        }
    }
}
