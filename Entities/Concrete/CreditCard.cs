using Core.Entities;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public byte ExpiryMonth { get; set; }
        public short ExpiryYear { get; set; }
        public string CVV { get; set; }
    }
}
