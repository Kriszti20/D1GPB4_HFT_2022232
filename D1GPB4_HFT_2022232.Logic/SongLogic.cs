using System;
using System.Collections.Generic;
using System.Linq;
using D1GPB4_HFT_2022232.Models;
using D1GPB4_HFT_2022232.Repository;

namespace D1GPB4_HFT_2022232.Logic
{
    public class SongLogic : ISongLogic
    {
        ISongRepository songRepo;
        public SongLogic(ISongRepository songRepo)
        {
            this.songRepo = songRepo;
        }

        public void Create(Song song)
        {
            if (song.Title == null)
            {
                throw new NullReferenceException("Song is Empty");
            }
            songRepo.Create(song);
        }

        public Song Read(int id)
        {
            return songRepo.Read(id);
        }

        public IEnumerable<Song> ReadAll()
        {
            return songRepo.ReadAll();
        }
        public void Delete(int id)
        {
            songRepo.Delete(id);
        }

        public void Update(Song song)
        {
            songRepo.Update(song);
        }

        public IEnumerable<Song> EdSheeranSongs()
        {
            var result = songRepo.ReadAll().Where(x => x.Author.Name == "Ed Sheraan");
            return result;
        }

        public IEnumerable<Song> AlbumId2Songs()
        {
            var result = songRepo.ReadAll().Where(x => x.AlbumId == 2);
            return result;
        }
        public IEnumerable<Song> RockSongs()
        {
            var result = songRepo.ReadAll().Where(x => x.Genre == "Rock");
            return result;
        }


    }
}

