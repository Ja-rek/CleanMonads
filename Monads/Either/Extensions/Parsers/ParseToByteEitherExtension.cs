using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToByteEitherExtension
    {
        public static Either<TLeft, byte> ParseToByte<TLeft>(this string source, TLeft left)
        {
            return ByteParser.Parse(source, left);
        }

        public static Either<TLeft, byte> ParseToByte<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return ByteParser.Parse(source, provider, left);
        }

        public static Either<TLeft, byte> ParseToByte<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return ByteParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, byte> ParseToByte<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return ByteParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, byte> ParseToByte<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => ByteParser.Parse(x, left));
        }

        public static Either<TLeft, byte> ParseToByte<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => ByteParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, byte> ParseToByte<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => ByteParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, byte> ParseToByte<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => ByteParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
