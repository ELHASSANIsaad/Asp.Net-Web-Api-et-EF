using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
//using Repository.DataContext;
using Shared.Model;

namespace FormationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        //private readonly DataContext _context;

        //private readonly IMapper _mapper;

        private readonly IRestaurantServices _restaurantServices;

        public RestaurantsController(IRestaurantServices restaurantServices)
        {
            _restaurantServices = restaurantServices;

        }

    [HttpGet]
        public async Task<IActionResult> Get()
        {

            var restaurants = _restaurantServices.Get();
            if (restaurants != null)
            {
                return Ok(restaurants);
            }
            //var restaurants = await _context.Restaurants.Include(r => r.Cuisines).Include(r => r.Contact).ToListAsync();
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var restaurant = _restaurantServices.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Restaurant restaurantPayload)
        {
            var newRestaurant = _restaurantServices.Post(restaurantPayload);
            //_myWorldDbContext.Customer.Add(newCustomer);

            return Created($"/{newRestaurant.Id}", newRestaurant);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(Restaurant restaurant)
        //{
        //    _context.Restaurants.Add(restaurant);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(Get), new { id = restaurant.Id }, restaurant);
        //}

        [HttpPut]
        public async Task<IActionResult> Put(Restaurant RestaurantPayload)
        {
            var updateRestaurant = _restaurantServices.Put(RestaurantPayload);

            return Ok(updateRestaurant);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            if(_restaurantServices.Delete(id) == null)
            {
                return NotFound();
            }else
            {
                return NoContent();
            }


             

            //if ( == 0)
            //{

            //}

            //var restaurantToDelete = await _context.Restaurants
            //.Include(_ => _.Contact).Where(_ => _.Id == id)
            //.Include(_ => _.Cuisines).Where(_ => _.Id == id).FirstOrDefaultAsync();
            //if (restaurantToDelete == null)
            //{
            //    return NotFound();
            //}
            //_context.Restaurants.Remove(restaurantToDelete);
            //await _context.SaveChangesAsync();
            //return NoContent();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, Restaurant restaurant)
        //{
        //    if (id != restaurant.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(restaurant).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RestaurantExists(id))
        //        {
        //            return NotFound();
        //        }

        //        throw;
        //    }

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var restaurant = await _context.Restaurants.FindAsync(id);
        //    if (restaurant == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Restaurants.Remove(restaurant);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool RestaurantExists(int id)
        //{
        //    return _context.Restaurants.Any(e => e.Id == id);
        //}

    }
}
