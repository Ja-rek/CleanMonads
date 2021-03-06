using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToDecimalEitherExtension
    {
        public static Either<TLeft, decimal> ParseToDecimal<TLeft>(this string source, TLeft left)
        {
            return DecimalParser.Parse(source, left);
        }

        public static Either<TLeft, decimal> ParseToDecimal<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return DecimalParser.Parse(source, provider, left);
        }

        public static Either<TLeft, decimal> ParseToDecimal<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return DecimalParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, decimal> ParseToDecimal<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return DecimalParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, decimal> ParseToDecimal<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => DecimalParser.Parse(x, left));
        }

        public static Either<TLeft, decimal> ParseToDecimal<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => DecimalParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, decimal> ParseToDecimal<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => DecimalParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, decimal> ParseToDecimal<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => DecimalParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
