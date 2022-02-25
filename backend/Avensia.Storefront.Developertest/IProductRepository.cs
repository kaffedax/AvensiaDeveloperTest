using System.Collections.Generic;

namespace Avensia.Storefront.Developertest
{
    public interface IProductRepository
    {
        IEnumerable<IProductDto> GetProducts();
        IEnumerable<IProductDto> GetProducts(int start, int pageSize);
    }
}