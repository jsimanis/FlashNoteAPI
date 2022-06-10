using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlashNote.Models;
using FlashNote.Data;

namespace FlashNote.Controllers
{
    [ApiController]
    [Route("api/cards/")]
    public class FlashNoteController : ControllerBase
    {
        private readonly IFlashNoteRepo _repository;
        public FlashNoteController(IFlashNoteRepo repo){
            _repository = repo;
        }
        // GET api/cards
        [HttpGet]
        public ActionResult <IEnumerable<FlashCard>> GetAllCards()
        {
            return Ok(_repository.GetAllCards());
        }

        [HttpGet("{id}")]
        public ActionResult <FlashCard> GetCardByID(int id){
            return Ok(_repository.GetCardByID(id));
        }
    }
}
