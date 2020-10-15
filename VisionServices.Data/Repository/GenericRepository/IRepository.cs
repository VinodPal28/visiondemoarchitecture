using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionServices.Data.Repository.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //IEnumerable<TEntity> GetBooks();
        //TEntity GetBook(int id);
    }
}
