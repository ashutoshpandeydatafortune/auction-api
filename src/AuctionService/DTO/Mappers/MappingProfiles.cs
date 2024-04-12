using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.DTO.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Item, AuctionDTO>();
            CreateMap<CreateAuctionDTO, Item>();
            CreateMap<Auction, AuctionDTO>().IncludeMembers(x => x.Item);
            CreateMap<CreateAuctionDTO, Auction>()
                .ForMember(d => d.Item, o => o.MapFrom(s => s));
        }
    }
}
