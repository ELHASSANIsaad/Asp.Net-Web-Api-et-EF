using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {

        private readonly DataContext.DataContext _context;

        private readonly IMapper _mapper;

        public RestaurantRepository(DataContext.DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<Restaurant>> Get()
        {
            var restaurants = await _context.Restaurants.Include(r => r.Cuisines).Include(r => r.Contact).ToListAsync();
            return restaurants;
        }


        public async Task<Restaurant> Get(int id)
        {
            var restaurant = await _context.Restaurants.Include(r => r.Cuisines).Include(r => r.Contact).FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null)
            {
                return null;
            }

            return restaurant;
        }


        public async Task<Restaurant> Post(Restaurant restaurantPayload)
        {
            var newRestaurant = _mapper.Map<Restaurant>(restaurantPayload);
            //_myWorldDbContext.Customer.Add(newCustomer);
            _context.Restaurants.Add(newRestaurant);
            await _context.SaveChangesAsync();
            return newRestaurant;
        }



        public async Task<Restaurant> Put(Restaurant RestaurantPayload)
        {
            var updateRestaurant = _mapper.Map<Restaurant>(RestaurantPayload);
            _context.Restaurants.Update(updateRestaurant);
            await _context.SaveChangesAsync();
            return updateRestaurant;
        }


        public async Task<int> Delete(int id)
        {
            var restaurantToDelete = await _context.Restaurants
            .Include(_ => _.Contact).Where(_ => _.Id == id)
            .Include(_ => _.Cuisines).Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (restaurantToDelete == null)
            {
                return 0;
            }
            _context.Restaurants.Remove(restaurantToDelete);
            await _context.SaveChangesAsync();
            return 1;
        }

       
    }
}
