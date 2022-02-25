using System;
using Avensia.inRiver.Developertest;
using inRiver.Remoting;
using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;

namespace Avensia.inRIver.Debugger
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new inRiverContext(RemoteManager.CreateInstance("https://demo.remoting.productmarketingcloud.com", "demoa1@inriver.com", "!Demoa1!"), new ConsoleLogger());

            var extension = new DeveloperListener { Context = context };

            extension.EntityCreated(43);
            extension.EntityUpdated(43, new[] { "ProductIndustry" });

            extension.EntityCreated(280);
            extension.EntityUpdated(280, new[] { "ResourceFileId" });
        }
    }

    public class ConsoleLogger : IExtensionLog
    {
        public void Log(LogLevel level, string message)
        {
            Console.WriteLine($"{level} - {message}");
        }

        public void Log(LogLevel level, string message, Exception ex)
        {
            Console.WriteLine($"{level} - {message}");
            Console.WriteLine();
            Console.WriteLine(ex);
            Console.WriteLine();
        }
    }
}
