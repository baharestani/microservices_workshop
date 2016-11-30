using System;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RentalOffer.Core;

namespace RentalOffer.SolutionProvider
{
    public class SolutionProvider
    {
        private const string BusName = "bart";

        public static void Main(string[] args)
        {
            const string host = "192.168.0.51";
            Console.Title = "Solution Provider";
            new Connection(host, BusName).WithOpen(new SolutionProvider().SuggustSolutions);
        }

        private void SuggustSolutions(Connection connection)
        {
            var sub = connection.Subscribe();

            while (true)
            {
                var e = sub.Next();
                string json = Encoding.UTF8.GetString(e.Body);
                var need = JsonConvert.DeserializeObject<NeedPacket>(json);

                if (!need.Solutions.Any())
                {
                    need.ProposeSolution(DiscountSolution.Random.GetStructure());
                    need.ProposeSolution(DiscountSolution.Random.GetStructure());
                    need.ProposeSolution(DiscountSolution.Random.GetStructure());

                    string message = need.ToJson();
                    connection.Publish(message);

                    Console.WriteLine("Published solutions.");
                }
                else
                {
                    Console.WriteLine("Skipped.");
                }

                Thread.Sleep(500);
            }
        }

    }
}
