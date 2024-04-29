using AutoMapper;
using Ytsoob.Profiles.Dtos;

namespace Ytsoob.Profiles;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMap<Models.Profile, ProfileDto>()
            .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName.Value))
            .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName.Value));
    }
}
