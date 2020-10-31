using OpenBots.Server.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable enable

namespace OpenBots.Server.Model.Core
{


    public class EntityOperationEvent : BusinessEvent
    {
        public EntityOperationEvent()
        {
        }

        [Display(Name = "Create")]
        public static EntityOperationEvent Create<T>(T entity, UserSecurityContext userContext, EntityOperationType operation = EntityOperationType.Unknown)
            where T : IEntity
        {
            EntityOperationEvent bizEvent = new EntityOperationEvent();
            bizEvent.EntityType = typeof(T).Name;
            bizEvent.Id = entity.Id.Value;
            bizEvent.EventOn = DateTime.UtcNow;
            bizEvent.Operation = operation;
            return bizEvent;
        }

        [Display(Name = "EntityType")]
        public string? EntityType { get; set; }

        [Display(Name = "Operation")]
        public EntityOperationType Operation { get; set; }

        [Display(Name = "Id")]
        public Guid Id { get; set; }
      
    }

    public enum EntityOperationType : int
    {
        Unknown = 0,
        Add = 1,
        Update = 2,
        Delete = 3,
        HardDelete = 4,
        Other =9
    }
}
