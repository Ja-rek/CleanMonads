using System;

namespace Monads.Common
{
    public static class Assert
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
