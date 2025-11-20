using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RecipeController : Controller
  {
    static List<Recipe> recipes = new List<Recipe>();

    [HttpGet]
    public IActionResult GetAll()
    {
      return Ok(recipes);
    }
  }
}
