using D1GPB4_HFT_2022232.Models;
using System.Collections.Generic;

namespace D1GPB4_HFT_2022232.Logic
{
    public interface ISongLogic
    {
        IEnumerable<Song> AlbumId2Songs();
        void Create(Song song);
        void Delete(int id);
        IEnumerable<Song> EdSheeranSongs();
        Song Read(int id);
        IEnumerable<Song> ReadAll();
        IEnumerable<Song> RockSongs();
        void Update(Song song);
    }
}