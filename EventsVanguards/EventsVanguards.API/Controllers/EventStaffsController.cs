using EventsVanguards.API.Data;
using EventsVanguards.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsVanguards.API.Controllers
{
    [ApiController]
    [Route("/api/eventStaffs")]
    public class EventStaffsController : ControllerBase
    {

        private readonly DataContext _context;

        public EventStaffsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.EventStaffs.ToListAsync());

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var eventStaff = await _context.EventStaffs.FirstOrDefaultAsync(c => c.Id == id);

            if (eventStaff == null)
            {
                return NotFound();//404


            }

            return Ok(eventStaff);//200

        }

       

        [HttpPost]
        public async Task<ActionResult> Post(EventStaff eventStaff)
        {
            _context.Add(eventStaff);
            await _context.SaveChangesAsync();
            return Ok(eventStaff);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(EventStaff eventStaff)
        {
            _context.Update(eventStaff);
            await _context.SaveChangesAsync();
            return Ok(eventStaff);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.EventStaffs
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
