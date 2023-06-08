using System;
using D1GPB4_HFT_2022232.Models;
using System.Linq;

namespace D1GPB4_HFT_2022232.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        SongDbContext database;
        public AuthorRepository(SongDbContext database)
        {
            this.database = database;
        }

        public void Create(Author author)
        {
            database.Authors.Add(author);
            database.SaveChanges();
        }

        public Author Read(int id)
        {
            return database.Authors.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Author> ReadAll()
        {
            return database.Authors;
        }

        public void Delete(int id)
        {
            database.Remove(Read(id));
            database.SaveChanges();
        }

        public void Update(Author author)
        {
            var oldauthor = Read(author.Id);
            oldauthor.Id = author.Id;
            oldauthor.Name = author.Name;
            database.SaveChanges();
        }
    }
}

