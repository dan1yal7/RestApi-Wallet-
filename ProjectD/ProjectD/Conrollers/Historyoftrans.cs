using Microsoft.AspNetCore.Mvc;

using ProjectD.Data.Models;

namespace ProjectD.Conrollers
{
    public class Historyoftrans : Controller
    {
        private readonly ApplicationContext _dbContext;

        public Historyoftrans(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult UserTransactions(Transactions transactions)
        {
            int UserId = 1;
            var history = _dbContext.Transactions
       . Where(t => t.Id == UserId)
         .OrderByDescending(t => t.date) 
          .ToList(); 

            return View(transactions);
        }
    }
}
