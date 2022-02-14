using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SetA.Server.Data;
using SetA.Shared.Domain;
using SetA.Server.IRepository;

namespace SetA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ExpensesController(ApplicationDbContext context)
        public ExpensesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Expenses
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
        public async Task<IActionResult> GetExpenses()
        {
            //return await _context.Expenses.ToListAsync();
            var expenses = await _unitOfWork.Expenses.GetAll();
            return Ok(expenses);
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Expense>> GetExpense(int id)
        public async Task<IActionResult> GetExpense(int id)
        {
            //var expense = await _context.Expenses.FindAsync(id);
            var expense = await _unitOfWork.Expenses.Get(q => q.Id == id);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT: api/Expenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            //_context.Entry(expense).State = EntityState.Modified;
            _unitOfWork.Expenses.Update(expense);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ExpenseExists(id))
                if (!await ExpenseExists(id))
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

        // POST: api/Expenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            //_context.Expenses.Add(expense);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Expenses.Insert(expense);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            //var expense = await _context.Expenses.FindAsync(id);
            var expense = await _unitOfWork.Expenses.Get(q => q.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            //_context.Expenses.Remove(expense);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Expenses.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ExpenseExists(int id)
        private async Task<bool> ExpenseExists(int id)
        {
            //return _context.Expenses.Any(e => e.Id == id);
            var expense = await _unitOfWork.Expenses.Get(q => q.Id == id);
            return expense != null;
        }
    }
}
