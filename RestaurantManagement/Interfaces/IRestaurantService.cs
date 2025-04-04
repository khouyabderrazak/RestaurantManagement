using RestaurantManagement.Models;

namespace RestaurantManagement.Interfaces
{
   

    public interface IRestaurantService
    {
        Restaurant GetRestaurantById(int id);
        List<Restaurant> GetAllRestaurants();
        void AddRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int id);

    }

}
