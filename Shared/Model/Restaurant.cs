using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        // Relational link to Ketchenes  one-to-many
        public List<Cuisine>? Cuisines { get; set; }

        // Relational link to Contact  one-to-many
        public List<Contact>? Contact { get; set; }

    }
}
