using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace D1GPB4_HFT_2022232.Models
{
	public class Album
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Author Author { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Song> Songs { get; set; }
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        
	}
}

