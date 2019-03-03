using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToLongEitherExtension
    {
        public static Either<TLeft, long> ParseToLong<TLeft>(this string source, TLeft left)
        {
            return LongParser.Parse(source, left);
        }

        public static Either<TLeft, long> ParseToLong<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return LongParser.Parse(source, provider, left);
        }

        public static Either<TLeft, long> ParseToLong<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return LongParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, long> ParseToLong<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return LongParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, long> ParseToLong<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => LongParser.Parse(x, left));
        }

        public static Either<TLeft, long> ParseToLong<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => LongParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, long> ParseToLong<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => LongParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, long> ParseToLong<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => LongParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
