using System;
using System.Linq;

namespace Proculite.Common.Reflection
{
    public static class FieldReflection
    {
        public static bool RecursiveFieldsEquals(
            this object? objectToCompare,
            object? compareWithObject
        )
        {
            if (objectToCompare is null)
            {
                // If first object is null, return here.
                return compareWithObject is null;
            }

            if (compareWithObject is null)
            {
                // We already know first object is not null.
                // If first one is not null, but compareWithObject
                // is null, they are not matching.
                return false;
            }

            if (objectToCompare.GetType() != compareWithObject.GetType())
            {
                return false;
            }

            Type type = objectToCompare.GetType();

            if (type.IsPrimitive)
            {
                return objectToCompare.Equals(compareWithObject);
            }

            if (type == typeof(string))
            {
                return objectToCompare == compareWithObject;
            }

            return false;
        }
    }
}
