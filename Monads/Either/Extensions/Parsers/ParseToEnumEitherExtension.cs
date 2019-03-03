using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToEnumEitherExtension
    {
        public static Either<TLeft, TEnum> ParseToEnum<TLeft, TEnum>(this string source, TLeft left) where TEnum : struct
        {
            return EnumParser.Parse<TLeft, TEnum>(source, left);
        }

        public static Either<TLeft, TEnum> ParseToEnum<TLeft, TEnum>(this Either<TLeft, string> source, TLeft left) where TEnum : struct
        {
            return source.FlatMap(x => EnumParser.Parse<TLeft, TEnum>(x, left));
        }

        public static Either<TLeft, TEnum> ParseToEnum<TLeft, TEnum>(
            this string source, 
            bool ignoreCase, 
            TLeft left) where TEnum : struct
        {
            return EnumParser.Parse<TLeft, TEnum>(source, ignoreCase, left);
        }

        public static Either<TLeft, TEnum> ParseToEnum<TLeft, TEnum>(
            this Either<TLeft, string> source, 
            bool ignoreCase, 
            TLeft left) where TEnum : struct
        {
            return source.FlatMap(x => EnumParser.Parse<TLeft, TEnum>(x, ignoreCase, left));
        }
    }
}
