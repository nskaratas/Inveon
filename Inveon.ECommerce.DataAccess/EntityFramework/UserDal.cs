using Inveon.core.EntityFramework;
using Inveon.ECommerce.DataAccess.Abstract;
using Inveon.ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inveon.ECommerce.DataAccess.EntityFramework
{
   public class UserDal : RepositoryBase<User, ECommerceDBContext>, IUserRepository
    {
        public UserDal(ECommerceDBContext context) : base(context)
        {
        }
    }
}
