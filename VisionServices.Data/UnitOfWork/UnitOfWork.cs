using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionServices.Data.Repository.GenericRepository;

namespace VisionServices.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PracticeEntities _context = null;
        private BaseRepository<BookDetail> _bookRepository;
        private BaseRepository<User> _userRepository;
        private BaseRepository<Token> _tokenRepository;


        public UnitOfWork()
        {
            _context = new PracticeEntities();
        }

        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public BaseRepository<BookDetail> BookRepository
        {
            get
            {
                if (this._bookRepository == null)
                    this._bookRepository = new BaseRepository<BookDetail>(_context);
                return _bookRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for User repository.
        /// </summary>
        public BaseRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new BaseRepository<User>(_context);
                return _userRepository;
            }
        }
        /// <summary>
        /// Get/Set Property for User repository.
        /// </summary>
        public BaseRepository<Token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new BaseRepository<Token>(_context);
                return _tokenRepository;
            }
        }

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
