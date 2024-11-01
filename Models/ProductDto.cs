namespace WebApplication1.Models
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public ProductDto(string name, string description,decimal price)
        {
            Name = name;
            Description = description;
            Price = price;

        }
    }
}
