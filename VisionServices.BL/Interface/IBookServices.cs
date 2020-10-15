using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionServices.BL.Interface
{
    public interface IBookServices
    {
        IEnumerable<BookDTO> GetAllBook();
        Book GetBook(int id);
    }
}
