using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToEnumMaybeExtension
    {
        public static Maybe<TEnum> ParseToEnum<TEnum>(this string source) where TEnum : struct
        {
            return EnumParser.Parse<TEnum>(source);
        }

        public static Maybe<TEnum> ParseToEnum<TEnum>(this Maybe<string> source) where TEnum : struct
        {
            return source.FlatMap(EnumParser.Parse<TEnum>);
        }

        public static Maybe<TEnum> ParseToEnum<TEnum>(this string source, bool ignoreCase) where TEnum : struct
        {
            return EnumParser.Parse<TEnum>(source, ignoreCase);
        }

        public static Maybe<TEnum> ParseToEnum<TEnum>(this Maybe<string> source, bool ignoreCase) where TEnum : struct
        {
            return source.FlatMap(x => EnumParser.Parse<TEnum>(x, ignoreCase));
        }
    }
}
