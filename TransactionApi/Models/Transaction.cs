namespace TransactionApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public string CustomerName { get; set; }
        public int Status { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
