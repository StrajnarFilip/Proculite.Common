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
    }
}
