using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookTypeManager : IBookTypeService
    {
        IBookTypeDal _bookTypeDal;

        public BookTypeManager(IBookTypeDal bookTypeDal)
        {
            _bookTypeDal = bookTypeDal;
        }

        [ValidationAspect(typeof(BookTypeValidator))]
        public IResult Add(BookType bookType)
        {
            IResult result = BusinessRules.Run(CheckIfBookTypeNameExists(bookType.TypeName));
            if (result!=null)
            {
                return result;
            }
            _bookTypeDal.Add(bookType);
            return new SuccessResult(Messages.BookTypeAdded);
        }

        public IResult Delete(BookType bookType)
        {
            _bookTypeDal.Delete(bookType);
            return new SuccessResult(Messages.BookTypeDeleted);
        }

        public IDataResult<List<BookType>> GetAll()
        {
            return new SuccessDataResult<List<BookType>>(_bookTypeDal.GetAll(), Messages.BookTypeListed);
        }

        public IDataResult<BookType> GetById(int bookTypeId)
        {
            return new SuccessDataResult<BookType>(_bookTypeDal.Get(b => b.Id == bookTypeId));
        }

        //aynı isimde olmama iş kuralı
        private IResult CheckIfBookTypeNameExists(string bookTypeName)
        {
            var result = _bookTypeDal.GetAll(b => b.TypeName == bookTypeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BookTypeNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
