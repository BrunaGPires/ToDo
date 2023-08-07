using AutoMapper;
using TodoList.Data.Dtos;
using TodoList.Models;

namespace TodoList.Profiles
{
    public class CoinsProfile : Profile
    {
        public CoinsProfile()
        {
            CreateMap<CreateCoinsDto, Coins>();
            CreateMap<Coins, ReadCoinDto>();
        }
    }
}
