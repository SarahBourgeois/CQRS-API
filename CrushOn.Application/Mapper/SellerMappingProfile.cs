using AutoMapper;
using CrushOn.Application.Commands;
using CrushOn.Application.Reponses;
using CrushOn.Core.EntitiesModel;

public class SellerMappingProfile : Profile
{
    public SellerMappingProfile()
    {
        CreateMap<SellerModel, SellerResponse>().ReverseMap();
        CreateMap<SellerModel, CreateSellerCommand>().ReverseMap();
    }
}