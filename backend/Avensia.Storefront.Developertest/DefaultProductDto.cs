namespace Avensia.Storefront.Developertest
{
    public class DefaultProductDto : IProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}