using FlashNote.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FlashNote.Data
{
    public class SqlRepo : IFlashNoteRepo
    {
        private readonly FlashNoteContext _context;

        public SqlRepo(FlashNoteContext context){
            _context = context;
        }

        public IEnumerable<FlashCard> GetAllCards(){
            return _context.FlashCards.ToList();
        }

        public FlashCard GetCardByID(int id){ //???
            return _context.FlashCards.FirstOrDefault(p => p.Id == id);
        }

        public void CreateCard(FlashCard newCard){
            if (newCard == null){
                throw new ArgumentNullException();
            }

            _context.FlashCards.Add(newCard);

        }

        public void UpdateCard(FlashCard card)
        {
            //Do Nothing
        }

        public void DeleteCard(FlashCard card)
        {
            if (card == null){
                throw new ArgumentNullException();
            }
            _context.FlashCards.Remove(card);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        
    }
}