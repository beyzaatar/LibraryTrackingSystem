using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Member:IEntity
    {
        public int Id { get; set; }
        public string MemberNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
