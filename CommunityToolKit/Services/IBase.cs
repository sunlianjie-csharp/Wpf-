using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolKit.Services
{
    public interface IBase<T,K>where K:class,new()
    {
        bool Add(T Model);
        bool Update(T Model);
        bool Delete(int key);
        T GetModel(int key);
        K GetList(Func<T,bool> f1);//传入模型
    }
}
