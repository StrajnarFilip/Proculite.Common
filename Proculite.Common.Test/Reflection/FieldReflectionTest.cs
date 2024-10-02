using System.Drawing;
using Proculite.Common.Reflection;

namespace Proculite.Common.Test.Reflection
{
    public class FieldReflectionTest
    {
        [Fact]
        public void SameByte_EqualsTrue()
        {
            byte a = 1;
            byte b = 1;
            Assert.True(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void DifferentByte_EqualsFalse()
        {
            byte a = 1;
            byte b = 2;
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void SameSByte_EqualsTrue()
        {
            sbyte a = 1;
            sbyte b = 1;
            Assert.True(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void DifferentSByte_EqualsFalse()
        {
            sbyte a = 1;
            sbyte b = 2;
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void SameInt16_EqualsTrue()
        {
            short a = 1;
            short b = 1;
            Assert.True(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void DifferentInt16_EqualsFalse()
        {
            short a = 1;
            short b = 2;
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void SameUInt16_EqualsTrue()
        {
            ushort a = 1;
            ushort b = 1;
            Assert.True(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void DifferentUInt16_EqualsFalse()
        {
            ushort a = 1;
            ushort b = 2;
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void SameInt32_EqualsTrue()
        {
            int a = 1;
            int b = 1;
            Assert.True(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void DifferentInt32_EqualsFalse()
        {
            int a = 1;
            int b = 2;
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void SameString_EqualsTrue()
        {
            string a = "example";
            string b = "example";
            Assert.True(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void DifferentString_EqualsFalse()
        {
            string a = "example";
            string b = "exampleDifferent";
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void SameChar_EqualsTrue()
        {
            char a = 'a';
            char b = 'a';
            Assert.True(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void DifferentChar_EqualsFalse()
        {
            char a = 'a';
            char b = 'b';
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void SameTypeAndValue_EqualsTrue()
        {
            int a = 2;
            int b = 2;
            Assert.True(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void DifferentTypeSameValue_EqualsFalse()
        {
            int a = 1;
            short b = 1;
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void TwoNulls_EqualsTrue()
        {
            string? a = null;
            string? b = null;
            Assert.True(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void FirstNullSecondNotNull_EqualsFalse()
        {
            string? a = null;
            string? b = "ok";
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void FirstNotNullSecondNull_EqualsFalse()
        {
            string? a = "ok";
            string? b = null;
            Assert.False(a.RecursiveFieldsEquals(b));
        }

        [Fact]
        public void SameDateTime_EqualsTrue()
        {
            DateTime one = DateTime.MinValue;
            DateTime two = DateTime.MinValue;
            Assert.True(one.RecursiveFieldsEquals(two));
        }

        [Fact]
        public void DifferentDateTime_EqualsFalse()
        {
            DateTime one = DateTime.MinValue;
            DateTime two = DateTime.MaxValue;
            Assert.False(one.RecursiveFieldsEquals(two));
        }

        [Fact]
        public void SameArray_EqualsTrue()
        {
            int[] array1 = [1, 2, 3, 4];
            int[] array2 = [1, 2, 3, 4];
            Assert.True(array1.RecursiveFieldsEquals(array2));
        }

        [Fact]
        public void DifferentArray_EqualsFalse()
        {
            int[] array1 = [1, 2, 3, 4];
            int[] array2 = [1, 2, 6, 4];
            Assert.False(array1.RecursiveFieldsEquals(array2));
        }

        [Fact]
        public void SameNullableArray_EqualsTrue()
        {
            string?[] array1 = [null, "one", null, "two"];
            string?[] array2 = [null, "one", null, "two"];
            Assert.True(array1.RecursiveFieldsEquals(array2));
        }

        [Fact]
        public void DifferentNullableArray_EqualsFalse()
        {
            string?[] array1 = [null, "one", null, "two"];
            string?[] array2 = [null, "one", "three", "two"];
            Assert.False(array1.RecursiveFieldsEquals(array2));
        }

        [Fact]
        public void SameDictionary_EqualsTrue()
        {
            Dictionary<string, string> dictionary1 =
                new() { { "one", "two" }, { "three", "four" } };
            Dictionary<string, string> dictionary2 =
                new() { { "one", "two" }, { "three", "four" } };

            Assert.True(dictionary1.RecursiveFieldsEquals(dictionary2));
        }

        [Fact]
        public void DifferentDictionaryKey_EqualsFalse()
        {
            Dictionary<string, string> dictionary1 =
                new() { { "one", "two" }, { "three", "four" } };
            Dictionary<string, string> dictionary2 =
                new() { { "one", "two" }, { "seven", "four" } };

            Assert.False(dictionary1.RecursiveFieldsEquals(dictionary2));
        }

        [Fact]
        public void DifferentDictionaryValue_EqualsFalse()
        {
            Dictionary<string, string> dictionary1 =
                new() { { "one", "two" }, { "three", "four" } };
            Dictionary<string, string> dictionary2 =
                new() { { "one", "two" }, { "three", "seven" } };

            Assert.False(dictionary1.RecursiveFieldsEquals(dictionary2));
        }
    }
}
