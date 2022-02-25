using System.Collections.Generic;
using System.Linq;
using inRiver.Remoting.Extension;
using inRiver.Remoting.Objects;
using inRiver.Remoting.Query;

namespace Avensia.inRiver.Developertest.Helpers
{
    public class ResourceHelper
    {
        public static void SetResourceData(inRiverContext context, Entity resourceEntity)
        {
            var mimeType = resourceEntity.GetField("ResourceMimeType").Data.ToString();

            if (mimeType.StartsWith("image/"))
            {
                resourceEntity.GetField("ResourceMedia").Data = "image";
            }
            else if (mimeType == "application/pdf")
            {
                resourceEntity.GetField("ResourceType").Data = "PDF";
            }
            else if (mimeType == "video/")
            {
                resourceEntity.GetField("ResourceType").Data = "video";
            }

            context.ExtensionManager.DataService.UpdateEntity(resourceEntity);

            var filename = resourceEntity.GetField("ResourceFilename").Data.ToString();

            if (filename.StartsWith("A") || filename.StartsWith("B") || filename.StartsWith("C") ||
                filename.StartsWith("D") || filename.StartsWith("E"))
            {
                var productCodeDigits = filename.Substring(1, 3);

                if (productCodeDigits.All(char.IsDigit))
                {
                    var productQuery = new Query
                    {
                        Criteria = new List<Criteria>
                        {
                            new Criteria {FieldTypeId = "ProductNumber", Operator = Operator.Equal, Value = filename.Substring(0, 4)}
                        }
                    };

                    var foundProduct = context.ExtensionManager.DataService.Search(productQuery, LoadLevel.DataOnly).SingleOrDefault();

                    if (foundProduct != null)
                    {
                        var productResourceLinkType = context.ExtensionManager.ModelService.GetLinkType("ProductResource");

                        var link = new Link
                        {
                            LinkType = productResourceLinkType,
                            Source = foundProduct,
                            Target = resourceEntity
                        };

                        context.ExtensionManager.DataService.AddLink(link);
                    }
                }
            }
        }
    }
}