using Mapster;
using Order.Dtos;
namespace Order.Mapper
{
    public class OrderMapping
    {
        public static void OrderMappings()
        {
            TypeAdapterConfig<Order.Entity.Order, OrderResponceDtos>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.ProductId, src => src.ProductId)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.TotalPrice, src => src.Quantity*src.Product.Price)
                .Map(dest => dest.OrderDate, src => src.OrderDate);
        }
    }
}
