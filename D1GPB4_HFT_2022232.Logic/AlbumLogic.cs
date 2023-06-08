﻿using System;
using D1GPB4_HFT_2022232.Models;
using D1GPB4_HFT_2022232.Repository;
using System.Collections.Generic;

namespace D1GPB4_HFT_2022232.Logic
{
	public class AlbumLogic
	{
        IAlbumRepository albumRepo;
        public AlbumLogic(IAlbumRepository albumRepo)
        {
            this.albumRepo = albumRepo;
        }

        public void Create(Album album)
        {
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


    }
}
