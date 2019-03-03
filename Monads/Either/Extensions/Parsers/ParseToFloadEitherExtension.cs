using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToFloatEitherExtension
    {
        public static Either<TLeft, float> ParseToFloat<TLeft>(this string source, TLeft left)
        {
            return FloatParser.Parse(source, left);
        }

        public static Either<TLeft, float> ParseToFloat<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return FloatParser.Parse(source, provider, left);
        }

        public static Either<TLeft, float> ParseToFloat<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return FloatParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, float> ParseToFloat<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return FloatParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, float> ParseToFloat<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => FloatParser.Parse(x, left));
        }

        public static Either<TLeft, float> ParseToFloat<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => FloatParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, float> ParseToFloat<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => FloatParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, float> ParseToFloat<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => FloatParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
