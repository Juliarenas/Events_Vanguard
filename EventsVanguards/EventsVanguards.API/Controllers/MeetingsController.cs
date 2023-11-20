using EventsVanguards.API.Data;
using EventsVanguards.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsVanguards.API.Controllers
{
    [ApiController]

    
    [Route("/api/meetings")]
    public class MeetingsController :ControllerBase
    {
        private readonly DataContext _context;
        public MeetingsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Meetings.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id) //Programacion asincrona
        {
            var meeting = await _context.Meetings.FirstOrDefaultAsync(p => p.Id == id);

            if (meeting == null)
            {
                return NotFound();
            }
            return Ok(meeting);//200 (Un ok)
        }

        //Post(Insertar registros)
        [HttpPost]
              public async Task<ActionResult> Post(Meeting meeting)
        {
            _context.Add(meeting);
            await _context.SaveChangesAsync();
            return Ok(meeting);
        }

        //Put
        [HttpPut]

        public async Task<ActionResult> Put(Meeting meeting)
        {

            _context.Update(meeting);//Update(Busca registro por registro para actualizarlo)
            await _context.SaveChangesAsync();
            return Ok(meeting);//200(SI GUARDA EL TELEFONO)
        }

        //Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _context.Meetings.Where(p => p.Id == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {
                return NotFound();//404

            }

            return NoContent();//204(Que lo borre, pero que no me muestre que borro)
        }

    }
}