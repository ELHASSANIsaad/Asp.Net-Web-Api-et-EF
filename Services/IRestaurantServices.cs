using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRestaurantServices
    {
        public Task<List<Restaurant>> Get();

        public Task<Restaurant> Get(int id);

        public Task<Restaurant> Post(Restaurant restaurantPayload);

        public Task<Restaurant> Put(Restaurant RestaurantPayload);

        public Task<int> Delete(int id);
    }
}
