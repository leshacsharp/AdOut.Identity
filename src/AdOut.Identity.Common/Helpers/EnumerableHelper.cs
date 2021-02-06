using System;
using System.Collections.Generic;
using System.Linq;

namespace AdOut.Identity.Common.Helpers
{
    public static class EnumerableHelper
    {
        public static IEnumerable<TEnum> ToEnum<TEnum>(this IEnumerable<string> collection) where TEnum : Enum
        {
            return collection.Select(el => (TEnum)Enum.Parse(typeof(TEnum), el));
        }
    }
}
