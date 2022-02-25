using System;

namespace Avensia.Storefront.Developertest
{
    public class ProductListVisualizer
    {
        private readonly IProductRepository _productRepository;

        public ProductListVisualizer(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void OutputAllProduct()
        {
            var products = _productRepository.GetProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Price}");
            }
        }

        public void OutputPaginatedProducts()
        {
            throw new NotImplementedException();
        }

        public void OutputProductGroupedByPriceSegment()
        {
            throw new NotImplementedException();
        }
    }
}