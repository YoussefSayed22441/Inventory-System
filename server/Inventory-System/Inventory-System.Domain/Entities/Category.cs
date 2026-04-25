using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public Guid CategoryId { get; set; } // we want to use Guid for uniqueness
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #region Relation With Product
        [InverseProperty(nameof(Product.Category))]
        public ICollection<Product> Products { get; set; } // Navigation Property
        #endregion
    }
}
