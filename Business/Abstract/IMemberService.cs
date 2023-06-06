using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMemberService
    {
        IDataResult<List<Member>> GetAll();
        IDataResult<Member> GetById(int memberId);
        IResult Add(Member member);
        IResult Delete(Member member);
        IResult Update(Member member);
    }
}
