namespace Monads
{
    public partial struct Maybe<TData> 
    {
        public static implicit operator Maybe<TData>(TData some) => new Maybe<TData>(some);
        public static implicit operator Maybe<TData>(Maybe<INothing> none) => new Maybe<TData>(false);

        public static bool operator ==(Maybe<TData> left, Maybe<TData> right) => left.Equals(right);
        public static bool operator !=(Maybe<TData> left, Maybe<TData> right) => !left.Equals(right);
        public static bool operator <(Maybe<TData> left, Maybe<TData> right) => left.CompareTo(right) < 0;
        public static bool operator >(Maybe<TData> left, Maybe<TData> right) => left.CompareTo(right) > 0;
        public static bool operator <=(Maybe<TData> left, Maybe<TData> right) => left.CompareTo(right) <= 0;
        public static bool operator >=(Maybe<TData> left, Maybe<TData> right) => left.CompareTo(right) >= 0;
    }
}
