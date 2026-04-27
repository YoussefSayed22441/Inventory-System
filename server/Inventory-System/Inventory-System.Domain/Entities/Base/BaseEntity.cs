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
        #region Props
        // <summary>
        /// Primary key for the entity
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Indicates whether the entity is deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// UTC timestamp when the entity was created
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Username or identifier of the user who created the entity
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// UTC timestamp when the entity was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Username or identifier of the user who last updated the entity
        /// </summary>
        [StringLength(50)]
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
