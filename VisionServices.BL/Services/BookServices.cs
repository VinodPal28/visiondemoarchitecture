using AutoMapper;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionServices.BL.Interface;
using VisionServices.BL.Mapping;
using VisionServices.Data;
using VisionServices.Data.Repository.RepositoryClass;
using VisionServices.Data.UnitOfWork;

namespace VisionServices.BL.Services
{

    public class BookServices : IBookServices
    {
        BookRepository objBookRepository = new BookRepository();
        //private readonly Mapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        MappingProfile mapper = new MappingProfile();


        /// <summary>
        /// Public constructor.
        /// </summary>
        public BookServices(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BookDTO> GetAllBook()
        {
            var lstBookDetails = _unitOfWork.BookRepository.GetAll().ToList();

            List<BookDTO> objBooklst = new List<BookDTO>();
            foreach (var item in objBookRepository.GetBooks())
            {
                BookDTO objBook = new BookDTO();
                objBook.Author = item.Author;
                objBook.Genre = item.Genre;
                objBook.Price = item.Price;
                objBook.Title = item.Title;
                objBook.Year = item.Year;
                objBooklst.Add(objBook);
            }

         
            //var lstBooks = MappingProfile.Map<List<BookDetail>, List<BookDTO>>(lstBookDetails);
            return objBooklst;
        }

        public Book GetBook(int id)
        {
            var book = _unitOfWork.BookRepository.GetByID(id);
            Book objBook = new Book();
            objBook.Author = book.Author;
            objBook.Genre = book.Genre;
            objBook.Id = book.Id;
            objBook.Price = book.Price;
            objBook.Title = book.Title;
            objBook.Year = book.Year;
            return objBook;
        }
    }


}
