using AutoMapper;
using TamagotchiPokemon.DTOs;
using TamagotchiPokemon.Models;

namespace TamagotchiPokemon.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PokemonDetailsResult, TamagotchiDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Abilities, opt => opt.MapFrom(src => src.Abilities.Select(a => new TamagotchiDTO.Ability { Name = a.Ability.Name })));
        }
    }

    public class PetService
    {
        private readonly IMapper _mapper;

        public PetService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TamagotchiDTO CreatePet(PokemonDetailsResult pokemon)
        {
            return _mapper.Map<TamagotchiDTO>(pokemon);
        }
    }
}
