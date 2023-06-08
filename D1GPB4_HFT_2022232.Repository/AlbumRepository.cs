using System;
using D1GPB4_HFT_2022232.Models;
using System.Linq;

namespace D1GPB4_HFT_2022232.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        SongDbContext database;
        public AlbumRepository(SongDbContext database)
        {
            this.database = database;
        }

        public void Create(Album album)
        {
            database.Albums.Add(album);
            database.SaveChanges();
        }

        public Album Read(int id)
        {
            return database.Albums.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Album> ReadAll()
        {
            return database.Albums;
        }

        public void Delete(int id)
        {
            database.Albums.Remove(Read(id));
            database.SaveChanges();
        }

        public void Update(Album album)
        {
            var oldalbum = Read(album.Id);
            oldalbum.Id = album.Id;
            oldalbum.Name = album.Name;
            oldalbum.AuthorId = 1;
            oldalbum.ReleaseYear = album.ReleaseYear;
            oldalbum.Songs = album.Songs;
            oldalbum.Author = album.Author;
            database.SaveChanges();
        }
    }
}

