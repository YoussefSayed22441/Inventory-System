using AutoMapper;

namespace Inventory_System.Core.Mapper.SupplierMapper
{
    public partial class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            GetSupplierByIdMapper();
            CreateSupplierCommandMapper();
            UpdateSupplierCommandMapper();
        }
    }
}
