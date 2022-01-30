using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IComicsService
    {
        void AddComics(Comics comics);
        Comics GetById(Guid id);
        Comics GetByName(string name);
        List<Comics> GetAllComics();
        void DeleteComics(Comics comics);
        public void UpdateComics(Comics comics);
        public Comics FindPartName(string name);
    }
}
