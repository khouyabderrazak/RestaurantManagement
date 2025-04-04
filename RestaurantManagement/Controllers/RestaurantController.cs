using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Interfaces;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
     
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET: RestaurantController
        public ActionResult Index()
        {
            List<Restaurant> restaurants = _restaurantService.GetAllRestaurants();
            return View(restaurants);
        }

        // GET: RestaurantController/Details/5
        public ActionResult Details(int id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);
            return View(restaurant);
        }

        // GET: RestaurantController/Create
        public ActionResult Create()
        { 
            return View(new Restaurant());
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                TempData["MessageSucess"] = "Restaurant created successfully";
                _restaurantService.AddRestaurant(restaurant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);
            return View(restaurant);
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            try
            {
                _restaurantService.UpdateRestaurant(restaurant);
                TempData["MessageSucess"] = "Restaurant updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);
            return View(restaurant);
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Restaurant restaurant)
        {
            try
            {
                _restaurantService.DeleteRestaurant(id);
                TempData["MessageSucess"] = "Restaurant deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
