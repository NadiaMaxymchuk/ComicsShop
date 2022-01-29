using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Repositories.Classes
{
    public class TagRepository : ITagRepository
    {
        public void Add(Tag entity)
        {
            FakeDBContext.Tags.Add(entity);
        }

        public void Edit(Tag entity)
        {
            var oldEntity = FakeDBContext.Tags.FirstOrDefault(x => x.Id == entity.Id);

            if (oldEntity == null)
            {
                throw new NullReferenceException();
            }

            oldEntity.Name = entity.Name;
            oldEntity.CreationDate = entity.CreationDate;
          
        }

        // ToDo
        public Tag FindByName(string name)
        {
            return FakeDBContext.Tags.FirstOrDefault(x=>x.Name == name);
        }

        // ToDo
        public List<Tag> FindMany(Expression<Func<Tag, bool>> filter = null)
        {
            if ( filter!= null )
            {
                return FakeDBContext.Tags.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Tags;
        }

        // ToDo
        public Tag FindOne(Expression<Func<Tag, bool>> filter = null)
        {
            if( filter!= null )
            {
                return FakeDBContext.Tags.FirstOrDefault(filter.Compile());
            }

            return FakeDBContext.Tags.FirstOrDefault();
        }

        // ToDo
        public List<Tag> GetAll()
        {
            return FakeDBContext.Tags;
        }

        public void Remove(Tag tag)
        {
            FakeDBContext.Tags.Remove(tag);
        }
    }
}
