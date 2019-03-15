using System;

namespace Dependencies
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether an instance of the current type can be assigned to an instance of a specified type.
        /// </summary>
        /// <param name="type">The current type.</param>
        /// <param name="c">The type to compare with the current type.</param>
        /// <returns></returns>
        public static bool IsAssignableTo(this Type type, Type c)
        {
            return c.IsAssignableFrom(type);
        }
    }
}
