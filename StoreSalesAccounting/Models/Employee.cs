using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StoreSalesAccounting.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Product { get; set; }
        public int EmployeeCash { get; set; }
        public int EmployeeNonCash { get; set; }
        public int EmployeeOnlineCash { get; set; }
        public int EmployeeTotalRevenue { get; set; }
        public DateTime EmployeeDay { get; set; }
   
    }
}
