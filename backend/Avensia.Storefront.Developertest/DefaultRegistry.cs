using StructureMap;

namespace Avensia.Storefront.Developertest
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<ProductListVisualizer>().Use<ProductListVisualizer>();
            For<IProductRepository>().Use<DefaultExampleProductRepository>();
        }
    }
}