using System.Linq;
using D1GPB4_HFT_2022232.Models;

namespace D1GPB4_HFT_2022232.Repository
{
    public interface IAlbumRepository
    {
        void Create(Album album);
        void Delete(int id);
        Album Read(int id);
        IQueryable<Album> ReadAll();
        void Update(Album album);
    }
}