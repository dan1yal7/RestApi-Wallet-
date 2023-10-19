namespace ProjectD.Data.Models
{
    public class Transactions
    { 
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string Wallet { get; set; }
        public bool direction { get; set; }
        public decimal amount { get; set; }
    }
}
