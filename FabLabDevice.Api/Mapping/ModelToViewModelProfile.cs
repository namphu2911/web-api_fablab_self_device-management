using AutoMapper;
using FabLabDevice.Api.Domains.Models;
using FabLabDevice.Api.Resource.Equipments;
using FabLabDevice.Api.Resource.EquipmentTypes;
using FabLabDevice.Api.Resource.Locations;
using FabLabDevice.Api.Resource.Suppliers;

namespace FabLabDevice.Api.Mapping
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Location, LocationViewModel>();
            CreateMap<EquipmentType, EquipmentTypeViewModel>();

            CreateMap<Equipment, EquipmentViewModel>()
                .ForMember(v => v.Location, o => o.MapFrom(e => e.Location))
                .ForMember(v => v.Supplier, o => o.MapFrom(e => e.Supplier))
                .ForMember(v => v.EquipmentType, o => o.MapFrom(e => e.EquipmentType));

                //.ForMember(v => v.Supplier.PhoneNumber, o => o.MapFrom(e => e.Supplier.PhoneNumber))
                //.ForMember(v => v.Supplier.Address, o => o.MapFrom(e => e.Supplier.Address))
                //.ForMember(v => v.EquipmentType.EquipmentTypeId, o => o.MapFrom(e => e.EquipmentType.EquipmentTypeId))
                //.ForMember(v => v.EquipmentType.EquipmentTypeName, o => o.MapFrom(e => e.EquipmentType.EquipmentTypeName))
                //.ForMember(v => v.EquipmentType.Picture, o => o.MapFrom(e => e.EquipmentType.Picture))
                //.ForMember(v => v.EquipmentType.Category, o => o.MapFrom(e => e.EquipmentType.Category));

        }
    }
}
