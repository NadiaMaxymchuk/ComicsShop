using Domain.Models;

namespace BLL.Repositories.Interfaces
{
    interface ITagRepository : IRepository<Tag>
    {
        void Remove(Tag tag);
    }
}
