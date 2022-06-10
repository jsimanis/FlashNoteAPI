using FlashNote.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashNote.Data
{
    public class FlashNoteContext : DbContext
    {
        public FlashNoteContext(DbContextOptions<FlashNoteContext> opt) : base(opt)
        {

        }

        public DbSet<FlashCard> FlashCards {get; set;}
    }
}