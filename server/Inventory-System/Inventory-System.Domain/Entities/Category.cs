using Inventory_System.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        #region Constructors
        public Category()
        {
            Products = new HashSet<Product>();
        }
        #endregion

        #region Props
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }
        #endregion

        #region Relation With Product
        [InverseProperty(nameof(Product.Category))]
        public ICollection<Product> Products { get; set; } = new List<Product>();
        #endregion


    }
}
