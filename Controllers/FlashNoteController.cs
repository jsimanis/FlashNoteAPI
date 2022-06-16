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
using Microsoft.AspNetCore.JsonPatch;

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

        //PUT api/cards/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCard(int id, FlashCardUpdateDto cardUpdateDto){
            var flashCardModel = _repository.GetCardByID(id);
            if (flashCardModel == null)
            {
                return NotFound();
            }
            _mapper.Map(cardUpdateDto, flashCardModel); //will update
            _repository.UpdateCard(flashCardModel);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCard(int id){
            var flashCardModel = _repository.GetCardByID(id);
            if (flashCardModel == null)
            {
                return NotFound();
            }
            _repository.DeleteCard(flashCardModel);
            _repository.SaveChanges();
            return NoContent();

        }

        //PATCH api/commands/{id}
        [HttpPatch("id")]
        public ActionResult PartialCardUpdate(int id , JsonPatchDocument<FlashCardUpdateDto> patchDoc)
        {
            var flashCardModel = _repository.GetCardByID(id);
            if (flashCardModel == null)
            {
                return NotFound();
            }

            var cardToPatch = _mapper.Map<FlashCardUpdateDto>(flashCardModel);
            patchDoc.ApplyTo(cardToPatch, ModelState);
            if (!TryValidateModel(cardToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(cardToPatch, flashCardModel);
            _repository.UpdateCard(flashCardModel);
            _repository.SaveChanges();
            return NoContent();

        }
    }
}
