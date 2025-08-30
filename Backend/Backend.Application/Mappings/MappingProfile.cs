﻿using AutoMapper;
using Backend.Application.DTOs;
using Backend.Domain.Entities;

namespace Backend.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<CreateUpdateProductDto, Product>();
        }
    }
}
