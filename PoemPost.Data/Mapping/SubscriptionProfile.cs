using AutoMapper;
using PoemPost.Data.DTO.Subscription;
using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;

namespace PoemPost.Data.Mapping
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionDTO>()
                .ForMember(s => s.AuthorName, opt => opt
                   .MapFrom(s => s.Author.Name));
           
            CreateMap<PagedList<Subscription>, PagedList<SubscriptionDTO>>()
              .ForMember(p => p.MetaData, opt => opt
              .MapFrom(p => p.MetaData))
              .ForMember(p => p.Items, opt => opt.MapFrom(p => p.Items));

            CreateMap<SubscriptionForCreateDTO, Subscription>();
        }
    }
}
