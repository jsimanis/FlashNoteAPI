using AutoMapper;
using FlashNote.Models;
using FlashNote.Dtos;

namespace FlashNote.Profiles
{
    public class FlashCardsProfile : Profile
    {
        public FlashCardsProfile()
        {
            //Source -> target
            CreateMap<FlashCardCreateDto, FlashCard>();
        }
    }
}