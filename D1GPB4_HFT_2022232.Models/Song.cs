﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace D1GPB4_HFT_2022232.Models
{
	public class Song
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Author Author { get; set; }
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Album Album { get; set; }
        public Song()
		{
		}
	}
}

