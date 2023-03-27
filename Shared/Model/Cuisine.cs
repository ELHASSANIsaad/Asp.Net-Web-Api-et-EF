using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Cuisine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Chef { get; set; }
        public string Description { get; set; }

        // Relational link to restaurant many-to-one
        public int? RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }



    }
}
