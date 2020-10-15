using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionServices.Data.Repository.GenericRepository;

namespace VisionServices.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Return the database reference for this UOW
        /// </summary>
        //DbContext Db { get; }
        BaseRepository<BookDetail> BookRepository { get; }
        void Save();

    }
}
