using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImafanSolution.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImafanSolution.Extensions.Tests
{
    [TestClass()]
    public class StreamExtensionsTests
    {
        [TestMethod()]
        public void ReadEntireStreamTest()
        {
            var expected = new byte[] { 0x01, 0x02 };
            var testStream = new MemoryStream(expected);
            var actual = testStream.ReadEntireStreamToBytes();
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}