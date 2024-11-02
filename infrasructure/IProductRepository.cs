namespace WebApplication1.infrasructure
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product GetById(string id);
        public void CreateProduct(string name,string description,decimal price);
    }
}
