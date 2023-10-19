using Apache.NMS.ActiveMQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectD.Models;


namespace ProjectD.Conrollers
{
    public class BalanceGet : Controller
    {
            private readonly ApplicationContext _dbContext;

            public BalanceGet(ApplicationContext dbContext)
            {
                _dbContext = dbContext;
            }

            [HttpPost]





            public decimal GetBalance(int userId)
        {
            decimal balance = 0;   

            var userTransactions = _dbContext.Balances
                .Where(t => t.UserId == userId)
                .ToList();

            foreach (var transaction in userTransactions)
            {
                if (transaction.Type.Id == (int)TranTypeEnum.Income)
                {
                    balance += transaction.Amount;
                }
                else if (transaction.Type.Id == (int)TranTypeEnum.Outcome)
                {
                    balance -= transaction.Amount;
                }
            }

            return balance;
        }  

    }
}
