using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RecipeController : Controller
  {
    static List<Recipe> recipes = new List<Recipe>() { new Recipe { Id=1, Name="Asd", Description="Basd", Image="", CreatedAt=DateTime.Now} };

    [HttpGet]
    public IActionResult GetAll()
    {
      return Ok(recipes);
    }

    [HttpPost("{ID}")]
    public IActionResult GetByID(int ID) {
      return Ok(recipes.FirstOrDefault(p => p.Id == ID));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Recipe rec)
    {
      if(rec.Id == 0)
        rec.Id = recipes.Count == 0 ? 1 : (recipes.Max(e => e.Id) + 1);

      recipes.Add(rec);
      return Ok(rec.Id);
    }

    [HttpPut]
    public IActionResult Put([FromBody] Recipe rec)
    {
      int index = recipes.FindIndex(e => e.Id == rec.Id);
      if (index >= 0)
      {
        recipes[index] = rec;
        return Ok();
      }
      else
      {
        return BadRequest();
      }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) 
    {
      int removed = recipes.RemoveAll(e => e.Id == id);
      if (removed > 0) return Ok();
      return BadRequest();
    }

  }
}
