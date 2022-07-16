using clubv1._3.Database;
using Clubv1._3.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clubv1._3.Controllers
{
    public class MovieController : Controller
    {
        public ClubDbContext Context { get; set; }

        public MovieController(ClubDbContext context)
        {
            Context = context;
        }
        [Route("Movies")]
        [HttpGet]
        public async Task<ActionResult> Movies()
        {
            try
            {
                return Ok(await Context.Movies.Select(p =>
                new
                {
                    Id = p.Id,
                    Title = p.Title,
                    Producer = p.Producer
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddMovie/{title}/{genre}/{producer}")]
        [HttpGet]
        public async Task<ActionResult> AddMovie(string title, GenreType genre, string producer, DateTime releaseDate)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Insert title.");
            }
            if (string.IsNullOrWhiteSpace(producer) || producer.Length > 50)
            {
                return BadRequest("Insert producers name.");
            }
            try
            {
                Movie movie = new Movie
                {
                    Title = title,
                    Genre = genre,
                    Producer = producer,
                    ReleaseDate = releaseDate
                };

                Context.Movies.Add(movie);
                await Context.SaveChangesAsync();
                return Ok("New movie has been added!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("ChangeMovie")]
        [HttpPut]
        public async Task<ActionResult> ChangeMovie([FromBody] Movie movie)
        {
            try
            {
                Context.Movies.Update(movie);
                await Context.SaveChangesAsync();
                return Ok("Movie information has been changed!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DeleteMovie")]
        [HttpDelete]
        public async Task<ActionResult> DeleteMovie(Guid id)
        {
            try
            {
                var movie = await Context.Movies.FindAsync(id);
                string title = movie.Title;
                Context.Movies.Remove(movie);
                await Context.SaveChangesAsync();
                return Ok($"Movie with title:{title} has been successfully deleted.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
