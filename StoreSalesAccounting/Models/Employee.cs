using System.ComponentModel.DataAnnotations;

namespace StoreSalesAccounting.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cash { get; set; }
        public int NonCash { get; set; }
        public int OnlineCash { get; set; }
        public int TotalRevenue { get; set; }
        public DateTime Day { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

    }
}
