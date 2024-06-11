using AuctionService.DTO;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Item, AuctionDTO>();
            CreateMap<AuctionDTO, Item>();
            CreateMap<CreateAuctionDTO, Item>();
            CreateMap<AuctionDTO, AuctionCreated>();
            CreateMap<Auction, AuctionDTO>().IncludeMembers(x => x.Item);
            CreateMap<AuctionDTO, Auction>().ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));
            CreateMap<CreateAuctionDTO, Auction>().ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));
        }
    }
}
