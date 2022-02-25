using System.Collections.Generic;

namespace Avensia.Storefront.Developertest
{
    public class DefaultExampleProductRepository : IProductRepository
    {
        public IEnumerable<IProductDto> GetProducts()
        {
            return new List<IProductDto> { new DefaultProductDto { Id = "1", Name = "Example product", Price = 73 } };
        }

        public IEnumerable<IProductDto> GetProducts(int start, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
}