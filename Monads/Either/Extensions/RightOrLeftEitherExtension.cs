namespace Monads
{
    public static class RightOrLeftEitherExtension
    {
        public static TData RightOrLeft<TData>(this Either<TData, TData> source) 
        { 
            return source.IsRight() ? source.ForceRight : source.ForceLeft ;
        }
    }
}
