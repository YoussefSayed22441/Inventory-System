using Inventory_System.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string CategoryName { get; set; } 
        public string? Description { get; set; }


        #region Relation With Product
        [InverseProperty(nameof(Product.Category))]
        public ICollection<Product> Products { get; set; }
        #endregion


    }
}
