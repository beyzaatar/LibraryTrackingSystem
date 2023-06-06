using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;

        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        [ValidationAspect(typeof(MemberValidator))]
        public IResult Add(Member member)
        {
            _memberDal.Add(member);
            return new SuccessResult(Messages.MemberAdded);
        }

        public IResult Delete(Member member)
        {
            _memberDal.Delete(member);
            return new SuccessResult(Messages.MemberDeleted);
        }

        public IDataResult<List<Member>> GetAll()
        {
            return new SuccessDataResult<List<Member>>(_memberDal.GetAll(), Messages.MembersListed);
        }

        public IDataResult<Member> GetById(int memberId)
        {
            return new SuccessDataResult<Member>(_memberDal.Get(m => m.Id == memberId));
        }

        public IResult Update(Member member)
        {
            _memberDal.Update(member);
            return new SuccessResult(Messages.MemberUpdated);
        }
    }
}
