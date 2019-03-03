using System;
using System.Collections.Generic;

namespace Monads
{
    [Serializable]
    public partial struct Maybe<TData> : 
        IComparable<Maybe<TData>>
    {
        private readonly bool hasValue;
        private TData value;

        internal Maybe(TData value)
        {
            if (value != null)
            {
                hasValue = true;
                this.value = value;
            }
            else
            {
                hasValue = false;
                this.value = default(TData);
            }
        }

        internal Maybe(bool hasValue)
        {
            this.hasValue = hasValue;
            value = default(TData);
        }

        internal TData ForceValue 
        { 
            get => this.value; 
        }

        public bool HasValue() 
        {
            return this.hasValue;
        }

        public bool HasValue(Func<TData, bool> predicate) 
        {
            return predicate(value) && this.HasValue();
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Maybe<TData> maybe:
                    return this.Equals(maybe);

                case Maybe<INothing> maybe:
                    return this.Equals(maybe);
            
                case TData value when this.hasValue:
                    return this.value.Equals(value);

                default:
                    return false;
            }
        }

        public bool Equals<TAny>(Maybe<TAny> obj) 
        {
            if (this.hasValue && obj.HasValue()) 
            {
                return this.value.Equals(obj.value);
            }

            return !this.HasValue() && !obj.HasValue();
        }

        public int CompareTo(Maybe<TData> other)
        {
            return Comparer<TData>.Default.Compare(this.value, other.value);
        }

        public override int GetHashCode() 
        {
            return !HasValue() ? 1 : value.GetHashCode();
        }
    }
}
