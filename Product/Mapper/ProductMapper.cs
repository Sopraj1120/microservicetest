using Mapster;
using Product.Dtos.ResponceDtos;
using Product.Entity;

namespace Product.Mapper
{
    public class ProductMapper
    {
        public static void ProductMappings()
        {
            TypeAdapterConfig<Products, ProductResponceDtos>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id);
                
        }
    }
}
