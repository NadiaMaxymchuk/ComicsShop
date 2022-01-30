using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IAuthorServise
    {
        public Author GetById(Guid id);
        public Author GetByName(string name);
        public List<Author> GetAll();
        public void DeleteAuthor(Author author);
    }
}
