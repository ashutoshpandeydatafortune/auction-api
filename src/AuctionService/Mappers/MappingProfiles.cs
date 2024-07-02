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
            CreateMap<CreateAuctionDTO, Item>();
            CreateMap<Auction, AuctionDTO>().IncludeMembers(x => x.Item);
            CreateMap<CreateAuctionDTO, Auction>().ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));

            CreateMap<Auction, AuctionUpdated>();
            CreateMap<AuctionDTO, AuctionCreated>();
            CreateMap<AuctionDTO, Auction>().ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));
        }
    }
}
