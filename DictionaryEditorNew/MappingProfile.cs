using AutoMapper;
using DictionaryEditorDbNew.Models;
using DictionaryEditorNew.Models;

namespace DictionaryEditorNew
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}