using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDatosDemo
{
    class Program
    {
        private static string serviceUrl =
            "YourServiceURL";
        static void Main(string[] args)
        {
            var serializer =
                new NewtonsoftSerializer();
            ICacheClient client =
                new StackExchangeRedisCacheClient(serializer,
                serviceUrl);

            var person = new
            {
                Name = "Héctor Pérez",
                Subjects = new List<string>{
                "Español",
                "Matemáticas"
            }
            };

            client.Add("People", person, 
                DateTimeOffset.Now.AddMinutes(10));

            //ConnectionMultiplexer connection =
            //    ConnectionMultiplexer.Connect(serviceUrl);

            //IDatabase cache = connection.GetDatabase();

            //string cacheCommand = "PING";
            //Console.WriteLine(cache.Execute(cacheCommand).ToString());

            //cache.StringSet("Message", "Hola!");

            //Console.WriteLine(cache.StringGet("Message"));


            //cache.ListLeftPush("listdemo", new RedisValue[]
            //{
            //    "hola",
            //    "adiós",
            //    "Lista de Redis"
            //});

            //cache.SetAdd("setdemo", "cachedemo");

            //var setResult = cache.SetPop("setdemo");
            //Console.WriteLine(setResult);

            //connection.Dispose();
            //Console.ReadLine();
        }

    }
}
