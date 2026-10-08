using MVVMLight.Model;
using MVVMLight.Model.DTO;
using MVVMLigtDemo.Helper;
using MVVMLigtDemo.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLight.IService
{
    public class UserService : IService<User, ViewUser>
    {
        public bool Add(User model)
        {
            return SqlSugarHelper.Db.Insertable(model).ExecuteCommand() > 0;
        }

        public bool Delete(int primaryKey)
        {
            return SqlSugarHelper.Db.Deleteable<User>().In(primaryKey).ExecuteCommand() > 0;
        }

        public List<ViewUser> GetList(Expressionable<ViewUser> exp)
        {
            return SqlSugarHelper.Db.Queryable<ViewUser>().Where(exp.ToExpression()).ToList();
        }

        public List<ViewUser> GetListByPage(Expressionable<ViewUser> exp, int page, int pageSize, ref int totalCount)
        {
            return SqlSugarHelper.Db.Queryable<ViewUser>().Where(exp.ToExpression()).OrderBy("UserId desc").ToPageList(page, pageSize, ref totalCount);
        }

        public User GetModel(int primaryKey)
        {
            return SqlSugarHelper.Db.Queryable<User>().InSingle(primaryKey);
        }

        public bool Update(User model)
        {
            return SqlSugarHelper.Db.Updateable(model).ExecuteCommand() > 0;
        }
    }
}

