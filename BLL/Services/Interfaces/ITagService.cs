﻿using Domain.Models;
using System;
using System.Collections.Generic;

namespace BLL.Managers.Interfaces
{
    public interface ITagService
    {
        Tag GetTagByName(string name);
        public Tag GetById(Guid id);
        public Tag GetByName(string name);
        public List<Tag> GetAll();
        public void DeleteTag(Tag tag);
        void AddTag(Tag tag); 
        void UpdateTag(Tag tag);
        public List<Tag> FindPartName(string name);

        //todo: Create Another Methods
    }
}
