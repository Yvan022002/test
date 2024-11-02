using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IProductService
    {
        public List<ProductDto> getAll();
        public ProductDto getById(string id);
    }
}
