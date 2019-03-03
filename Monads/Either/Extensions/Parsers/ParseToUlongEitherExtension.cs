using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToUlongEitherExtension
    {
        public static Either<TLeft, ulong> ParseToUlong<TLeft>(this string source, TLeft left)
        {
            return UlongParser.Parse(source, left);
        }

        public static Either<TLeft, ulong> ParseToUlong<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return UlongParser.Parse(source, provider, left);
        }

        public static Either<TLeft, ulong> ParseToUlong<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return UlongParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, ulong> ParseToUlong<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return UlongParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, ulong> ParseToUlong<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => UlongParser.Parse(x, left));
        }

        public static Either<TLeft, ulong> ParseToUlong<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => UlongParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, ulong> ParseToUlong<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => UlongParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, ulong> ParseToUlong<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => UlongParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
