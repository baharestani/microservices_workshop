using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fastJSON;

namespace RentalOffer.Core
{
    public class DiscountSolution
    {

        //0-1000
        public int OfferValue { get; set; }

        //0-100
        public int Likelihood { get; set; }

        public static DiscountSolution Random
        {
            get
            {
                var r = new Random();

                return new DiscountSolution()
                {
                    OfferValue = r.Next(0, 1000),
                    Likelihood = r.Next(0, 100)
                };
            }
        }


        public IDictionary<string, object> GetStructure()
        {
            // Clumsy, but this seems easier than dealing with
            // the JSON provider's idiosyncrasies to get snake-cased keys.
            IDictionary<string, object> message = new Dictionary<string, object>();
            message.Add("json_class", this.GetType().FullName);
            message.Add("offer_value", this.OfferValue);
            message.Add("likelihood", this.Likelihood);
           // message.Add("solution_name","Sol*****************************tion");

            return message;
        }
    }


}
