using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payslip.Data;
using Payslip.Models;

namespace Payslip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalarySlipController : ControllerBase
    {
        private readonly SalarySlipContext _context;

        public SalarySlipController(SalarySlipContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalarySlip>>> GetSalarySlips()
        {
            return await _context.SalarySlips.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<SalarySlip>> PostSalarySlip(SalarySlip salarySlip)
        {
            _context.SalarySlips.Add(salarySlip);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalarySlips), new { id = salarySlip.Id }, salarySlip);
        }
    }
}
