using AutoMapper;
using Nivel1.Domain.Models;
using Nivel1.Domain.ValueObject;
using Nivel1.Models;
using Nivel1.Models.Responses;

namespace Nivel1.Shared.Mappers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            #region View -> Model

            #region UserCreateRequest

            CreateMap<UserCreateRequest, Name>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Name));

            CreateMap<UserCreateRequest, YearsOld>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.YearsOld));

            CreateMap<UserCreateRequest, Cpf>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Document));

            CreateMap<UserCreateRequest, Email>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserCreateRequest, Phone>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Phone));

            CreateMap<UserCreateRequest, User>()
                .ForPath(dest => dest.Name.Value , opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.YearsOld.Value, opt => opt.MapFrom(src => src.YearsOld))
                .ForPath(dest => dest.Document.Value, opt => opt.MapFrom(src => src.Document))
                .ForPath(dest => dest.Email.Value, opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.Phone.Value, opt => opt.MapFrom(src => src.Phone));

            #endregion

            #region UserUpdateRequest

            CreateMap<UserUpdateRequest, Name>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Name));

            CreateMap<UserUpdateRequest, YearsOld>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.YearsOld));

            CreateMap<UserUpdateRequest, Email>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserUpdateRequest, Phone>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Phone));

            CreateMap<UserUpdateRequest, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.YearsOld, opt => opt.MapFrom(src => src.YearsOld))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));

            #endregion

            #endregion

            #region Model -> View

            #region UserResponse

            CreateMap<Name, UserResponse>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Value));

            CreateMap<YearsOld, UserResponse>()
                .ForMember(x => x.YearsOld, opt => opt.MapFrom(src => src.Value));

            CreateMap<Cpf, UserResponse>()
                .ForMember(x => x.Document, opt => opt.MapFrom(src => src.Value));

            CreateMap<Email, UserResponse>()
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Value));

            CreateMap<Phone, UserResponse>()
                .ForMember(x => x.Phone, opt => opt.MapFrom(src => src.Value));

            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
                .ForMember(dest => dest.YearsOld, opt => opt.MapFrom(src => src.YearsOld.Value))
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document.Value))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value));
            
            #endregion

            #endregion
        }
    }
}