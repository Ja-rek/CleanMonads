using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToUintEitherExtension
    {
        public static Either<TLeft, uint> ParseToUint<TLeft>(this string source, TLeft left)
        {
            return UintParser.Parse(source, left);
        }

        public static Either<TLeft, uint> ParseToUint<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return UintParser.Parse(source, provider, left);
        }

        public static Either<TLeft, uint> ParseToUint<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return UintParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, uint> ParseToUint<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return UintParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, uint> ParseToUint<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => UintParser.Parse(x, left));
        }

        public static Either<TLeft, uint> ParseToUint<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => UintParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, uint> ParseToUint<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => UintParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, uint> ParseToUint<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => UintParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
