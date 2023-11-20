using EventsVanguards.API.Data;
using EventsVanguards.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace EventsVanguards.API.Controllers
{
    [ApiController]
    [Route("/api/registers")]
    public class RegistersController : ControllerBase
    {

        private readonly DataContext _context;

        public RegistersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Registers.ToListAsync());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var register = await _context.Registers.FirstOrDefaultAsync(c => c.Id == id);

            if (register == null)
            {
                return NotFound();//404


            }

            return Ok(register);//200

        }

        [HttpPost]
        public async Task<ActionResult> Post(Register register)
        {
            _context.Add(register);
            await _context.SaveChangesAsync();
            return Ok(register);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(Register register)
        {
            _context.Update(register);
            await _context.SaveChangesAsync();
            return Ok(register);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Registers
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