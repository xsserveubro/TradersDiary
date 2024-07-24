namespace TradersDiary.Models
{
    public class Deals
    {
        public PaginatedList<DealBO>? BinaryOptDeal { get; set; }
        public PaginatedList<DealForex>? ForexDeal { get; set; }
        public int? CurrentHistory { get; set; }
    }
}
