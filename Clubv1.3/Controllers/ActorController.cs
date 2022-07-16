using clubv1._3.Database;
using Clubv1._3.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clubv1._3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : Controller
    {
        public ClubDbContext Context { get; set; }

        public ActorController(ClubDbContext context)
        {
            Context = context;
        }
        [Route("Actors")]
        [HttpGet]
        public async Task<ActionResult> Actors()
        {
            try
            {
                return Ok(await Context.Actors.Select(p =>
                new
                {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.Birthdate,
                    DeceaseDate = p.DeceaseDate
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [EnableCors("CORS")]
        [Route("AddActor")]
        [HttpPost]
        public async Task<ActionResult> AddActor([FromBody] Actor actor)
        {
            if (string.IsNullOrWhiteSpace(actor.Name) || actor.Name.Length > 50)
            {
                return BadRequest("Wrong name!");
            }
            try
            {
                Context.Actors.Add(actor);
                await Context.SaveChangesAsync();
                return Ok($"Actor has been added with Id: {actor.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("ChangeActor")]
        [HttpPut]
        public async Task<ActionResult> ChangeActor([FromBody] Actor actor)
        {
            try
            {
                Context.Actors.Update(actor);
                await Context.SaveChangesAsync();
                return Ok($"Successfully changed actor with ID: {actor.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DeleteActor/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var actor = await Context.Actors.FindAsync(id);
                string name = actor.Name;
                Context.Actors.Remove(actor);
                await Context.SaveChangesAsync();
                return Ok($"Successfully deleted actor with name:{name}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}