using CommunityToolKit.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolKit.Services.implementation
{
    public class UserService : IPeople<User, ViewUser>
    {
        public bool Add(User Model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public ViewUser GetList(Func<User, bool> f1)
        {
            throw new NotImplementedException();
        }

        public List<ViewUser> GetListByPage(Func<ViewUser, bool> f1, int page, int pageSzie, ref int totalCount)
        {
            var list = MockData.MockData.Users.Where(f1);
            var count =list.Count();
            totalCount = count;
            return list.Skip((page-1)*pageSzie).Take(pageSzie).ToList();
        }

       

        public User GetModel(int key)
        {
            throw new NotImplementedException();
        }

        public bool Update(User Model)
        {
            throw new NotImplementedException();
        }
    }
}
