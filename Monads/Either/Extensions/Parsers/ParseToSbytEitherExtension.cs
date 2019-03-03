using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToSbyteEitherExtension
    {
        public static Either<TLeft, sbyte> ParseToSbyte<TLeft>(this string source, TLeft left)
        {
            return SbyteParser.Parse(source, left);
        }

        public static Either<TLeft, sbyte> ParseToSbyte<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return SbyteParser.Parse(source, provider, left);
        }

        public static Either<TLeft, sbyte> ParseToSbyte<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return SbyteParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, sbyte> ParseToSbyte<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return SbyteParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, sbyte> ParseToSbyte<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => SbyteParser.Parse(x, left));
        }

        public static Either<TLeft, sbyte> ParseToSbyte<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => SbyteParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, sbyte> ParseToSbyte<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => SbyteParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, sbyte> ParseToSbyte<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => SbyteParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
