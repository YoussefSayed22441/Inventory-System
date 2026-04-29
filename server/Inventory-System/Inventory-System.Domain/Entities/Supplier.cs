using Inventory_System.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory_System.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            ProductSuppliers = new HashSet<ProductSupplier>();
            StockHistories = new HashSet<StockHistory>();
        }

        public string Name { get; set; } 
        public string Email { get; set; }  
        public string Phone { get; set; }     
        public string Address { get; set; }



        #region Relation with ProductSuppliers
        public ICollection<ProductSupplier> ProductSuppliers { get; set; } 
        #endregion

        #region Relation with StockHistories 
        public ICollection<StockHistory> StockHistories { get; set; } 
        #endregion
    }
}
