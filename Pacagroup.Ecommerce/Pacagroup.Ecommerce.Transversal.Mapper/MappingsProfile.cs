﻿using AutoMapper;
using Pacagroup.Ecommerce.Aplicacion.DTO;
using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customers, CustomersDTO>().ReverseMap();

            //Ejemlo en caso de que Customers y CustomersDTO tengan diferentes nombres de atributos
            //CreateMap<Customers, CustomersDTO>().ReverseMap()
            //    .ForMember(destination => destination.CustomerID, source => source.MapFrom(src => src.CustomerID))
            //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
            //    .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
            //    .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
            //    .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
            //    .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
            //    .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
            //    .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
            //    .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
            //    .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
            //    .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax)).ReverseMap();

            CreateMap<Users, UsersDTO>().ReverseMap();

        }
    }
}
