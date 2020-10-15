using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionServices.Data.Repository
{
    interface IBookRepository
    {
        IEnumerable<BookDetail> GetBooks();
        BookDetail GetBook(int id);

    }
}
