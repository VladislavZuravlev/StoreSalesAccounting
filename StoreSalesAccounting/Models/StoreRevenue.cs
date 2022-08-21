

namespace StoreSalesAccounting.Models
{
    public class StoreRevenue
    {
        public int StoreRevenueId { get; set; }
        public int StoreCash { get; set; }
        public int StoreNonCash { get; set; }
        public int StoreOnlineCash{ get; set; }
        public int StoreTotalRevenue { get; set; }
        public DateTime Day { get; set; }


    }
}
