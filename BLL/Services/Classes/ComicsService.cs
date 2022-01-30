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
    public class ComicsService : IComicsService
    {
        private readonly IComicsRepository comicsRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly ITagRepository tagRepository;

        public ComicsService()
        {
            comicsRepository = new ComicsRepository();
            authorRepository = new AuthorRepository();
            tagRepository = new TagRepository();
        }


        public void AddComics(Comics comics)
        {
            if (comics.Author != null)
            {
                if (authorRepository.FindOne(a => a.Id == comics.Author.Id) == null)
                {
                    authorRepository.Add(comics.Author);
                }
            }

            if (comics.Tags != null && comics.Tags.Count > 0)
            {
                foreach (var tag in comics.Tags)
                {
                    if (tagRepository.FindOne(t => t.Id == tag.Id) == null)
                    {
                        tagRepository.Add(tag);
                    }
                }
            }
            if(comicsRepository.FindOne(a => a.Id != comics.Author.Id) != null)
            comicsRepository.Add(comics);
        }

        public Comics GetById(Guid id)
        {
           return comicsRepository.FindOne(x=>x.Id == id);
        }

        public Comics GetByName(string name)
        {
            return comicsRepository.FindByName(name);   
        }
        public List<Comics> GetAllComics()
        {
            return comicsRepository.GetAll();   
        }

        public void DeleteComics(Comics comics)
        {
            comicsRepository.DeleteComics(comics);
        }

        public void UpdateComics(Comics comics)
        {
            comicsRepository.EditComics(comics);
        }

        public Comics FindPartName(string name)
        {
            return comicsRepository.FindOne(x=>x.Name.Contains(name));
        }
    }
}
