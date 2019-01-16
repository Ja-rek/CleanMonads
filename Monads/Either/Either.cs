using System;
using System.Collections.Generic;
using Monads.Common;

namespace Monads.Either
{
    [Serializable]
    public struct Either<TLeft, TRight> : 
        IComparable<Either<TLeft, TRight>>
    {
        private readonly bool isRight;
        private readonly bool isLeft;

        internal Either(TLeft left, TRight right, bool isRight, bool isLeft)
        {
            this.isRight = isRight;
            this.isLeft = isLeft;
            Left = left;
            Right = right;
        }

        internal Either(TRight right) : this(default, right, true, false) 
        { 
            Assert.ArgumentIsNotNull(right, nameof(right));
        }

        internal Either(TLeft left) : this(left, default, false, true) 
        { 
            Assert.ArgumentIsNotNull(left, nameof(left));
        }

        internal TLeft Left { get; }
        internal TRight Right { get; }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Either<TLeft, TRight> either:
                    return this.Equals(either);

                case Either<NotDefined, TRight> either:
                    return this.Equals(either);

                case Either<TLeft, NotDefined> either:
                    return this.Equals(either);
            
                case TRight right when this.isRight:
                    return this.Right.Equals(right);

                default:
                    return false;
            }
        }

        public bool Equals<TAnyLeft, TAnyRight>(Either<TAnyLeft, TAnyRight> either) 
        {
            if (this.isRight && either.IsRight()) 
            {
                return this.Right.Equals(either.Right);
            }

            return !this.IsRight() && !either.IsRight();
        }

        public int CompareTo(Either<TLeft, TRight> other)
        {
            return Comparer<TRight>.Default.Compare(this.Right, other.Right);
        }

        public bool IsRight(Func<TRight, bool> predicate) 
        {
            return predicate(this.Right) && this.isRight;
        }

        public bool IsLeft(Func<TLeft, bool> predicate) 
        {
            return predicate(this.Left) && this.isLeft;
        }

        public bool IsRight() => isRight;
        public bool IsLeft() => isLeft;

        public override int GetHashCode() => !IsRight() ? 1 : Right.GetHashCode();

        public static implicit operator Either<TLeft, TRight>(TLeft left) => new Either<TLeft, TRight>(left);
        public static implicit operator Either<TLeft, TRight>(TRight right) => new Either<TLeft, TRight>(right);

        public static implicit operator Either<TLeft, TRight>(Either<TLeft, NotDefined> either) 
            => new Either<TLeft, TRight>(either.Left);

        public static implicit operator Either<TLeft, TRight>(Either<NotDefined, TRight> either) 
            => new Either<TLeft, TRight>(either.Right);

        public static bool operator ==(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.Equals(second);
        public static bool operator !=(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => !first.Equals(second);
        public static bool operator <(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.CompareTo(second) < 0;
        public static bool operator >(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.CompareTo(second) > 0;
        public static bool operator <=(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.CompareTo(second) <= 0;
        public static bool operator >=(Either<TLeft, TRight> first, Either<TLeft, TRight> second) => first.CompareTo(second) >= 0;
    }
}
