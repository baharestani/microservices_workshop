using System;
using System.Threading;
using RabbitMQ.Client;

using RentalOffer.Core;

namespace RentalOffer.Need {

    public class Need {

        private readonly string busName;

        public static void Main(string[] args) {
            string host = "192.168.0.51";
            string busName = "bart";
            Console.Title = "Need";
            new Connection(host, busName).WithOpen(new Need(busName).PublishNeed);
        }

        public Need(string busName) {
            this.busName = busName;
        }

        private void PublishNeed(Connection connection) {
           // while (true)
            {
                string message = new NeedPacket().ToJson();
                connection.Publish(message);
                Console.WriteLine(" [x] Published {0} on the {1} bus", message, busName);
              //  Thread.Sleep(5000);
            }
        }

    }

}
