using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories.Classes
{
    public class AuthorRepository : IAuthorRepository
    {
        public void Add(Author entity)
        {
            FakeDBContext.Authors.Add(entity);
        }

        public void Edit(Author entity)
        {
            var oldEntity = FakeDBContext.Authors.FirstOrDefault(x => x.Id == entity.Id);

            if (oldEntity == null)
            {
                throw new NullReferenceException();
            }
            oldEntity.Comicses=entity.Comicses;
            oldEntity.FirstName=entity.FirstName;
            oldEntity.LastName=entity.LastName;
            oldEntity.BirthDate=entity.BirthDate;
            oldEntity.CreationDate=entity.CreationDate;
            
        }

        public Author FindByName(string name)
        {
           return FakeDBContext.Authors.FirstOrDefault(x => x.FirstName == name || x.LastName == name);
        }

        public List<Author> FindMany(Expression<Func<Author, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Authors.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Authors;
        }

        public Author FindOne(Expression<Func<Author, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Authors.FirstOrDefault(filter.Compile());
            }

            return FakeDBContext.Authors.FirstOrDefault();
        }

        public List<Author> GetAll()
        {
            return FakeDBContext.Authors;
        }

        public void Remove(Author author)
        {
            FakeDBContext.Authors.Remove(author);
        }
    }


}
