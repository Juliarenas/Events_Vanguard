﻿using EventsVanguards.API.Data;
using EventsVanguards.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsVanguards.API.Controllers
{
    [ApiController]
    [Route("/api/sponsors")]
    public class SponsorsController :ControllerBase
    {
        private readonly DataContext _context;
        public SponsorsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Sponsors.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id) //Programacion asincrona
        {
            var sponsor = await _context.Sponsors.FirstOrDefaultAsync(p => p.Id == id);

            if (sponsor == null)
            {
                return NotFound();
            }
            return Ok(sponsor);//200 (Un ok)
        }

        //Post(Insertar registros)
        [HttpPost]
        public async Task<ActionResult> Post(Sponsor sponsor)
        {
            _context.Add(sponsor);
            await _context.SaveChangesAsync();
            return Ok(sponsor);
        }

        //Put
        [HttpPut]
        public async Task<ActionResult> Put(Sponsor sponsor)
        {
            _context.Update(sponsor);//Update(Busca registro por registro para actualizarlo)
            await _context.SaveChangesAsync();
            return Ok(sponsor);//200(SI GUARDA EL TELEFONO)
        }

        //Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _context.Sponsors.Where(p => p.Id == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {
                return NotFound();//404

            }

            return NoContent();//204(Que lo borre, pero que no me muestre que borro)
        }

    }
}