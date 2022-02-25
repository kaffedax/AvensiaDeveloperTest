using System;
using System.Collections.Generic;
using System.Linq;
using Avensia.inRiver.Developertest.Helpers;
using inRiver.Remoting.Extension;
using inRiver.Remoting.Extension.Interface;
using inRiver.Remoting.Objects;

namespace Avensia.inRiver.Developertest
{
    public class DeveloperListener : IEntityListener
    {
        public string Test()
        {
            return string.Join(Environment.NewLine, Context.Settings.Select(x => x.Key + ": " + x.Value));
        }

        public void EntityCreated(int entityId)
        {
            var entity = Context.ExtensionManager.DataService.GetEntity(entityId, LoadLevel.DataAndLinks);

            if (entity.EntityType.Id == "Product")
            {
                ProductHelper.SetFieldSet(Context, entity);
            }

            if (entity.EntityType.Id == "Resource")
            {
                ResourceHelper.SetResourceData(Context, entity);
            }
        }

        public void EntityUpdated(int entityId, string[] fields)
        {
            var entity = Context.ExtensionManager.DataService.GetEntity(entityId, LoadLevel.DataAndLinks);

            if (entity.EntityType.Id == "Product")
            {
                ProductHelper.SetFieldSet(Context, entity);
            }

            if (entity.EntityType.Id == "Resource")
            {
                ResourceHelper.SetResourceData(Context, entity);
            }
        }

        public void EntityDeleted(Entity deletedEntity)
        {
            
        }

        public void EntityLocked(int entityId)
        {
            
        }

        public void EntityUnlocked(int entityId)
        {
            
        }

        public void EntityFieldSetUpdated(int entityId, string fieldSetId)
        {
            
        }

        public void EntityCommentAdded(int entityId, int commentId)
        {
        }

        public void EntitySpecificationFieldAdded(int entityId, string fieldName)
        {
        }

        public void EntitySpecificationFieldUpdated(int entityId, string fieldName)
        {
        }

        public inRiverContext Context { get; set; }
        public Dictionary<string, string> DefaultSettings { get; }
    }
}