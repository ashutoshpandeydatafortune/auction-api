using AuctionService.DTO;
using AuctionService.Entities;
using AuctionService.Entities.Enums;
using AutoMapper;
using Contracts;

namespace AuctionService.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Item, AuctionDTO>();
            CreateMap<CreateAuctionDTO, Item>();
            CreateMap<AuctionDTO, AuctionCreated>();
            CreateMap<Auction, AuctionDTO>().IncludeMembers(x => x.Item);
            CreateMap<CreateAuctionDTO, Auction>().ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));

            CreateMap<Auction, AuctionDeleted>();
            CreateMap<Auction, AuctionUpdated>();

            CreateMap<AuctionDTO, Auction>()
           .ForMember(dest => dest.Item, opt => opt.MapFrom(src => new Item
           {
               Year = src.Year,
               Mileage = src.Mileage,
               Make = src.Make,
               Model = src.Model,
               Color = src.Color,
               ImageUrl = src.ImageUrl
           }))
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
           .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
