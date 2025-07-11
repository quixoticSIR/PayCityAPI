using Microsoft.AspNetCore.Mvc;
using PayCityAPI.Models;

namespace PayCityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayBillController : ControllerBase
    {
        // In-memory bill store for demo purposes
        private static List<PayBillModel> bills = new List<PayBillModel>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(bills);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bill = bills.FirstOrDefault(b => b.Id == id);
            if (bill == null)
                return NotFound();
            return Ok(bill);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PayBillModel bill)
        {
            bill.Id = bills.Count > 0 ? bills.Max(b => b.Id) + 1 : 1;
            bills.Add(bill);
            return CreatedAtAction(nameof(Get), new { id = bill.Id }, bill);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PayBillModel bill)
        {
            var existing = bills.FirstOrDefault(b => b.Id == id);
            if (existing == null)
                return NotFound();
            existing.BillerName = bill.BillerName;
            existing.Amount = bill.Amount;
            existing.AccountNumber = bill.AccountNumber;
            existing.PaymentDate = bill.PaymentDate;
            existing.UserId = bill.UserId;
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bill = bills.FirstOrDefault(b => b.Id == id);
            if (bill == null)
                return NotFound();
            bills.Remove(bill);
            return NoContent();
        }
    }
} 