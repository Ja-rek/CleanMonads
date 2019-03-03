using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToDoubleEitherExtension
    {
        public static Either<TLeft, double> ParseToDouble<TLeft>(this string source, TLeft left)
        {
            return DoubleParser.Parse(source, left);
        }

        public static Either<TLeft, double> ParseToDouble<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return DoubleParser.Parse(source, provider, left);
        }

        public static Either<TLeft, double> ParseToDouble<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return DoubleParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, double> ParseToDouble<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return DoubleParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, double> ParseToDouble<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => DoubleParser.Parse(x, left));
        }

        public static Either<TLeft, double> ParseToDouble<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => DoubleParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, double> ParseToDouble<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => DoubleParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, double> ParseToDouble<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => DoubleParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
