using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class FloatParser
    {
        public static Maybe<float> Parse(string source)
        {
            float parsed;

            if (float.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<float> Parse(string source, IFormatProvider provider)
        {
            float parsed;

            if (float.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<float> Parse(string source, NumberStyles style)
        {
            float parsed;

            if (float.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<float> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            float parsed;

            if (float.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, float> Parse<TLeft>(string source, TLeft left)
        {
            float parsed;

            if (float.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, float> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            float parsed;

            if (float.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, float> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            float parsed;

            if (float.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, float> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            float parsed;

            if (float.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
