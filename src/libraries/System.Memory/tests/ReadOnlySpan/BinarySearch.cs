// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;
using System.Runtime.CompilerServices;

namespace System.SpanTests
{
    public static partial class ReadOnlySpanTests
    {
        [Theory]
        [InlineData(new uint[] { 1u, 2u, 4u, 5u }, 0u, -1)]
        [InlineData(new uint[] { 1u, 2u, 4u, 5u }, 1u, 0)]
        [InlineData(new uint[] { 1u, 2u, 4u, 5u }, 2u, 1)]
        [InlineData(new uint[] { 1u, 2u, 4u, 5u }, 3u, -3)]
        [InlineData(new uint[] { 1u, 2u, 4u, 5u }, 4u, 2)]
        [InlineData(new uint[] { 1u, 2u, 4u, 5u }, 5u, 3)]
        [InlineData(new uint[] { 1u, 2u, 4u, 5u }, 6u, -5)]
        public static void BinarySearch_UInt(uint[] a, uint value, int expectedIndex)
        {
            var span = new ReadOnlySpan<uint>(a);

            var index = span.BinarySearch(value);

            Assert.Equal(expectedIndex, index);
        }

        [Theory]
        [InlineData(new double[] { 1, 2, 4, 5 }, 0, -1)]
        [InlineData(new double[] { 1, 2, 4, 5 }, 1, 0)]
        [InlineData(new double[] { 1, 2, 4, 5 }, 2, 1)]
        [InlineData(new double[] { 1, 2, 4, 5 }, 3, -3)]
        [InlineData(new double[] { 1, 2, 4, 5 }, 4, 2)]
        [InlineData(new double[] { 1, 2, 4, 5 }, 5, 3)]
        [InlineData(new double[] { 1, 2, 4, 5 }, 6, -5)]
        public static void BinarySearch_Double(double[] a, double value, int expectedIndex)
        {
            var span = new ReadOnlySpan<double>(a);

            var index = span.BinarySearch(value);

            Assert.Equal(expectedIndex, index);
        }

        [Theory]
        [InlineData(new string[] { "b", "c", "d", "e" }, "a", -1)]
        [InlineData(new string[] { "b", "c", "d", "e" }, "b", 0)]
        [InlineData(new string[] { "b", "c", "d", "e" }, "c", 1)]
        [InlineData(new string[] { "b", "c", "d", "e" }, "d", 2)]
        [InlineData(new string[] { "b", "c", "d", "e" }, "e", 3)]
        [InlineData(new string[] { "b", "c", "d", "e" }, "f", -5)]
        public static void BinarySearch_String(string[] a, string value, int expectedIndex)
        {
            var span = new ReadOnlySpan<string>(a);

            var index = span.BinarySearch(value);

            Assert.Equal(expectedIndex, index);
        }

        //[Fact]
        //public static void AsBytesContainsReferences()
        //{
        //    ReadOnlySpan<StructWithReferences> span = new ReadOnlySpan<StructWithReferences>(Array.Empty<StructWithReferences>());
        //    TestHelpers.AssertThrows<ArgumentException, StructWithReferences>(span, (_span) => _span.AsBytes().DontBox());
        //}
    }
}
