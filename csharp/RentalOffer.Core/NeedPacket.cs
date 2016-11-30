using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using fastJSON;

namespace RentalOffer.Core
{

    public class NeedPacket
    {

        public const string NEED = "car_rental_offer";

        private List<object> solutions = new List<object>();
        private string collationId = Guid.NewGuid().ToString("D");

        public List<object> Solutions
        {
            get { return solutions; }
            set { solutions = value; }
        }

        public string CollationId
        {
            get { return this.collationId; }
            set { this.collationId = value; }
        }

        public string MembershipId { get; set; }

        public NeedPacket() { }

        public string ToJson()
        {
            // Clumsy, but this seems easier than dealing with
            // the JSON provider's idiosyncrasies to get snake-cased keys.
            IDictionary<string, object> message = new Dictionary<string, object>();
            message.Add("origin", "Mame 85!");
            message.Add("json_class", this.GetType().FullName);
            message.Add("need", NEED);
            message.Add("solutions", solutions);
            message.Add("collation_id", this.CollationId);
            message.Add("membership_id", string.Empty);

            return JSON.ToJSON(message);
        }

        public void ProposeSolution(object solution)
        {
            solutions.Add(solution);
        }

    }

}

