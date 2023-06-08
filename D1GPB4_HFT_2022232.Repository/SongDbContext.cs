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
            Author author2 = new Author() { Id = 1, Name = "Lady Gaga" };
            Author author3 = new Author() { Id = 1, Name = "Lady Gaga" };
            Author author4 = new Author() { Id = 1, Name = "Lady Gaga" };
            Author author5 = new Author() { Id = 1, Name = "Lady Gaga" };

            Album album1 = new Album() { Id = 1, Name = "Purpose", AuthorId = author1.Id, ReleaseYear = 2015 };
            Song song1 = new Song() { Id = 1,Title = "Love Yourself", AuthorId = author1.Id, Genre = "Pop", AlbumId = album1.Id };
        }
    }
}
