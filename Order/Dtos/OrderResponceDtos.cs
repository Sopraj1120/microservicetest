namespace Order.Dtos
{
    public class OrderResponceDtos : OrderRequestDtos
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
