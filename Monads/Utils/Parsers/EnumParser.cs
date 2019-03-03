using System;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class EnumParser
    {
        public static Maybe<TEnum> Parse<TEnum>(string source, bool ignoreCase) where TEnum : struct
        {
            TEnum parsed;

            if (Enum.TryParse(source, ignoreCase , out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<TEnum> Parse<TEnum>(string source) where TEnum : struct
        {
            TEnum parsed;

            if (Enum.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, TEnum> Parse<TLeft, TEnum>(string source, bool ignoreCase, TLeft left) where TEnum : struct
        {
            TEnum parsed;

            if (Enum.TryParse(source, ignoreCase , out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, TEnum> Parse<TLeft, TEnum>(string source, TLeft left) where TEnum : struct
        {
            TEnum parsed;

            if (Enum.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
