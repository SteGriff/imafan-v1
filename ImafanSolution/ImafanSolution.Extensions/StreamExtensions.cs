using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImafanSolution.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] ReadEntireStreamToBytes(this Stream theStream)
        {
            int count = (int)theStream.Length;
            var theBytes = new byte[count];
            theStream.Read(theBytes, 0, count);
            return theBytes;
        }

        public static string ReadEntireStreamToString(this Stream theStream)
        {
            int count = (int)theStream.Length;
            var theBytes = new byte[count];
            theStream.Read(theBytes, 0, count);

            var theString = Encoding.UTF8.GetString(theBytes);
            return theString;
        }
    }
}
