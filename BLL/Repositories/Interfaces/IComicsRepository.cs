using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories.Interfaces
{
     interface IComicsRepository : IRepository<Comics>
    {
        public void EditComics(Comics comics);
        public void DeleteComics(Comics comics);
        public Comics FindByName(string name);
    }
}
