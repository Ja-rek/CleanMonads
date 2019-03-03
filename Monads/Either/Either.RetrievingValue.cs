using System;
using Monads.Utils;

namespace Monads
{
    public partial class Either<TLeft, TRight>
    {
        public TResutl Adjust<TResutl>(Func<TLeft, TResutl> left, Func<TRight, TResutl> right)
        {
            if (this.IsRight())
            {
                Assert.ArgumentIsNotNull(right(this.right), nameof(right));

                return right(this.right);
            }

            Assert.ArgumentIsNotNull(left(this.left), nameof(left));

            return left(this.left);
        }

        public void Do(Action<TLeft> left, Action<TRight> right)
        {
            this.DoWhenLeft(left);
            this.DoWhenRight(right);
        }

        public void DoWhenRight(Action<TRight> right)
        {
            if (this.IsRight()) right(this.right);
        }

        public void DoWhenLeft(Action<TLeft> left)
        {
            if (this.IsLeft()) left(this.left);
        }

        public TRight RightOr(Func<TLeft, TRight>  alternative)
        { 
            return this.RightOr(alternative(this.left));
        }

        public TRight RightOr(TRight  alternative)
        { 
            return this.Adjust(left => alternative, right => right);
        }
    }
}
