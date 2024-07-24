namespace TradersDiary.Models
{
    public class DealForex : Deal
    {
        public string? Symbol { get; set; }
        public string? Type { get; set; }
        public double? Volume { get; set; }
        public decimal? StopLoss { get; set; }
        public decimal? TakeProfit { get; set; }
        public decimal? Profit { get; set; }
    }
}
