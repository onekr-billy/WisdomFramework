using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate.Support;
using W.Model;
using W.IDAL;

namespace W.DAL
{
    public class UserDao : HibernateDaoSupport, IUserDao
    {
        public User Save(User user)
        {
            HibernateTemplate.Save(user);
            return user;
        }
        public User SaveOrUpdate(User user)
        {
            HibernateTemplate.SaveOrUpdate(user);
            return user;
        }
        public void Delete(User user)
        {
            HibernateTemplate.Delete(user);
        }
        public User FindById(string userId)
        {
            return HibernateTemplate.Get(typeof(User), userId) as User;
        }
    }
}
