namespace Monads
{
    public static class ValueOrMaybeExtension
    {
        public static string ValueOrEmpty(this Maybe<string> text)
        {
            return text.ValueOr(string.Empty);
        }

        public static int ValueOrZero(this Maybe<int> text)
        {
            return text.ValueOr(0);
        }
    }
}
