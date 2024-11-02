namespace WebApplication1.infrasructure
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public Product(string id, string name, string description,decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            
        }
        public Product() { }

    }
}
