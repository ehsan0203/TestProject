using AutoMapper;
using Project3.Model;

namespace Project3.Mapper
{
    public class MapperMessage : Profile
    {
        public MapperMessage()
        {
            CreateMap<Message, MessageDto>().ReverseMap();
        }
    }
}
