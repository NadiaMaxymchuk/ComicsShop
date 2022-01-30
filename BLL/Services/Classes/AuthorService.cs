using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using BLL.Services.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Classes
{
    public class AuthorService: IAuthorServise
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IComicsRepository comicsRepository;

        public AuthorService()
        {
            authorRepository = new AuthorRepository();
            comicsRepository = new ComicsRepository();
        }

        public void AddAuthor(Author author)
        {
            if(author == null && authorRepository.FindOne(x=>x.Id!=author.Id)==null)
            authorRepository.Add(author);
        }

        public Author GetById(Guid id)
        {
            return authorRepository.FindOne(x=>x.Id==id);   
        }

        public Author GetByName(string name)
        {
            return authorRepository.FindByName(name);
        }

        public List<Author> GetAll()
        {
            return authorRepository.GetAll();
        }

        public void DeleteAuthor(Author author)
        {
            authorRepository.Remove(author);
        }

        public void UpdateAuthor(Author author)
        {
            authorRepository.Edit(author);
        }

        public Author FindPartName(string name)
        {
            return authorRepository.FindOne(x => x.LastName.Contains(name)||x.FirstName.Contains(name));
        }

    }
}
