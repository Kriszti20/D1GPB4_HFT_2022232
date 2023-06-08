using System;
using D1GPB4_HFT_2022232.Models;
using D1GPB4_HFT_2022232.Repository;
using System.Collections.Generic;
using System.Linq;

namespace D1GPB4_HFT_2022232.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        IAlbumRepository albumRepo;
        public AlbumLogic(IAlbumRepository albumRepo)
        {
            this.albumRepo = albumRepo;
        }

        public void Create(Album album)
        {
            if (album.Name == null)
            {
                throw new NullReferenceException("Album is Empty");
            }
            albumRepo.Create(album);
        }

        public Album Read(int id)
        {
            return albumRepo.Read(id);
        }

        public IEnumerable<Album> ReadAll()
        {
            return albumRepo.ReadAll();
        }

        public void Delete(int id)
        {
            albumRepo.Delete(id);
        }
        public void Update(Album album)
        {
            albumRepo.Update(album);
        }

        public IEnumerable<Album> AlbumsBefore1999()
        {
            var result = albumRepo.ReadAll().Where(x => x.ReleaseYear < 1999);
            return result;
        }
        public IEnumerable<Album> StudioAlbums()
        {
            var result = albumRepo.ReadAll().Where(x => x.Songs.Count > 6);
            return result;
        }
    }
}

