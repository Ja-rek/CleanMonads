using System;
using System.Collections.Generic;

namespace Monads.Maybe
{
    [Serializable]
    public struct Maybe<TData> : 
        IComparable<Maybe<TData>>
    {
        private readonly bool hasValue;

        internal Maybe(TData value)
        {
            if (value != null)
            {
                hasValue = true;
                Value = value;
            }
            else
            {
                hasValue = false;
                Value = default(TData);
            }
        }

        internal Maybe(bool hasValue)
        {
            this.hasValue = hasValue;
            Value = default(TData);
        }

        internal TData Value { get; }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Maybe<TData> maybe:
                    return this.Equals(maybe);

                case Maybe<INothing> maybe:
                    return this.Equals(maybe);
            
                case TData value when this.hasValue:
                    return this.Value.Equals(value);

                default:
                    return false;
            }

        }

        public bool Equals<TAny>(Maybe<TAny> obj) 
        {
            if (this.hasValue && obj.HasValue()) 
            {
                return this.Value.Equals(obj.Value);
            }

            return !this.HasValue() && !obj.HasValue();
        }

        public int CompareTo(Maybe<TData> other)
        {
            return Comparer<TData>.Default.Compare(this.Value, other.Value);
        }

        public bool HasValue(Func<TData, bool> predicate) 
        {
            return predicate(Value) && this.HasValue();
        }

        public bool HasValue() => hasValue;

        public override int GetHashCode() => !HasValue() ? 1 : Value.GetHashCode();

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
