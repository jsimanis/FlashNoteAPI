using System.ComponentModel.DataAnnotations;

namespace FlashNote.Models{
    public class FlashCard{ //public and get set
        [Key]
        public int Id { get; set; }
        [Required]
        public string Front { get; set; }
        [Required]
        public string Back { get; set; }
        [Required]

        public string Subject { get; set; }
    }
}