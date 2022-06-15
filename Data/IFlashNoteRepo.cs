using FlashNote.Models;
using System.Collections.Generic;

namespace FlashNote.Data
{
    public interface IFlashNoteRepo   //inherits interface class
    {
         IEnumerable<FlashCard> GetAllCards();
         FlashCard GetCardByID(int id);
         void CreateCard(FlashCard newCard); //dont show implentation details
         bool SaveChanges();
    }
}