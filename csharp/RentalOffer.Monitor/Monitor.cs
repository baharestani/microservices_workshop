using System;
using System.Text;

using RabbitMQ.Client;

using RentalOffer.Core;

namespace RentalOffer.Monitor
{

    public class Monitor
    {

        private const string BusName = "bart";

        public static void Main(string[] args)
        {
            const string host = "192.168.0.51";
            Console.Title = "Monitor";
            new Connection(host, BusName).WithOpen(new Monitor().MonitorSolutions);
        }



        private void MonitorSolutions(Connection connection)
        {
            var sub = connection.Subscribe();
            Console.WriteLine(" [*] Waiting for solutions on the {0} bus... To exit press CTRL+C", BusName);

            while (true)
            {
                var e = sub.Next();
                var message = Encoding.UTF8.GetString(e.Body);
                if (message.Contains("Mame 85"))
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.WriteLine(" [x] Received: {0}", message);
            }
        }

    }

}
