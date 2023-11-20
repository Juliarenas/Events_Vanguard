using EventsVanguards.API.Data;
using EventsVanguards.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsVanguards.API.Controllers
{
    [ApiController]
    [Route("/api/participants")]
    public class ParticipantsController : ControllerBase
    {

        private readonly DataContext _context;

        public ParticipantsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Participants.ToListAsync());

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var organizers = await _context.Organizers.FirstOrDefaultAsync(c => c.Id == id);

            if (organizers == null)
            {
                return NotFound();//404


            }

            return Ok(organizers);//200

        }

       

        [HttpPost]
        public async Task<ActionResult> Post(Organizer organizers)
        {
            _context.Add(organizers);
            await _context.SaveChangesAsync();
            return Ok(organizers);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(Organizer organizers)
        {
            _context.Update(organizers);
            await _context.SaveChangesAsync();
            return Ok(organizers);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Organizers
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            if (filaafectada == 0)
            {


                return NotFound();// 404

            }

            return NoContent();//204   

        }
    }
}
