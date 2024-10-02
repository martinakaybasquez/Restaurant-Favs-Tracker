using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestoFavs.Controllers;

[Route("api/[controller]")]
[ApiController]

public class FavoriteController : Controller
{
    private RestoFavsDbContext dbContext = new RestoFavsDbContext();
   
    [HttpGet()]
    public IActionResult GetAllRestos(string? restaurant = null, bool? orderAgain = null)  
    {
        List<Favorite> result = dbContext.Favorites.ToList();
        
        if (restaurant != null)
        {
            result = result.Where(resto => resto.Restaurant.ToLower().Contains(restaurant.ToLower())).ToList();
        }
        if (orderAgain != null)
        {
            result = result.Where(order => order.OrderAgain == orderAgain).ToList();
        }

        return Ok(result);
    }

    [HttpGet("/{id}")]
    public IActionResult GetByFavoriteId(int id)
    {
        Favorite order = dbContext.Favorites.FirstOrDefault(orders => orders.Id == id);

        if (order == null)
        {
            return NotFound("Page not found! :-(");
        }
        else
        {
            return Ok(order);
        }
    }

    [HttpPost()]
    public IActionResult AddFavorites([FromBody] Favorite newOrder)
    {
        newOrder.Id = 0;
        dbContext.Favorites.Add(newOrder);
        dbContext.SaveChanges();
        return Created($"/Favorites/{newOrder.Id}", newOrder);
    }

    [HttpPut()]
    public IActionResult UpdateFavorite([FromBody] Favorite updatedFavorite, int id)
    {
        if (updatedFavorite.Id != id)
        {
            return BadRequest("Ids do not match");
        }

        if (!dbContext.Favorites.Any(order => order.Id == id))
        {
            return NotFound();
        }

        dbContext.Favorites.Update(updatedFavorite);
        dbContext.SaveChanges();
        return Ok(updatedFavorite);
    }

    [HttpDelete("/{id}")]
    public IActionResult DeleteFavorite(int id)
    {
        Favorite order = dbContext.Favorites.FirstOrDefault(order => order.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        else
        {
            dbContext.Favorites.Remove(order);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}