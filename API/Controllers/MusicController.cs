using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  //[Route("api/[controller]")]
  [Route("[controller]")]
  [ApiController]
  public class MusicController : ControllerBase
  {
    private readonly DBContext _dbContext;

    public MusicController(DBContext dbContext)
    {
      _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Music>>> GetMusics()
    {
      if (_dbContext == null)
      {
        return NotFound();
      }

      return await _dbContext.Musics.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Music>> GetMusic(int id)
    {
      if (_dbContext == null)
      {
        return NotFound();
      }

      var music = await _dbContext.Musics.FindAsync(id);

      if(music == null)
      {
        return NotFound();
      }

      return music;
    }

    [HttpPut]
    public async Task<ActionResult<Music>> AddMusic([FromBody]Music music)
    {
      if (music == null)
      {
        return NotFound();
      }

      _dbContext.Musics.Add(music);

      await _dbContext.SaveChangesAsync();

      return music;
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<Music>> UpdateMusic([FromRoute] int id, [FromBody] Music music)
    {
      if (music.Id != id)
      {
        return BadRequest();
      }

      _dbContext.Entry(music).State = EntityState.Modified;

      await _dbContext.SaveChangesAsync();

      var updatedMovie = _dbContext.Musics.FirstOrDefaultAsync(x => x.Id == id);

      return music;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMusic(int id)
    {
      var music = await _dbContext.Musics.FindAsync(id);

      if(music == null) { return NotFound(); }

      _dbContext.Musics.Remove(music);

      await _dbContext.SaveChangesAsync(true);

      return NoContent();
    }

    //public IActionResult Index()
    //{
    //  return View();
    //}
  }
}
