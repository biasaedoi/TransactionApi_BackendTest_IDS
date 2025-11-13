using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionApi.Data;

namespace TransactionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly AppDbContext _db;
        public DataController(AppDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _db.Transactions
                .AsNoTracking()
                .OrderBy(t => t.Id)
                .ToListAsync();

            var data = transactions.Select(t => new {
                id = t.Id,
                productID = t.ProductID,
                productName = t.ProductName,
                amount = t.Amount.ToString("0"),
                customerName = t.CustomerName,
                status = t.Status,
                transactionDate = t.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss"),
                createBy = t.CreateBy,
                createOn = t.CreateOn.ToString("yyyy-MM-dd HH:mm:ss")
            });

            var statuses = await _db.Statuses
                .AsNoTracking()
                .OrderBy(s => s.Id)
                .Select(s => new { id = s.Id, name = s.Name })
                .ToListAsync();

            var response = new
            {
                data = data,
                status = statuses
            };

            return Ok(response);
        }
    }
}
