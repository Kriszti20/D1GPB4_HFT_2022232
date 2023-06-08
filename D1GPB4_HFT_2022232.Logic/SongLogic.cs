using System;
using System.Collections.Generic;
using D1GPB4_HFT_2022232.Models;
using D1GPB4_HFT_2022232.Repository;

namespace D1GPB4_HFT_2022232.Logic
{
	public class SongLogic
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
                throw new NullReferenceException("Your Song Title Is Empty");
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
    }
}

