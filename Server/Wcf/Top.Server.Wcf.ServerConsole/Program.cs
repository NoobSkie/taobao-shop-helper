using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Top.Server.TaobaoInterface;

namespace Top.Server.Wcf.ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ServiceHost> hosts = new List<ServiceHost>();
            ServiceHost hostSql = new ServiceHost(typeof(ShopApiFacade));
            hosts.Add(hostSql);
            hosts.ForEach(host => host.Open());

            Console.Title = "WCF服务";
            Console.WriteLine("Started...");
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key == ConsoleKey.C || key.Key == ConsoleKey.R)
            {
                Console.Clear();
                Console.WriteLine("Started...");
                key = Console.ReadKey();
            }
            hosts.ForEach(host => host.Close());
        }
    }
}
