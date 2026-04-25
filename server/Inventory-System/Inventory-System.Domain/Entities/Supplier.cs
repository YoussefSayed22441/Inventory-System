using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        [MaxLength(20)]
        [Phone]
        public string? Phone { get; set; }
        [MaxLength(500)]
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ProductSupplier>? ProductSuppliers { get; set; } = new List<ProductSupplier>();

    }
}
