using EventsVanguards.API.Data;
using EventsVanguards.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsVanguards.API.Controllers
{
    [ApiController]
    [Route("/api/ meetingStaffs")]
    public class MeetingStaffsController : ControllerBase
    {
        private readonly DataContext _context;
        public MeetingStaffsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.MeetingStaffs.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id) //Programacion asincrona
        {
            var meetingStaff = await _context.MeetingStaffs.FirstOrDefaultAsync(p => p.IdMeeting == id);

            if (meetingStaff == null)
            {
                return NotFound();
            }
            return Ok(meetingStaff);//200 (Un ok)
        }

        //Post(Insertar registros)
        [HttpPost]
        public async Task<ActionResult> Post(MeetingStaff meetingStaff)
        {
            _context.Add(meetingStaff);
            await _context.SaveChangesAsync();
            return Ok(meetingStaff);
        }

        //Put
        [HttpPut]

        public async Task<ActionResult> Put(MeetingStaff meetingStaff)
        {

            _context.Update(meetingStaff);//Update(Busca registro por registro para actualizarlo)
            await _context.SaveChangesAsync();
            return Ok(meetingStaff);//200(SI GUARDA EL TELEFONO)
        }

        //Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _context.MeetingStaffs.Where(p => p.IdMeeting == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {
                return NotFound();//404

            }

            return NoContent();//204(Que lo borre, pero que no me muestre que borro)
        }

    }
}