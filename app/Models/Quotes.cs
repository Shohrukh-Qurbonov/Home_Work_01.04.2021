using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class Quotes
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Author { get; set; }
        public DateTime InsertDate { get; set; }
    }
}