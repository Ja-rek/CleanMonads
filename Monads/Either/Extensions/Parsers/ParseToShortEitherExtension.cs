using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToShortEitherExtension
    {
        public static Either<TLeft, short> ParseToShort<TLeft>(this string source, TLeft left)
        {
            return ShortParser.Parse(source, left);
        }

        public static Either<TLeft, short> ParseToShort<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return ShortParser.Parse(source, provider, left);
        }

        public static Either<TLeft, short> ParseToShort<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return ShortParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, short> ParseToShort<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return ShortParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, short> ParseToShort<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => ShortParser.Parse(x, left));
        }

        public static Either<TLeft, short> ParseToShort<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => ShortParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, short> ParseToShort<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => ShortParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, short> ParseToShort<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => ShortParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
