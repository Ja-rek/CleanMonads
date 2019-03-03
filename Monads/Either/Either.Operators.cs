namespace Monads
{
    public partial class Either<TLeft, TRight>
    {
        public static implicit operator Either<TLeft, TRight>(TLeft left) 
        {
            return new Either<TLeft, TRight>(left);
        }

        public static implicit operator Either<TLeft, TRight>(TRight right) 
        {
            return new Either<TLeft, TRight>(right);
        }

        public static implicit operator Either<TLeft, TRight>(Either<TLeft, NotDefined> either)
        {
            return new Either<TLeft, TRight>(either.ForceLeft);
        }

        public static implicit operator Either<TLeft, TRight>(Either<NotDefined, TRight> either) 
        {
            return new Either<TLeft, TRight>(either.ForceRight);
        }

        public static bool operator ==(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.Equals(second);
        public static bool operator !=(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => !first.Equals(second);
        public static bool operator <(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.CompareTo(second) < 0;
        public static bool operator >(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.CompareTo(second) > 0;
        public static bool operator <=(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.CompareTo(second) <= 0;
        public static bool operator >=(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.CompareTo(second) >= 0;
    }
}
