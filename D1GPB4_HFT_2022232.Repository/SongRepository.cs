using System;
using D1GPB4_HFT_2022232.Models;
using System.Linq;

namespace D1GPB4_HFT_2022232.Repository
{
    public class SongRepository : ISongRepository
    {
        SongDbContext database;
        public SongRepository(SongDbContext database)
        {
            this.database = database;
        }

        public void Create(Song song)
        {
            database.Songs.Add(song);
            database.SaveChanges();
        }

        public Song Read(int id)
        {
            return database.Songs.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Song> ReadAll()
        {
            return database.Songs;
        }

        public void Delete(int id)
        {
            database.Remove(Read(id));
            database.SaveChanges();
        }

        public void Update(Song song)
        {
            var oldsong = Read(song.Id);
            oldsong.Id = song.Id;
            oldsong.Title = song.Title;
            oldsong.Genre = song.Genre;
            oldsong.AuthorId = 1;
            oldsong.AlbumId = 1;
            oldsong.Album = song.Album;
            oldsong.Author = song.Author;
            database.SaveChanges();
        }
    }
}

