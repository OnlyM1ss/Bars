using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bars_Server.Data;
using Bars_Server.Models;

namespace Bars_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly Bars_ServerContext _context;

        public ContractsController(Bars_ServerContext context)
        {
            _context = context;
        }

        // GET: api/Contracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContract()
        {
            return await _context.Contract.ToListAsync();
        }

        // GET: api/Contracts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetContract(int id)
        {
            var contract = await _context.Contract.FindAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            return contract;
        }

        // PUT: api/Contracts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContract(int id, Contract contract)
        {
            if (id != contract.Id)
            {
                return BadRequest();
            }

            _context.Entry(contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(id))
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

        // POST: api/Contracts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contract>> PostContract(Contract contract)
        {
            _context.Contract.Add(contract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContract", new { id = contract.Id }, contract);
        }

        // DELETE: api/Contracts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contract>> DeleteContract(int id)
        {
            var contract = await _context.Contract.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();

            return contract;
        }

        private bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.Id == id);
        }
    }
}
