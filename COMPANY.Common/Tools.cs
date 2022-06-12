namespace COMPANY
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// a class that can hold common tools sets between all layers
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// use this method to create an instant of any object that has a private or protected constructor
        /// </summary>
        /// <typeparam name="TInstant">the type of the instant you want to create</typeparam>
        /// <param name="paramsType">the constructor parameters type, must be in order</param>
        /// <param name="paramsValues">the value you want to pass, must be in order</param>
        public static TInstant CreateInstantOf<TInstant>(Type[] paramsType, object[] paramsValues)
        {
            Type dataRequestType = typeof(TInstant);

            ConstructorInfo constructor = dataRequestType.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null, paramsType, null);

            return (TInstant)constructor.Invoke(paramsValues);
        }

        /// <summary>
        /// get the lambda expression for the given property
        /// </summary>
        /// <typeparam name="T">the type of object</typeparam>
        /// <param name="property">the property to orderBy it</param>
        /// <returns>a lambda expression</returns>
        public static LambdaExpression CreateOrderByKeySelector<T>(string property)
        {
            var prop = typeof(T).GetProperty(property,
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.IgnoreCase);

            if (!string.IsNullOrEmpty(prop.Name))
            {
                var parameter = Expression.Parameter(typeof(T), prop.Name);
                var propertyAccess = Expression.MakeMemberAccess(parameter, prop);
                return Expression.Lambda(propertyAccess, parameter);
            }

            return null;
        }
    }
}
