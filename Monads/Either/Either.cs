using System;
using System.Collections.Generic;
using Monads.Utils;

namespace Monads
{
    [Serializable]
    public partial class Either<TLeft, TRight> : 
        IComparable<Either<TLeft, TRight>>
    {
        private readonly bool isRight;
        private readonly bool isLeft;
        private TLeft left;
        private TRight right;

        internal Either(TLeft left, TRight right, bool isRight, bool isLeft)
        {
            this.isRight = isRight;
            this.isLeft = isLeft;
            this.left = left;
            this.right = right;
        }

        internal Either(TRight right) : this(default, right, true, false) 
        { 
            Assert.ArgumentIsNotNull(right, nameof(right));
        }

        internal Either(TLeft left) : this(left, default, false, true) 
        { 
            Assert.ArgumentIsNotNull(left, nameof(left));
        }

        internal TLeft ForceLeft 
        { 
            get => this.left; 
        }

        internal TRight ForceRight
        { 
            get => this.right; 
        }

        public bool IsRight(Func<TRight, bool> predicate) 
        {
            return predicate(this.right) && this.isRight;
        }

        public bool IsLeft(Func<TLeft, bool> predicate) 
        {
            return predicate(this.left) && this.isLeft;
        }

        public bool IsRight() 
        {
            return this.isRight;
        }

        public bool IsLeft() 
        {
            return this.isLeft;
        }

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
                    return this.right.Equals(right);

                default:
                    return false;
            }
        }

        public bool Equals<TAnyLeft, TAnyRight>(Either<TAnyLeft, TAnyRight> either) 
        {
            if (this.isRight && either.IsRight()) 
            {
                return this.right.Equals(either.right);
            }

            return !this.IsRight() && !either.IsRight();
        }

        public int CompareTo(Either<TLeft, TRight> other)
        {
            return Comparer<TRight>.Default.Compare(this.right, other.right);
        }

        public override int GetHashCode() 
        {
            return !IsRight() ? 1 : right.GetHashCode();
        }
    }
}
