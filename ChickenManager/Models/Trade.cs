namespace ChickenManager.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public User TradeInitiator { get; set; }
        public User TradeRecipient { get; set; }
        public DateTime TradeInitiateDate { get; set; }
        public TradeStatus TradeStatus { get; set; }
    }
}
