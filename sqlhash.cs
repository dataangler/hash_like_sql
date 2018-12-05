
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Foo
{
 
	public static class ConvertTo
    {   

        public static void HashBytes_SHA256(string input, out byte[] output)
        {
            HashAlgorithm algorithm = SHA256.Create();

            output = algorithm.ComputeHash(System.Text.Encoding.Unicode.GetBytes(input));
        }

        public static void HashBytes_SHA256(string input, out long output)
        {
            byte[] bytes;
            HashBytes_SHA256(input, out bytes);
            Array.Reverse(bytes);
            output = BitConverter.ToInt64(bytes, 0);
        }

        public static void HashBytes_SHA256(string input, out Guid output)
        {
            byte[] bytes;
            HashBytes_SHA256(input, out bytes);
            Array.Resize(ref bytes, 16);
            output = new Guid(bytes);
        }
	}
}
