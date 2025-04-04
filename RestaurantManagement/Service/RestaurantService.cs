using RestaurantManagement.Data;
using RestaurantManagement.Interfaces;
using RestaurantManagement.Models;

namespace RestaurantManagement.Service
{
    public class RestaurantService(AppDbConntext _db, IFileService _file) : IRestaurantService
    {
       
        public void AddRestaurant(Restaurant restaurant)
        {
            if (restaurant.Image is not null)
            {
               string fileName = _file.loadImage(restaurant.Image);
               restaurant.ImagePath = fileName;
            }
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
        }

        public void DeleteRestaurant(int id)
        {
            var restaurant = _db.Restaurants.FirstOrDefault(res => res.Id == id);

            if (restaurant is not null)
            {
                _db.Restaurants.Remove(restaurant);
                _db.SaveChanges();
            }
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _db.Restaurants.ToList();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _db.Restaurants.FirstOrDefault(res => res.Id == id);
        }


        public void UpdateRestaurant(Restaurant restaurant)
        {
            if (restaurant.Image is not null)
            {
                string fileName = _file.loadImage(restaurant.Image);
                restaurant.ImagePath = fileName;
            }
            _db.Restaurants.Update(restaurant);
            _db.SaveChanges();
        }
    }
}
