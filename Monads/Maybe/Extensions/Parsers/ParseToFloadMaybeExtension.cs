using System;
using System.Globalization;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToFloatMaybeExtension
    {
        public static Maybe<float> ParseToFloat(this string source)
        {
            return FloatParser.Parse(source);
        }

        public static Maybe<float> ParseToFloat(this string source, IFormatProvider provider)
        {
            return FloatParser.Parse(source, provider);
        }

        public static Maybe<float> ParseToFloat(this string source, NumberStyles style)
        {
            return FloatParser.Parse(source, style);
        }

        public static Maybe<float> ParseToFloat(this string source, NumberStyles style, IFormatProvider provider)
        {
            return FloatParser.Parse(source, style, provider);
        }

        public static Maybe<float> ParseToFloat(this Maybe<string> source)
        {
            return source.FlatMap(FloatParser.Parse);
        }

        public static Maybe<float> ParseToFloat(this Maybe<string> source, IFormatProvider provider)
        {
            return source.FlatMap(x => FloatParser.Parse(x, provider));
        }

        public static Maybe<float> ParseToFloat(this Maybe<string> source, NumberStyles style)
        {
            return source.FlatMap(x => FloatParser.Parse(x, style));
        }

        public static Maybe<float> ParseToFloat(this Maybe<string> source, NumberStyles style, IFormatProvider provider)
        {
            return source.FlatMap(x => FloatParser.Parse(x, style, provider));
        }
    }
}
