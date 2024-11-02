using WebApplication1.infrasructure;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<ProductDto> getAll()
        {
            var products= _productRepository.GetAll();
            return products.Select(p => new ProductDto(p.Name, p.Description, p.Price)).ToList();

        }

        public ProductDto getById(string id)
        {
            var product= _productRepository.GetById(id);
            return new ProductDto(product.Name, product.Description, product.Price);
        }
    }
}
