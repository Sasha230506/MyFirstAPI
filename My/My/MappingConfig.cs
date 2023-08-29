using AutoMapper;
using Table_Tennis_UK.Models;
using Table_Tennis_UK.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;

namespace Table_Tennis_UK
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<TableTennisClub, TableTennisClubDTO>();
            CreateMap<TableTennisClubDTO, TableTennisClub>();

            CreateMap<TableTennisClubDTO, TableTennisClubCreateDTO>().ReverseMap();
            CreateMap<TableTennisClubCreateDTO, TableTennisClubDTO>().ReverseMap();

            CreateMap<TableTennisClubCreateDTO, TableTennisClub>();
            CreateMap<TableTennisClub, TableTennisClubCreateDTO>();

            CreateMap<TableTennisClubUpdateDTO, TableTennisClub>();
            CreateMap<TableTennisClub, TableTennisClubDTO>().ReverseMap();

/*            CreateMap<VillaNumberCreateDTO, VillaNumber>();
            CreateMap<VillaNumber, VillaNumberDTO>();

            CreateMap<VillaNumberUpdateDTO, VillaNumber>();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();*/

        }
    }
}
