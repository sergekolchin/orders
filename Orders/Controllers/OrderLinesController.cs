using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Data;
using Orders.Models;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderLines
        [HttpGet]
        public IEnumerable<OrderLine> GetOrderLine()
        {
            return _context.OrderLines;
        }

        // GET: api/OrderLines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderLine = await _context.OrderLines.FindAsync(id);

            if (orderLine == null)
            {
                return NotFound();
            }

            return Ok(orderLine);
        }

        // PUT: api/OrderLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderLine([FromRoute] int id, [FromBody] OrderLine orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderLines
        [HttpPost]
        public async Task<IActionResult> PostOrderLine([FromBody] OrderLine orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderLines.Add(orderLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderLine", new { id = orderLine.Id }, orderLine);
        }

        // DELETE: api/OrderLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderLine = await _context.OrderLines.FindAsync(id);
            if (orderLine == null)
            {
                return NotFound();
            }

            _context.OrderLines.Remove(orderLine);
            await _context.SaveChangesAsync();

            return Ok(orderLine);
        }

        private bool OrderLineExists(int id)
        {
            return _context.OrderLines.Any(e => e.Id == id);
        }
    }
}