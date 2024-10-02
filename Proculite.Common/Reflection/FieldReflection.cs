using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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

            foreach (FieldInfo field in type.GetRuntimeFields().Where(field => !field.IsStatic))
            {
                if (field.IsStatic)
                    continue;
                object value1 = field.GetValue(objectToCompare);
                object value2 = field.GetValue(compareWithObject);

                if (!value1.RecursiveFieldsEquals(value2))
                {
                    // If any of the field values do not match, return false.
                    return false;
                }
            }

            if (type.GetInterfaces().Contains(typeof(IEnumerable)))
            {
                if (!CompareEnumerable(objectToCompare, compareWithObject))
                    return false;
            }

            return true;
        }

        private static bool CompareEnumerable(object objectToCompare, object compareWithObject)
        {
            IEnumerable<object?>? object1 = (objectToCompare as IEnumerable)?.Cast<object?>();
            IEnumerable<object?>? object2 = (compareWithObject as IEnumerable)?.Cast<object?>();

            if (object1 is null)
            {
                // If first object is null, return here.
                return object2 is null;
            }

            if (object2 is null)
            {
                // We already know first object is not null.
                // If first one is not null, but compareWithObject
                // is null, they are not matching.
                return false;
            }

            if (object1.Count() != object2.Count())
            {
                // If IEnumerables are of different size, return false.
                return false;
            }

            for (int i = 0; i < object1.Count(); i++)
            {
                object? element1 = object1.ElementAt(i);
                object? element2 = object2.ElementAt(i);

                if (!element1.RecursiveFieldsEquals(element2))
                    return false;
            }

            return true;
        }
    }
}
