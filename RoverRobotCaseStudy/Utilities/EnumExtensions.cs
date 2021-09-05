using System;

namespace RoverRobotCaseStudy.Utilities
{
    public static class EnumExtensions
    {
       public static T TryConvertToEnum<T>(this string instance)
          where T : Enum
        {
            var enumType = typeof(T);
            T result;
            var success = Enum.IsDefined(enumType, instance);
            if (success)
            {
                result = (T)Enum.Parse(typeof(T), instance);
            }
            else
            {
                result = default(T);
            }
            return result;
        }
    }
}
