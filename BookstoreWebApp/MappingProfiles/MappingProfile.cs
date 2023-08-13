using AutoMapper;
using BookstoreSdk.ViewModels;
using BookstoreWebApp.Models;

namespace BookstoreWebApp.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SdkGetUpdateBooksModel, GetUpdateBooksViewModel>();
            CreateMap<GetUpdateBooksViewModel, SdkGetUpdateBooksModel>();

            CreateMap<SdkBooksModel, BooksModel>();
            CreateMap<BooksModel, SdkBooksModel>();

            CreateMap<SdkLoginRequestModel, LoginRequestModel>();
            CreateMap<LoginRequestModel, SdkLoginRequestModel>();

            CreateMap<SdkRegisterUserModel, RegisterUserModel>();
            CreateMap<RegisterUserModel, SdkRegisterUserModel>();
        }
    }
}