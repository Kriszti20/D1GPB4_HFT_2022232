using D1GPB4_HFT_2022232.Models;
using System.Collections.Generic;

namespace D1GPB4_HFT_2022232.Logic
{
    public interface IAlbumLogic
    {
        IEnumerable<Album> AlbumsBefore1999();
        void Create(Album album);
        void Delete(int id);
        Album Read(int id);
        IEnumerable<Album> ReadAll();
        IEnumerable<Album> StudioAlbums();
        void Update(Album album);
    }
}