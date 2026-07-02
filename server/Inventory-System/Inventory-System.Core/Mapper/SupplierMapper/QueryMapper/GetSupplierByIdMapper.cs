using Inventory_System.Core.Features.Suppliers.Queries.DTOs;
using Inventory_System.Domain.Entities;

namespace Inventory_System.Core.Mapper.SupplierMapper
{
    public partial class SupplierProfile
    {
        public void GetSupplierByIdMapper()
        {
            //        Source  ....... Dest
            CreateMap<Supplier, SupplierDto>();
        }
    }
}
