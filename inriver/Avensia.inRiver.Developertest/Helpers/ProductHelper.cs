using System.Collections.Generic;
using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using inRiver.Remoting.Objects;

namespace Avensia.inRiver.Developertest.Helpers
{
    public class ProductHelper
    {
        private static Dictionary<string, string> ProductCategoryToFieldSetMap = new Dictionary<string, string>
        {
            { "fashionretail", "FashionProduct" },
            { "diy", "DIYProduct" },
            { "furniture", "FurnitureProduct" },
            { "manufacturing", "ManufacturingProduct" },
            { "food", "Food" },
        };

        public static void SetFieldSet(inRiverContext context, Entity entity)
        {
            var industryField = entity.GetField("ProductIndustry");

            if (industryField.IsEmpty())
            {
                context.ExtensionManager.DataService.RemoveEntityFieldSet(entity.Id);
            }
            else
            {
                if (ProductCategoryToFieldSetMap.TryGetValue(industryField.Data.ToString(), out var fieldSet))
                {
                    context.ExtensionManager.DataService.SetEntityFieldSet(entity.Id, fieldSet);
                }
                else
                {
                    context.Logger.Log(LogLevel.Warning, $"Could not find FieldSet for Industry {industryField.Data}");
                }
            }
        }
    }
}