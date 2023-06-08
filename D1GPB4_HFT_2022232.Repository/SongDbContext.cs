using System;
using System.Reflection;
using D1GPB4_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;

namespace D1GPB4_HFT_2022232.Repository
{
    public class SongDbContext : DbContext
    {
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public SongDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                UseLazyLoadingProxies().UseInMemoryDatabase("songdb");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>(entity =>
            {
                entity
                .HasOne(song => song.Author)
                .WithMany(author => author.Songs)
                .HasForeignKey(song => song.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity
                .HasMany(author => author.Songs)
                .WithOne(song => song.Author)
                .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Album>(entity =>
            {
                entity
                .HasOne(album => album.Author)
                .WithMany(author => author.Albums)
                .HasForeignKey(album => album.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity
                .HasOne(song => song.Album)
                .WithMany(album => album.Songs)
                .HasForeignKey(song => song.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            Author author1 = new Author() { Id = 1, Name = "Lady Gaga" };
            Author author2 = new Author() { Id = 2, Name = "Ariana Grande" };
            Author author3 = new Author() { Id = 3, Name = "Katy Perry" };
            Author author4 = new Author() { Id = 4, Name = "Selena Gomez" };
            Author author5 = new Author() { Id = 5, Name = "Ed Sheeran" };
            Author author6 = new Author() { Id = 6, Name = "Adele" };
            Author author7 = new Author() { Id = 7, Name = "Blur" };

            Album album1 = new Album() { Id = 1, Name = "The Fame Monster", AuthorId = author1.Id, ReleaseYear = 2015 };
            Album album2 = new Album() { Id = 1, Name = "My Everything", AuthorId = author2.Id, ReleaseYear = 2014 };
            Album album3 = new Album() { Id = 1, Name = "Purpose", AuthorId = author1.Id, ReleaseYear = 2015 };
            Album album4 = new Album() { Id = 1, Name = "Purpose", AuthorId = author1.Id, ReleaseYear = 2015 };
            Album album5 = new Album() { Id = 1, Name = "Divide", AuthorId = author5.Id, ReleaseYear = 2017 };
            Album album6 = new Album() { Id = 1, Name = "Blur", AuthorId = author7.Id, ReleaseYear = 1997 };


            Song song1 = new Song() { Id = 1, Title = "Bad Romance", AuthorId = author1.Id, Genre = "Pop", AlbumId = album1.Id };
            Song song2 = new Song() { Id = 2, Title = "Song 2", AuthorId = author7.Id, Genre = "Rock", AlbumId = album2.Id };
            Song song3 = new Song() { Id = 2, Title = "Break Free", AuthorId = author2.Id, Genre = "Pop", AlbumId = album2.Id };


        }
    }
}
