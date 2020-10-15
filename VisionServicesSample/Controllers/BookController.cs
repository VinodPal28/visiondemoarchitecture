using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using VisionServices.BL;
using VisionServices.BL.Interface;
using VisionServices.BL.Services;
using VisionServices.Data.UnitOfWork;
using VisionServicesSample.ActionFilter;

namespace VisionServicesSample.Controllers
{
    [Authorize]
    [RoutePrefix("api/books")]
    public class BookController : ApiController
    {
       private readonly IBookServices _objBookServices;
        
        public BookController(IBookServices objBookServices)
        {
            _objBookServices = objBookServices;
        }
        
        [Route("")]        
        public IEnumerable<BookDTO> GetBooks()
        { 
            return _objBookServices.GetAllBook();
        }

        [Authorize]
        [Route("{id:int}")]
        public Book GetBooks(int id)
        {
            return _objBookServices.GetBook(id);

        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("authorize")]
        public IHttpActionResult GetForAdmin()
        {
            string x = "test";
            string xx = x.ToString();




            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }

    }

}
