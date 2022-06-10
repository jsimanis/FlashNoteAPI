using FlashNote.Models;
using System.Collections.Generic;

namespace FlashNote.Data
{
    public class MockRepo : IFlashNoteRepo
    {
        public IEnumerable<FlashCard> GetAllCards(){
            var list = new List<FlashCard> {
                new FlashCard{Id =1, Front= "make tea", Back= "jiojiojio", Subject = "Test" }, //curly brackets
                new FlashCard{Id =2, Front= "make coffee", Back= "jiojiojio", Subject = "Test" },
                new FlashCard{Id =2, Front= "make lemon water", Back= "jiojiojio", Subject = "Test" }
            };
            return list;
        }
        public FlashCard GetCardByID(int id){ //???
            return new FlashCard{Id =id, Front= "make tea", Back= "jiojiojio", Subject = "Test" };

        }
    }
}
