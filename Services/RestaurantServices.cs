using Repository;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RestaurantServices : IRestaurantServices
    {

        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantServices(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Task<int> Delete(int id)
        {
            return _restaurantRepository.Delete(id);
        }

        public Task<List<Restaurant>> Get()
        {
            return _restaurantRepository.Get();
        }

        public Task<Restaurant> Get(int id)
        {
            return _restaurantRepository.Get(id);
        }

        public Task<Restaurant> Post(Restaurant restaurantPayload)
        {
            return _restaurantRepository.Post(restaurantPayload);
        }

        public Task<Restaurant> Put(Restaurant RestaurantPayload)
        {
            return _restaurantRepository.Put(RestaurantPayload);
        }
    }
}
