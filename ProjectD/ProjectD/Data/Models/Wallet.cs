namespace ProjectD.Data.Models
{
    public class Wallet
    { 
        public int WalletId { get; set; }
        public string WalletType { get; set; }
        public int Userid { get; set; } 
        public decimal Balance { get; set; }
    }
}
