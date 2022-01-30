using BLL.Managers.Interfaces;
using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace BLL.Services.Classes
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;

        public TagService()
        {
            tagRepository = new TagRepository();
        }

        public Tag GetTagByName(string name)
        {
            return tagRepository.FindByName(name);
        }

        public void AddTag(Tag tag)
        {
            if(tag == null && tagRepository.FindOne(x=>x.Id!=tag.Id)==null)
            {
                tagRepository.Add(tag);
            }
            
        }

        public Tag GetById(Guid id)
        {
            return tagRepository.FindOne(x=>x.Id==id);
        }
        
        public Tag GetByName(string name)
        {
            return tagRepository.FindByName(name) as Tag;

        }

        public List<Tag> GetAll()
        {
            return tagRepository.GetAll();
        }

        public void DeleteTag(Tag tag)
        {
            tagRepository.Remove(tag);
        }

        public void UpdateTag(Tag tag)
        {
            tagRepository.Edit(tag);
        }

        public Tag FindPartName(string name)
        {
           return tagRepository.FindOne(x=>x.Name.Contains(name));
        }
    }
}
