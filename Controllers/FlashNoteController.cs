using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlashNote.Models;
using FlashNote.Data;
using AutoMapper;
using FlashNote.Dtos;

namespace FlashNote.Controllers
{
    [ApiController]
    [Route("api/cards/")]
    public class FlashNoteController : ControllerBase
    {
        private readonly IFlashNoteRepo _repository;
        private readonly IMapper _mapper;

        public FlashNoteController(IFlashNoteRepo repo, IMapper mapper){
            _repository = repo;
            _mapper = mapper;
        }
        // GET api/cards
        [HttpGet]
        public ActionResult <IEnumerable<FlashCard>> GetAllCards()
        {
            return Ok(_repository.GetAllCards());
        }

        // GET api/cards/{id}
        [HttpGet("{id}", Name="GetCardByID")]
        public ActionResult <FlashCard> GetCardByID(int id){
            var cardItem = _repository.GetCardByID(id);
            if (cardItem != null)
                return Ok(cardItem);
            return NotFound();
        }

        // POST api/cards/
        [HttpPost]
        public ActionResult <FlashCard> CreateCard(FlashCardCreateDto cardCreateDto)
        {
            var flashCardModel = _mapper.Map<FlashCard>(cardCreateDto);
            _repository.CreateCard(flashCardModel);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetCardByID), new {Id =flashCardModel.Id },flashCardModel );
    
        }

    }
}
