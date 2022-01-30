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
    public class ComicsRepository : IComicsRepository
    {
        public void Add(Comics entity)
        {
            FakeDBContext.Comicses.Add(entity);
        }

        public void Edit(Comics entity)
        {
            var oldEntity = FakeDBContext.Comicses.FirstOrDefault(x => x.Id == entity.Id);

            if (oldEntity == null)
            {
                throw new NullReferenceException();
            }

            oldEntity.Name = entity.Name;
            oldEntity.Order = entity.Order;
            oldEntity.CreationDate = entity.CreationDate;
            oldEntity.PublishingHouse = entity.PublishingHouse;
            oldEntity.Tags = entity.Tags;
            oldEntity.IsSpecial = entity.IsSpecial;
            oldEntity.Pages = entity.Pages;
            oldEntity.Author = entity.Author;
           
        }

        public Comics FindByName(string name)
        {
            return FakeDBContext.Comicses.FirstOrDefault(x => x.Name == name);
        }

        public List<Comics> FindMany(Expression<Func<Comics, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Comicses.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Comicses;
        }

        public Comics FindOne(Expression<Func<Comics, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Comicses.FirstOrDefault(filter.Compile());
            }

            return FakeDBContext.Comicses.FirstOrDefault();
        }

        public List<Comics> GetAll()
        {
            return FakeDBContext.Comicses;
        }
    }
}
