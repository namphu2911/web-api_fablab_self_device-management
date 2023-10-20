using AutoMapper;
using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Resource.Equipments;
using FabLabDevice.Api.Resource.EquipmentTypes;
using FabLabDevice.Api.Resource.Locations;
using FabLabDevice.Api.Resource.Suppliers;

namespace FabLabDevice.Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateSupplierViewModel, Supplier>();
            CreateMap<CreateLocationViewModel, Location>();
            CreateMap<CreateEquipmentTypeViewModel, EquipmentType>();
            CreateMap<CreateEquipmentViewModel, Equipment>();
        }

        
    }
}
