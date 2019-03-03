using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToByteMaybeExtension
    {
        public static Maybe<byte> ParseToByte(this string source)
        {
            return ByteParser.Parse(source);
        }

        public static Maybe<byte> ParseToByte(this string source, IFormatProvider provider)
        {
            return ByteParser.Parse(source, provider);
        }

        public static Maybe<byte> ParseToByte(this string source, NumberStyles style)
        {
            return ByteParser.Parse(source, style);
        }

        public static Maybe<byte> ParseToByte(this string source, NumberStyles style, IFormatProvider provider)
        {
            return ByteParser.Parse(source, style, provider);
        }

        public static Maybe<byte> ParseToByte(this Maybe<string> source)
        {
            return source.FlatMap(ByteParser.Parse);
        }

        public static Maybe<byte> ParseToByte(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => ByteParser.Parse(x, provider));
        }

        public static Maybe<byte> ParseToByte(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => ByteParser.Parse(x, style));
        }

        public static Maybe<byte> ParseToByte(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => ByteParser.Parse(x, style, provider));
        }
    }
}
