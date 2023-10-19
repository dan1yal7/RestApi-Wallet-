using Apache.NMS.ActiveMQ;

namespace ProjectD.Data.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public  Trantype Type { get; set; }

    }
}
