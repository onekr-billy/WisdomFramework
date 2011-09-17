using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using W.Model;

namespace W.IDAL
{
    public interface IUserDao
    {
        User FindById(string userId);
        void Delete(User user);
        User Save(User user);
        User SaveOrUpdate(User user);
    }
}
