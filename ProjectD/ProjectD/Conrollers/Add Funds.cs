using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using ProjectD.Data.Models;
using ProjectD.Models;

namespace ProjectD.Conrollers
{
    [Route("api/[controller]")]
    public class AddFunds : Controller
    {
        protected ApplicationContext ctx;
        public AddFunds(ApplicationContext _ctx)
        {
            ctx = _ctx;
        }
        [HttpPost("CreateWallet")]
        public IActionResult CreateWallet(UserModel model)
        {
            var user = ctx.Users.FirstOrDefault(f => f.Name == model.name && f.Password == model.password);
            if (user is not null)
            {
                var wallet = new Wallet
                {
                    WalletType = "Not identity",
                    Userid = user.Id,
                    Balance = 0m
                };
                ctx.Wallets.Add(wallet);
                ctx.SaveChanges();
                return Ok(new WalletModel { walletId = wallet.WalletId, balance = wallet.Balance });

            }
            else
            {
                return NotFound("User not found");
            }
        }
        [HttpPost("AddBalance")]
        public IActionResult AddBalance(WalletBalanceModel model)
        {
            var user = ctx.Users.FirstOrDefault(f => f.Name == model.name && f.Password == model.password);
            if (user is not null)
            {
                var wallet = ctx.Wallets.FirstOrDefault(f => f.WalletId == model.walletId && f.Userid == user.Id);
                if (wallet is not null)
                {
                    wallet.Balance = wallet.Balance + model.balance;
                    ctx.SaveChanges();
                    return Ok();

                }
                else
                {
                    return BadRequest("Wrong wallet ID");
                }
            }
            else
            {
                return NotFound("User not found");
            }
        }

    }


}