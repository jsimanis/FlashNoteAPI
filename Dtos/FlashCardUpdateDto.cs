using System.ComponentModel.DataAnnotations;

namespace FlashNote.Dtos{
    
    public class FlashCardUpdateDto
    { 
        [Required]
        public string Front { get; set; }
        [Required]
        public string Back { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}