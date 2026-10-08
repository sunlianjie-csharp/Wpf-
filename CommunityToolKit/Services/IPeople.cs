using CommunityToolKit.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolKit.Services
{
    public interface IPeople<T,K>:IBase<User,ViewUser>
    {
        //扩展基础接口
        List<K> GetListByPage(Func<K, bool> f1, int page, int pageSzie, ref int totalCount);
    }
}
