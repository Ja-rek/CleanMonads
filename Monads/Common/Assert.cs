using System;

namespace Monads
{
    internal static class Assert
    {
        public static void ArgumentIsNotNull<TValue>(TValue value, string name = null)
        {
            if (value == null) 
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
