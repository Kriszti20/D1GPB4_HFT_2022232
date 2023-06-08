using System;
using System.Collections.Generic;
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
            Author author3 = new Author() { Id = 3, Name = "Justin Bieber" };
            Author author4 = new Author() { Id = 4, Name = "Michael Jackson" };
            Author author5 = new Author() { Id = 5, Name = "Ed Sheeran" };
            Author author6 = new Author() { Id = 6, Name = "Adele" };
            Author author7 = new Author() { Id = 7, Name = "Blur" };

            Album album1 = new Album() { Id = 1, Name = "The Fame Monster", AuthorId = author1.Id, ReleaseYear = 2015 };
            Album album2 = new Album() { Id = 2, Name = "My Everything", AuthorId = author2.Id, ReleaseYear = 2014 };
            Album album3 = new Album() { Id = 3, Name = "Bad", AuthorId = author4.Id, ReleaseYear = 1987 };
            Album album4 = new Album() { Id = 4, Name = "Purpose", AuthorId = author3.Id, ReleaseYear = 2015 };
            Album album5 = new Album() { Id = 5, Name = "Divide", AuthorId = author5.Id, ReleaseYear = 2017 };
            Album album6 = new Album() { Id = 6, Name = "Blur", AuthorId = author7.Id, ReleaseYear = 1997 };
            Album album7 = new Album() { Id = 7, Name = "21", AuthorId = author6.Id, ReleaseYear = 2011 };

            Song song1 = new Song() { Id = 1, Title = "Bad Romance", AuthorId = author1.Id, Genre = "Pop", AlbumId = album1.Id };
            Song song2 = new Song() { Id = 2, Title = "Song 2", AuthorId = author7.Id, Genre = "Rock", AlbumId = album6.Id };
            Song song3 = new Song() { Id = 3, Title = "Break Free", AuthorId = author2.Id, Genre = "Pop", AlbumId = album2.Id };
            Song song4 = new Song() { Id = 4, Title = "Smooth Criminal", AuthorId = author4.Id, Genre = "Pop", AlbumId = album3.Id };
            Song song5 = new Song() { Id = 5, Title = "What Do You Mean", AuthorId = author3.Id, Genre = "Pop", AlbumId = album4.Id };
            Song song6 = new Song() { Id = 6, Title = "Galway Girl", AuthorId = author5.Id, Genre = "Pop", AlbumId = album5.Id };
            Song song7 = new Song() { Id = 7, Title = "Rolling in the Deep", AuthorId = author6.Id, Genre = "Romantic", AlbumId = album7.Id };

            List<Author> authors = new List<Author>();
            authors.Add(author1);
            authors.Add(author2);
            authors.Add(author3);
            authors.Add(author4);
            authors.Add(author5);
            authors.Add(author6);
            authors.Add(author7);

            List<Album> albums = new List<Album>();
            albums.Add(album1);
            albums.Add(album2);
            albums.Add(album3);
            albums.Add(album4);
            albums.Add(album5);
            albums.Add(album6);
            albums.Add(album7);

            List<Song> songs = new List<Song>();
            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);
            songs.Add(song4);
            songs.Add(song5);
            songs.Add(song6);
            songs.Add(song7);

            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Album>().HasData(albums);
            modelBuilder.Entity<Song>().HasData(songs);
        }
    }
}
