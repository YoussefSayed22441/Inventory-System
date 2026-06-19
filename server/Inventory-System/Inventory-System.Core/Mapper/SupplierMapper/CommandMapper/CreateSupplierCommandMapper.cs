using Inventory_System.Core.Features.Suppliers.Commands.Models;
using Inventory_System.Domain.Entities;

namespace Inventory_System.Core.Mapper.SupplierMapper
{
    public partial class SupplierProfile
    {
        public void CreateSupplierCommandMapper()
        {
            CreateMap<CreateSupplierCommand, Supplier>();
        }
    }
}
