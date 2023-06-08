using System;
using D1GPB4_HFT_2022232.Models;
using D1GPB4_HFT_2022232.Repository;
using System.Collections.Generic;

namespace D1GPB4_HFT_2022232.Logic
{
    public class AuthorLogic : IAuthorLogic
    {
        IAuthorRepository authorRepo;
        public AuthorLogic(IAuthorRepository authorRepo)
        {
            this.authorRepo = authorRepo;
        }

        public void Create(Author author)
        {
            authorRepo.Create(author);
        }

        public Author Read(int id)
        {
            return authorRepo.Read(id);
        }

        public IEnumerable<Author> ReadAll()
        {
            return authorRepo.ReadAll();
        }

        public void Delete(int id)
        {
            authorRepo.Delete(id);
        }

        public void Update(Author author)
        {
            authorRepo.Update(author);
        }
    }
}

