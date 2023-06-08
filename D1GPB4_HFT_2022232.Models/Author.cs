using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1GPB4_HFT_2022232.Models
{
	public class Author
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public virtual ICollection<Song> Songs { get; set; }
        [NotMapped]
        public virtual ICollection<Album> Albums { get; set; }
        public Author()
        {
            Songs = new HashSet<Song>();
            Albums = new HashSet<Album>();
        }
        
	}
}

