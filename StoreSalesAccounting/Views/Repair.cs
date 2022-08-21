namespace CashFlowWeb.Models
{
    public class Repair
    {
        public int RepairId { get; set; }
        public DateTime RepairStartDate { get; set; }
        public string ReceivingEmployee { get; set; }
        public string Master { get; set; }
        public string ClientName { get; set; }
        public int ClientNumber { get; set; }
        public string MusicalInstrument { get; set; }
        public string TechnicalTask { get; set; }
        public bool GuitarCase { get; set; }
        public DateTime RepairEndDate { get; set; }
        public bool GiveAway { get; set; }
    }
}
