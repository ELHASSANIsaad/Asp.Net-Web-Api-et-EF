using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Gsm { get; set; }
        public string Address { get; set; }
        public string email { get; set; }


        // Relational link to Restaurant one-to-many
        public int? RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
