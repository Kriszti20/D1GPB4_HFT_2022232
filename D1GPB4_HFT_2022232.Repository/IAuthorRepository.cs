using System.Linq;
using D1GPB4_HFT_2022232.Models;

namespace D1GPB4_HFT_2022232.Repository
{
    public interface IAuthorRepository
    {
        void Create(Author author);
        void Delete(int id);
        Author Read(int id);
        IQueryable<Author> ReadAll();
        void Update(Author author);
    }
}