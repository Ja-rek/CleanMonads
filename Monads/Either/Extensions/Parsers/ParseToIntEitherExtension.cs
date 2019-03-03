using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToIntEitherExtension
    {
        public static Either<TLeft, int> ParseToInt<TLeft>(this string source, TLeft left)
        {
            return IntParser.Parse(source, left);
        }

        public static Either<TLeft, int> ParseToInt<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return IntParser.Parse(source, provider, left);
        }

        public static Either<TLeft, int> ParseToInt<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return IntParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, int> ParseToInt<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return IntParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, int> ParseToInt<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => IntParser.Parse(x, left));
        }

        public static Either<TLeft, int> ParseToInt<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => IntParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, int> ParseToInt<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => IntParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, int> ParseToInt<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => IntParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
