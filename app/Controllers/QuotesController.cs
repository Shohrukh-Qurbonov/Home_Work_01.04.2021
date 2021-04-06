using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.DataContext;
using Application.Models;

namespace Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuotesDbContext _context;
        public QuotesController(QuotesDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Select()
        {
            var quotes = await _context.Quotes.ToListAsync();
            return Ok(quotes);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> SelectById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var quote = await _context.Quotes.FirstOrDefaultAsync(p => p.Id == id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Quotes quote)
        {
            if (quote == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();
            return Ok(quote);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Quotes quote)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var quotes = await _context.Quotes.FindAsync(id);
            if (quotes == null)
            {
                return NotFound();
            }
            quotes.Author = quote.Author;
            quotes.Text = quote.Text;
            quotes.InsertDate = quote.InsertDate;

            var isUpdated = await _context.SaveChangesAsync();
            if (isUpdated == 0)
            {
                return BadRequest("Edit quote was failed!");
            }
            return Ok(quotes);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            _context.Quotes.Remove(quote);
            var deleted = await _context.SaveChangesAsync();
            if (deleted == 0)
            {
                return BadRequest();
            }
            return Ok(quote);
        }
        [NonAction]
        private async Task AutoRemove()
        {
            foreach (var quote in await _context.Quotes.ToListAsync<Quotes>())
            {
                if (quote.InsertDate.Month != DateTime.Now.Month)
                {
                    _context.Quotes.Remove(quote);
                }
            }
        }
    }
}