using clubv1._3.Database;
using Clubv1._3.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clubv1._3.Controllers
{
    public class SerieController : Controller
    {
        public ClubDbContext Context { get; set; }

        public SerieController(ClubDbContext context)
        {
            Context = context;
        }
        [Route("Serie")]
        [HttpGet]
        public async Task<ActionResult> Serie()
        {
            try
            {
                return Ok(await Context.Series.Select(p =>
                new
                {
                    Id = p.Id,
                    Title = p.Title,
                    Genre = p.Genre,
                    Seasons = p.Seasons,
                    Episodes = p.Episodes,
                    Producer = p.Producer
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddSerie/{title}/{genre}/{seasons}/{episodes}")]
        [HttpPost]
        public async Task<ActionResult> AddSerie(string title, GenreType genre, int seasons, int episodes, DateTime releaseDate)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Insert title.");
            }
            if (episodes <= 0)
            {
                return BadRequest("Insert how many episodes there are in serie.");
            }
            try
            {
                Serie serie = new Serie
                {
                    Title = title,
                    Genre = genre,
                    Seasons = seasons,
                    Episodes = episodes,
                    ReleaseDate = releaseDate
                };
                Context.Series.Add(serie);
                await Context.SaveChangesAsync();
                return Ok("New serie has been added!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("ChangeSerie")]
        [HttpPut]
        public async Task<ActionResult> ChangeSerie([FromBody] Serie serie)
        {
            /* if (serie.Id < 0)
             {
                 return BadRequest("Wrong id.");
             }      */
            try
            {
                Context.Series.Update(serie);
                await Context.SaveChangesAsync();
                return Ok("Successfully changed serie!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DeleteSerie")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSerie(Guid id)
        {
            /*if(id = 0)    //Guid ne moze da koristi <,>,=
            {
                return BadRequest("Wrong id.");
            } */
            try
            {
                var serie = await Context.Series.FindAsync(id);
                string title = serie.Title;
                Context.Series.Remove(serie);
                await Context.SaveChangesAsync();
                return Ok($"Serie with title:{title} has been successfully deleted.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
