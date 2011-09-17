using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Testing.NUnit;
using NUnit.Framework;
using W.IDAL;
using W.Model;

namespace W.UnitTest
{
    [TestFixture]
    public class UserDaoTest : AbstractTransactionalDbProviderSpringContextTests
    {
        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] { "objects.xml" };
            }
        }

        protected IUserDao UserDao
        {
            get
            {
                return applicationContext.GetObject("UserDao") as IUserDao;
            }
        }
        [Test]
        public void SaveUserTest()
        {
            User user = new User();
            user.UserID = "buyer000";
            user.Password = "1356";
            user.UserName = "刘翔";
            user.ValidFrom = Convert.ToDateTime("2008-8-18");
            user.ValidTo = Convert.ToDateTime("2012-8-18");
            user.CreateTime = DateTime.Now;
            UserDao.Save(user);
        }
    }
}
