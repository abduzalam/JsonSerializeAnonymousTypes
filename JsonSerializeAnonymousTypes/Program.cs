using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JsonSerializeAnonymousTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var abdul1 = new { field1 = @"\\server\share\path1\path2", field2 = @"c:\temp\test.txt" };
            string serialized = JsonSerializer.Serialize(abdul1);
            Console.WriteLine(serialized);
            var abdul2 = JsonSerializerExtensions.DeserializeAnonymousType(serialized, new { field1 = "", field2 = "" });
            Console.WriteLine($"Path1 = {abdul2.field1}, Path2= {abdul2.field2}");
            Console.ReadLine();
        }

        public static class JsonSerializerExtensions
        {
            public static T? DeserializeAnonymousType<T>(string json, T anonymousTypeObject, JsonSerializerOptions? options = default)
                => JsonSerializer.Deserialize<T>(json, options);

            public static ValueTask<TValue?> DeserializeAnonymousTypeAsync<TValue>(Stream stream, TValue anonymousTypeObject, JsonSerializerOptions? options = default, CancellationToken cancellationToken = default)
                => JsonSerializer.DeserializeAsync<TValue>(stream, options, cancellationToken); // Method to deserialize from a stream added for completeness
        }
    }
}
