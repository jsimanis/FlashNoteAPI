using FlashNote.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}