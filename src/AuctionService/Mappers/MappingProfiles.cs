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
            CreateMap<AuctionDTO, AuctionCreated>();
            CreateMap<Auction, AuctionDTO>().IncludeMembers(x => x.Item);
            CreateMap<CreateAuctionDTO, Auction>().ForMember(d => d.Item, o => o.MapFrom(s => s));
        }
    }
}
