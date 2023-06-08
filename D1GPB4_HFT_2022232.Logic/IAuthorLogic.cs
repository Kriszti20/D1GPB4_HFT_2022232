using D1GPB4_HFT_2022232.Models;
using System.Collections.Generic;

namespace D1GPB4_HFT_2022232.Logic
{
    public interface IAuthorLogic
    {
        void Create(Author author);
        void Delete(int id);
        Author Read(int id);
        IEnumerable<Author> ReadAll();
        void Update(Author author);
    }
}