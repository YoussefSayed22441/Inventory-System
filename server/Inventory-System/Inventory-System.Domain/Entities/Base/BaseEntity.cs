using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory_System.Domain.Entities.Base
{
    /// <summary>
    /// Base class for all entities in the system, providing common audit and tracking properties
    /// </summary>
    public abstract class BaseEntity 
    {
        public Guid Id { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
  
    }
}
