using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRestaurantRepository
    {
        public Task<List<Restaurant>> Get();

        public Task<Restaurant> Get(int id);

        public Task<Restaurant> Post(Restaurant restaurantPayload);

        public Task<Restaurant> Put(Restaurant RestaurantPayload);

        public Task<int> Delete(int id);

    }
}
