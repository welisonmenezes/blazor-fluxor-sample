using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Style.Shared
{
    public static class ConvertType
    {
        public static object ChangeType(object value, Type type)
        {
            if (value == null && Nullable.GetUnderlyingType(type) != null)
            {
                return value;
            }

            if ((Nullable.GetUnderlyingType(type) ?? type) == typeof(Guid) && value is string)
            {
                return Guid.Parse((string)value);
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                Type itemType = type.GetGenericArguments()[0];
                var enumerable = value as IEnumerable<object>;

                if (enumerable != null)
                {
                    return enumerable.AsQueryable().Cast(itemType);
                }
            }

            return value is IConvertible ? Convert.ChangeType(value, Nullable.GetUnderlyingType(type) ?? type) : value;
        }
    }

    public static class RandonValues
    {
        public static int GetRandonInt()
        {
            Random rnd = new Random();
            return rnd.Next();
        }
    }
}