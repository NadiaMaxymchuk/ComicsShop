using Domain.Models;

namespace BLL.Repositories.Interfaces
{
    interface ITagRepository : IRepository<Tag>
    {
        void Remove(Tag tag);
        public Tag FindByName(string name);
    }
}
