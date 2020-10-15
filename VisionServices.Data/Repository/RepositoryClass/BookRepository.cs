using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionServices.Data.Repository.RepositoryClass
{
    public class BookRepository : IBookRepository
    {
        private readonly PracticeEntities context=new PracticeEntities();
        //public BookRepository(PracticeEntities context)
        //{
        //    this.context = context;
        //}
        public BookDetail GetBook(int id)
        {
            return context.BookDetails.Find(id);
        }

        public IEnumerable<BookDetail> GetBooks()
        {
            return context.BookDetails.ToList();
        }
    }
}
