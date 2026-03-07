namespace Backend.Models
{
    public enum TransactionType
    {
        Income,
        Expense
    }
    
    public class Transaction
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string Name { get; set; } = "";
        public int Amount { get; set; }
        public TransactionType Type { get; set; }
    }
}