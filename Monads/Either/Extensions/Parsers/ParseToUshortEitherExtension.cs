using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToUshortEitherExtension
    {
        public static Either<TLeft, ushort> ParseToUshort<TLeft>(this string source, TLeft left)
        {
            return UshortParser.Parse(source, left);
        }

        public static Either<TLeft, ushort> ParseToUshort<TLeft>(this string source, IFormatProvider provider, TLeft left)
        {
            return UshortParser.Parse(source, provider, left);
        }

        public static Either<TLeft, ushort> ParseToUshort<TLeft>(this string source, NumberStyles style, TLeft left)
        {
            return UshortParser.Parse<TLeft>(source, style, left);
        }

        public static Either<TLeft, ushort> ParseToUshort<TLeft>(
            this string source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return UshortParser.Parse<TLeft>(source, style, provider, left);
        }

        public static Either<TLeft, ushort> ParseToUshort<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source
                .FlatMap(x => UshortParser.Parse(x, left));
        }

        public static Either<TLeft, ushort> ParseToUshort<TLeft>(
            this Either<TLeft, string> source, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => UshortParser.Parse<TLeft>(x, provider, left));
        }

        public static Either<TLeft, ushort> ParseToUshort<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            TLeft left)
        {
            return source.FlatMap(x => UshortParser.Parse<TLeft>(x, style, left));
        }

        public static Either<TLeft, ushort> ParseToUshort<TLeft>(
            this Either<TLeft, string> source, 
            NumberStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            return source.FlatMap(x => UshortParser.Parse<TLeft>(x, style, provider, left));
        }
    }
}
