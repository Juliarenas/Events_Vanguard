using EventsVanguards.API.Data;
using EventsVanguards.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsVanguards.API.Controllers
{
    [ApiController]
    [Route("/api/meetingSponsors")]
    public class MeetingSponsorsController : ControllerBase
    {

        private readonly DataContext _context;
        public MeetingSponsorsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.MeetingSponsors.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id) //Programacion asincrona
        {
            var meetingSponsor = await _context.MeetingSponsors.FirstOrDefaultAsync(p => p.IdMeeting == id);

            if (meetingSponsor == null)
            {
                return NotFound();
            }
            return Ok(meetingSponsor);//200 (Un ok)
        }

        //Post(Insertar registros)
        [HttpPost]
        public async Task<ActionResult> Post(MeetingSponsor meetingSponsor)
        {
            _context.Add(meetingSponsor);
            await _context.SaveChangesAsync();
            return Ok(meetingSponsor);
        }

        //Put
        [HttpPut]

        public async Task<ActionResult> Put(MeetingSponsor meetingSponsor)
        {

            _context.Update(meetingSponsor);//Update(Busca registro por registro para actualizarlo)
            await _context.SaveChangesAsync();
            return Ok(meetingSponsor);//200(SI GUARDA EL TELEFONO)
        }

        //Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _context.MeetingSponsors.Where(p => p.IdMeeting == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {
                return NotFound();//404

            }

            return NoContent();//204(Que lo borre, pero que no me muestre que borro)
        }

    }
}