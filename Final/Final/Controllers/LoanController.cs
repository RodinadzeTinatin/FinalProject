using Data;
using Domain.Final;
using Final.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly UserContext _context;
        public LoanController(UserContext context)
        {
            _context = context;
        }

        #region Post
        [HttpPost("/AddLoan/{userId}")]

        public async Task<IActionResult> AddLoan([FromForm] AddLoanRequest AddLoanRequest)
        {

            var Loan = new Loan();
            {
                Loan.TypeOfLoan = AddLoanRequest.TypeOfLoan;
                Loan.AmountOfLoan = AddLoanRequest.AmountOfLoan;
                Loan.StatusOfLoan = AddLoanRequest.StatusOfLoan;
                Loan.CurrencyOfLoan = AddLoanRequest.CurrencyOfLoan;
                Loan.PeriodOfLoan= AddLoanRequest.PeriodOfLoan;
                Loan.UserId = AddLoanRequest.UserId;

            }

           await _context.Loans.AddAsync(Loan);
            await _context.SaveChangesAsync();

            return Created("/AddLoan/{userId}", Loan);
        }
        #endregion

        #region Get
        [HttpGet("/GetLoan/{Id}")]
        public async Task<IActionResult> GetLoanByUserId(int Id)
        {
            var loan = await _context.Loans.FindAsync(Id);
            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);

        }
        #endregion

        #region Get All
        [HttpGet("/GetLoan/All")]

        public async Task<IEnumerable<Loan>> GetLoans()
        => await _context.Loans.ToListAsync();
        #endregion

        #region DeleteLoanById
        [HttpDelete("/DeleteLoan/{Id}")]

        public async Task<IActionResult> DeleteLoan(int Id)
        {
          var loan=  await _context.Loans.FindAsync(Id);
            if (loan != null && _context.Loans.Find(loan.Id).StatusOfLoan == 0)
            {
                _context.Remove(loan);
                _context.SaveChanges();
                return Ok("This loan was deleted");
            }

            return NotFound("The loan was not found or is not proccessing");
        }
        #endregion

        #region Put
        [HttpPut("/UpdateLoan/{Id}")]
        public async Task<IActionResult> UpdateLoan( int Id,[FromForm] UpdateLoanRequest UpdateLoanRequest)
        {
            var loan =await _context.Loans.FindAsync(Id);
            if (loan != null && _context.Loans.Find(loan.Id).StatusOfLoan == 0)
            {
                loan.TypeOfLoan= UpdateLoanRequest.TypeOfLoan;
                loan.CurrencyOfLoan= UpdateLoanRequest.CurrencyOfLoan;
                loan.AmountOfLoan= UpdateLoanRequest.AmountOfLoan;
                loan.PeriodOfLoan= UpdateLoanRequest.PeriodOfLoan;
                loan.StatusOfLoan= UpdateLoanRequest.StatusOfLoan;
                await _context.SaveChangesAsync();

                return Ok(loan);
            }
            return NotFound("The loan was not found or is not proccessing");
        }
        #endregion

        #region PutStatus
        [HttpPut("/UpdateLoanStatus/{Id}")]
        public async Task<IActionResult> UpdateLoanStatus(int Id, [FromForm] UpdateLoanStatusRequest UpdateLoanStatusRequest)
        {
            var existingloan = await _context.Loans.FindAsync(Id);
            if (existingloan != null)
            {
                existingloan.StatusOfLoan = UpdateLoanStatusRequest.StatusOfLoan;
                await _context.SaveChangesAsync();

                return Ok(existingloan);
            }
            return NotFound("The loan was not found or is not proccessing");
        }
        #endregion

    }
}
