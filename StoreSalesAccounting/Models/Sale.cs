namespace StoreSalesAccounting.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string PaymentMethod { get; set; }
        public int SaleAmount { get; set; }
        public string? Note { get; set; }
        public DateTime Day { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
