using System.Linq;
using D1GPB4_HFT_2022232.Models;

namespace D1GPB4_HFT_2022232.Repository
{
    public interface ISongRepository
    {
        void Create(Song song);
        void Delete(int id);
        Song Read(int id);
        IQueryable<Song> ReadAll();
        void Update(Song song);
    }
}